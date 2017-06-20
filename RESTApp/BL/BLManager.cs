using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Google.Apis.Services;
using Google.Apis.Discovery;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Enums;




//using  RESTApp.Models;

namespace RESTApp.BL
{
    public sealed class BLManager
    {
        #region Class Members
        private static readonly BLManager m_instance = new BLManager();

        private DataAccessLayerNameSpace.DataAccessLayer m_dal = new DataAccessLayerNameSpace.DataAccessLayer();
        private DataAccessLayerNameSpace.FireBaseAccessLayer m_fbAccess = new DataAccessLayerNameSpace.FireBaseAccessLayer();
        private DataAccessLayerNameSpace.GoogleAPIAccessLayer m_googleApiAcess = new DataAccessLayerNameSpace.GoogleAPIAccessLayer();
        //private  SqlConnection m_appDBConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\YONATANT\DOWNLOADS\SERVERAPP\SERVERAPP\RESTAPP\APP_DATA\RIDEAPPDB.MDF;Integrated Security=True");
        private int m_userIDIndex = 0;
        private int m_groupIDIndex = 0;
        private int m_rideIDIndex = 0;

        private enum eUserRole { eDriver = 0, ePassenger = 1, eDeclined = 2, eUnknown = 3 }
        private enum eMatchStatus { eNew = 0, eSentForApproval = 1, eApproved = 2, eDeclined = 3, eUnknown = 4 }
        private enum eUserNotification { eNewGrpUser = 0, ePassengersList = 1 }
        private enum eGroupType {eOneTimeEvent=0, eCompany=1, eGroup=2 }

        private const int MAX_DISTANCE_DIF = 10; //[km] 

        //   private static string SERVER_KEY = "AAAAK4i1ZVc:APA91bFiG1VeSR7pVUpOvvqdspp4BlPxO46uvPB7uoKal8evatTr0-qQ1L_S6phJA74IEPff4Pa7FIT-xiNDIdxl_T0NSNO9HeIm1BlW1_AmaTR_rsCZSUs4doF0oPOFAModJRRYqfcU";
        //     private static string SENDER_ID = "186977183063";
        #endregion

        private BLManager()
        {
            m_groupIDIndex = m_dal.GetGroupsLength();
            m_userIDIndex = m_dal.GetUsersLength();
            m_rideIDIndex = m_dal.GetRidesLength();
        }

        public static BLManager Instance
        {
            get
            {
                return m_instance;
            }
        }

        #region User Methods
        public User AddNewUser(User user)
        {

            ++m_userIDIndex;
            //add new user to DB
            user.UserId = m_userIDIndex;
            return m_dal.AddUser(user);
        }

        public User GetUser(int userID)
        {
            User userObj = new User();

            //get user data from DB
            userObj = m_dal.GetUser(userID);
            return userObj;
        }

        public void UpdateUser(int userID, User userObj)
        {
            //update users table
            m_dal.UpdateUser(userID, userObj);
        }

        public void DeleteUser(int userID)
        {
            //delete from users table
            m_dal.DeleteUser(userID);
        }
        #endregion

        #region Group Methods

        public Group AddNewGroup(Group group)
        {

            ++m_groupIDIndex;
            group.GroupId = m_groupIDIndex;
            //add new group to DB
            return m_dal.AddGroup(group);
        }

        public Group GetGroup(int groupID)
        {
            //get user data from DB
            return m_dal.GetGroup(groupID);
        }

        public List<Group> GetUserGroups(int p_userId)
        {
            return m_dal.GetUserGroups(p_userId);
        }

        public void UpdateGroup(int groupID, Group groupObj)
        {
            //update groups table
            m_dal.UpdateGroups(groupID, groupObj);
        }

        public void DeleteGroup(int groupID)
        {
            List<GroupUser> grpUsers =  m_dal.GetGroupUsers(groupID);
            foreach (GroupUser grpUser in grpUsers)
            {
                m_dal.DeleteGroupUser((int)grpUser.UserId);
            }
            //delete from groups table
            m_dal.DeleteGroup(groupID);

        }

        #endregion

        #region GroupUser Methods
        public void AddNewGroupUser(int groupID, GroupUser user)
        {
            m_dal.AddGroupUser(user);

            //add new group user to DB
            GroupUserChangedEvent(groupID, (int)user.UserId);


        }

        public void AddRafaelMember(RafaelMember p_rafaelMemeber)
        {
            m_dal.AddRafaelMemeber(p_rafaelMemeber);
        }

        public int AddNewGroupUsersList(int goupID, List<string> phoneNums)
        {
           // RafaelMember curRafaeMember = null;
            User curUser = null;
            bool isListChanged = false;

            int currentGroupLength = m_dal.GetGroupUsers(goupID).Count();
            foreach (string phoneNum in phoneNums)
            {
                //Anat: Temp remove check RafaelMembers
               // curRafaeMember = m_dal.GetRafaelMember(phoneNum);
              //  if (curRafaeMember != null)
                {
                    curUser = m_dal.GetUser(phoneNum);
                    if (curUser != null)
                    {
                        GroupUser grpUser = new GroupUser();
                        grpUser.GroupId = goupID;
                        grpUser.UserId = curUser.UserId;
                        grpUser.Role = curUser.Role;
                        grpUser.From = curUser.Address;
                        grpUser.To = m_dal.GetGroup(goupID).To;
                        grpUser.Matched = 0;

                        m_dal.AddGroupUser(grpUser);

                        isListChanged = true;


                    }
                    else
                    {
                        //Send app join notification
                    }

                }
            }

            if (isListChanged)
                GroupUserChangedEvent(goupID, 0);

            int updatedGroupLength = m_dal.GetGroupUsers(goupID).Count();
            return updatedGroupLength - currentGroupLength;
        }

        public GroupUser GetGroupUser(int groupID, int userId)
        {
            GroupUser groupObj = new GroupUser();
            //get user data from DB
            return groupObj;
        }

        public void UpdateGroupUser(int groupID, GroupUser userObj)
        {
            //update groups table
            GroupUserChangedEvent(groupID, (int)userObj.UserId);
        }

        public void DeleteGroupUser(int groupID, int userId)
        {
            //delete from groups table
            GroupUserChangedEvent(groupID, userId);
        }

        //public List<GroupUser> GetAllGroupUsers(int groupId)
        //{
        //    List<GroupUser> grpUsers = m_dal.GetAllGroupUsers();

        //    foreach (GroupUser grpUser in grpUsers)
        //    {

        //        if (grpUser.GroupId != groupId)
        //        {
        //            grpUsers.Remove(grpUser);
        //        }

        //    }

        //    return grpUsers;
        //}

        public List<GroupUser> GetAllGroupPassengers(List<GroupUser> allGrpUsers)
        {
            //List<GroupUser> grpUsers = m_dal.GetAllGroupUsers(groupId);
            List<GroupUser> grpUsers = new List<GroupUser>(allGrpUsers.Count);

            foreach (GroupUser grpUser in allGrpUsers)
            {

                if (grpUser.Role == (int)eUserRole.ePassenger)
                {
                    grpUsers.Add(grpUser);
                }

            }

            return grpUsers;
        }


        public List<GroupUser> GetAllGroupUnMatchedPassengers(List<GroupUser> allGrpUsers)
        {
            List<GroupUser> grpUsers = new List<GroupUser>(allGrpUsers.Count);


            foreach (GroupUser grpUser in allGrpUsers)
            {

                if (grpUser.Role == (int)eUserRole.ePassenger &&
                    (grpUser.Matched == 0))
                {
                    grpUsers.Add(grpUser);
                }

            }

            return grpUsers;
        }

        public List<GroupUser> GetAllGroupDrivers(List<GroupUser> allGrpUsers)
        {
            //List<GroupUser> grpUsers = GetAllGroupUsers(groupId);
            List<GroupUser> grpUsers = new List<GroupUser>(allGrpUsers.Count);

            foreach (GroupUser grpUser in allGrpUsers)
            {

                if (grpUser.Role == (int)eUserRole.eDriver)
                {
                    grpUsers.Add(grpUser);
                }

            }

            return grpUsers;
        }

        #endregion

        #region Ride Methods
        public int AddNewRide(Ride ride)
        {
            m_dal.AddRide(ride);
            ++m_rideIDIndex;
            //add new group to DB
            return m_rideIDIndex;
        }

        public int AddNewRide(int driverId, int groupId, List<int> acceptedUsersIds)
        {
            Ride newRide = new Ride();
            newRide.RideId = m_rideIDIndex;
            newRide.GroupId = groupId;
            newRide.DriverId = driverId;
            newRide.Date = m_dal.GetGroup(groupId).EventTime.Value.Date;
           // newRide.Time = m_dal.GetGroup(groupId).EventTime.Value.TimeOfDay;
            newRide.Distance = 0;
             

            
            ++m_rideIDIndex;

            foreach (int userId in acceptedUsersIds)
            {
                RideUser rideUser = new RideUser();
                rideUser.RideId = newRide.RideId;
                rideUser.UserId = userId;
                m_dal.AddRideUser(rideUser);

                //update match status
                Match tempMatch = new Match();
                tempMatch.GroupId = groupId;
                tempMatch.DriverId = driverId;
                tempMatch.UserId = userId;
                tempMatch.MatchStatus = (int)eMatchStatus.eUnknown;
                m_dal.UpdateMatchStatus(tempMatch, (int)eMatchStatus.eApproved);

            }

            newRide.Distance = ComputeRideDistance(driverId, groupId, acceptedUsersIds);

            m_dal.AddRide(newRide);

            return m_rideIDIndex;
        }

      

        public int UpdateRide(int driverId, int groupId, List<int> acceptedUsersIds)
        {
            Ride currRide = m_dal.GetRide(driverId, groupId);
            if (currRide != null)
            {
                m_dal.DeleteRideUsers(currRide.RideId);

                foreach (int userId in acceptedUsersIds)
                {
                    RideUser rideUser = new RideUser();
                    rideUser.RideId = currRide.RideId;
                    rideUser.UserId = userId;
                    m_dal.AddRideUser(rideUser);

                    //update match status
                    Match tempMatch = new Match();
                    tempMatch.GroupId = groupId;
                    tempMatch.DriverId = driverId;
                    tempMatch.UserId = userId;
                    tempMatch.MatchStatus = (int)eMatchStatus.eUnknown;
                    m_dal.UpdateMatchStatus(tempMatch, (int)eMatchStatus.eApproved);

                }

                currRide.Distance = ComputeRideDistance(driverId, groupId, acceptedUsersIds);
                m_dal.UpdateRide(currRide.RideId, currRide);
                return currRide.RideId;
            }
            return -1;
        }

        private int ComputeRideDistance(int driverId, int groupId, List<int> acceptedUsersIds)
        {
            GroupUser driverUser = m_dal.GetGroupUser(driverId);
            string driverLoc = driverUser.From;
            string toLoc = driverUser.To;
            List<string> passengersLocs = new List<string>(acceptedUsersIds.Count);
            foreach (int userId in acceptedUsersIds)
            {
                passengersLocs.Add(m_dal.GetGroupUser(userId).From);
            }

            int totalRideDist = m_googleApiAcess.GetShortestDistance(driverLoc, toLoc, passengersLocs);
            return totalRideDist;
        }

        public Ride GetRide(int rideID)
        {
           
            //get user data from DB
            return m_dal.GetRide(rideID);
        }

        public void UpdateRide(int rideID, Ride rideObj)
        {
            //update rides table
            m_dal.UpdateRide(rideID, rideObj);
        }

        public void DeleteRide(int rideID)
        {
          
            m_dal.DeleteRideUsers(rideID);
            //delete from groups table
            m_dal.DeleteRide(rideID);
        }

        public int ReceiveRide(int GroupId, int driverId, List<int> acceptedUsersIds)
        {
            Ride curRide = m_dal.GetRide(GroupId, driverId);
            if (curRide == null)
            {
                AddNewRide(GroupId, driverId, acceptedUsersIds);
            }
            else
            {
                UpdateRide(GroupId, driverId, acceptedUsersIds);
            }
            return 0;
        }
        #endregion

        #region Matching Logic

        private void GroupUserChangedEvent(int groupId, int UserId)
        {
            RunMatchAlgorithm(groupId);
        }

        private void RunMatchAlgorithm(int groupId)
        {
            List<GroupUser> allGroupUsers = m_dal.GetGroupUsers(groupId);
            List<GroupUser> grpUnmatchedPassengers = GetAllGroupUnMatchedPassengers(allGroupUsers);
            List<GroupUser> grpDrivers = GetAllGroupDrivers(allGroupUsers);
            if (grpDrivers.Count > 0 && grpUnmatchedPassengers.Count > 0)
            {
                foreach (GroupUser grpPassenger in grpUnmatchedPassengers)
                {
                    foreach (GroupUser grpDriver in grpDrivers)
                    {
                        if (CheckCouple(grpDriver, grpPassenger))
                        {
                            AddNewMatch(groupId, grpDriver, grpPassenger);

                            break;
                        }
                    }

                }
            }

            SendDriversNotification(groupId, grpDrivers);
        }


        private bool CheckCouple(GroupUser driver, GroupUser passenger)
        {
            
            List<string> wayPoints = new List<string>();
            int driverAloneDist = m_googleApiAcess.GetShortestDistance(driver.From, driver.To, wayPoints);

            wayPoints.Add(passenger.From);
            int coupleDist = m_googleApiAcess.GetShortestDistance(driver.From, driver.To, wayPoints);

            if (coupleDist - driverAloneDist < MAX_DISTANCE_DIF)
                return true;

            return false;
        }

        private void AddNewMatch(int groupId, GroupUser driver, GroupUser passenger)
        {
            passenger.Matched = 1;
            Match newMatch = new Match();
            newMatch.GroupId = groupId;
            newMatch.UserId = (int)passenger.UserId;
            newMatch.DriverId = (int)driver.UserId;
            newMatch.MatchStatus = (int)eMatchStatus.eNew;
            m_dal.AddMatch(newMatch);
            m_dal.UpdateGroupUser(groupId, passenger);

            
        }
        #endregion
#region Notifications
        private void SendDriversNotification(int groupId, List<GroupUser> grpDrivers)
        {
            List<Match> grpMatches = m_dal.GetMatches(groupId);

            UserNotification driverNotification = new UserNotification();
            driverNotification.OpCode = (int)eUserNotification.ePassengersList;
            driverNotification.Title = "You have new ride ";

            foreach (GroupUser driver in grpDrivers)
            {
                driverNotification.ReceiverFBId = m_dal.GetUser((int)driver.UserId).IdFB;
                foreach (Match match in grpMatches)
                {
                    if (match.DriverId == driver.UserId && match.MatchStatus == (int)eMatchStatus.eNew)
                    {
                        GroupUser grpUser = m_dal.GetGroupUser((int)match.UserId);
                        driverNotification.NotificationObj.Add(grpUser);                     
                        m_dal.UpdateMatchStatus(match, (int)eMatchStatus.eSentForApproval);
                    }
                    
                }
                if (driverNotification.NotificationObj.Count > 0)
                    m_fbAccess.PushNotification(driverNotification);
            }

            //send notification
        }

#endregion    

    }

}
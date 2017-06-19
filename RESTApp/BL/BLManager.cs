using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RESTApp.DataAccessLayerNameSpace;
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

        DataAccessLayer m_dal = new DataAccessLayer();
        //private  SqlConnection m_appDBConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\YONATANT\DOWNLOADS\SERVERAPP\SERVERAPP\RESTAPP\APP_DATA\RIDEAPPDB.MDF;Integrated Security=True");
        private int m_userIDIndex = 0;
        private int m_groupIDIndex = 0;
        private int m_rideIDIndex = 0;

        private enum eUserRole { eDriver = 0, ePassenger = 1, eDeclined = 2, eUnknown = 3 }
        private enum eMatchStatus { eNew = 0, eApproved = 1, eDeclined = 2, eUnknown = 3 }
        private enum eUserNotification { eNewGrpUser=0, ePassengersList=1}

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
        }

        public void DeleteUser(int userID)
        {
            //delete from users table
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
            Group groupObj = new Group();
            //get user data from DB
            return m_dal.GetGroup(groupID);
        }

        public void UpdateGroup(int groupID, Group groupObj)
        {
            //update groups table
        }

        public void DeleteGroup(int groupID)
        {
            //delete from groups table
        }

        #endregion

        #region GroupUser Methods
        public void AddNewGroupUser(int groupID, GroupUser user)
        {
            m_dal.AddGroupUser(user);

            //add new group user to DB
            GroupUserChangedEvent(groupID, (int)user.UserId);


        }

        public void AddNewGroupUsersList(int goupID, List<string> phoneNums)
        {
            RafaelMember curRafaeMember = null;
            User curUser = null;
            bool isListChanged = false;

            foreach (string phoneNum in phoneNums)
            {
                curRafaeMember = m_dal.GetRafaelMember(phoneNum);
                if (curRafaeMember != null)
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
                    ( grpUser.Matched == 0))
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
        public int AddNewRide(Ride group)
        {

            ++m_rideIDIndex;
            //add new group to DB
            return m_rideIDIndex;
        }

        public Ride GetRide(int rideID)
        {
            Ride rideObj = new Ride();
            //get user data from DB
            return rideObj;
        }

        public void UpdateRide(int rideID, Ride rideObj)
        {
            //update rides table
        }

        public void DeleteRide(int rideID)
        {
            //delete from groups table
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

            SendDriversNotification(groupId);
        }


        private bool CheckCouple(GroupUser driver, GroupUser passenger)
        {
            //Add google map service here
            var client = new MapsAPIClient("AIzaSyC29znWjdwUcxAqvmlBQfa_0fGGwOQKfAo");
            // Geocoding an address
            // var geocodeResult = client.Geocoding.Geocode("1600 Amphitheatre Parkway, Mountain View, CA");
            //
            // Look up an address with reverse geocoding
            // var reverseGeocodeResult = client.Geocoding.ReverseGeocode(40.714224, -73.961452);

            // Request directions via public transit
            GoogleMapsAPI.NET.API.Directions.Responses.GetDirectionsResponse directionsResult = client.Directions.GetDirections(driver.From,
                driver.To,
                mode: TransportationModeEnum.Driving,
                departureTime: DateTime.Now);
            //Anat - check all routes
            int driverAloneDist = directionsResult.Routes[0].Summary.Length;

            List<GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Location> wayPnts = new List<GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Location>(1);
            GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation loc = new GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation(passenger.From);
            wayPnts.Add(loc);
            directionsResult = client.Directions.GetDirections(driver.From,
                driver.To,
                mode: TransportationModeEnum.Driving, waypoints: wayPnts);

            int coupleDist = directionsResult.Routes[0].Summary.Length;

            if (coupleDist - driverAloneDist < 10)
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

            //SendDriverNotification(groupId, driver, passenger);
        }

        private void SendDriversNotification(int groupId)
        {
            List<Match> grpMatches = m_dal.GetMatches(groupId);

            UserNotification driverNotification = new UserNotification();
            driverNotification.OpCode = (int)eUserNotification.ePassengersList;

            foreach (Match match in grpMatches)
            {
                driverNotification.NotificationObj.Add(match);
            }


        }

        #endregion

        }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTApp;

namespace RESTApp.DataAccessLayerNameSpace
{
    public class DataAccessLayer
    {
        #region GetLengthFunctions

        public int GetGroupsLength()
        {
            try
            {
                return m_db.Groups.Count();
            }
            catch(Exception)
            {
                return 0;
            }
       
        }

        public int GetGroupUsersLength()
        {
            try
            {
                return m_db.GroupUsers.Count();
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public int GetMatchesLength()
        {
            try
            {
                return m_db.Matches.Count();
            }
            catch(Exception)
            {
                return 0;
            }
          
        }

        public int GetRafaelMemebersLength()
        {
            try
            {
                return m_db.RafaelMembers.Count();
            }
            catch(Exception)
            {
                return 0;
            }
      
        }

        public int GetRideRequestsLength()
        {
            try
            {
                return m_db.RideRequests.Count();
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public int GetRidesLength()
        {
            try
            {
                return m_db.Rides.Count();
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public int GetRideUsersLength()
        {
            try
            {
                return m_db.RideUsers.Count();
            }
            catch(Exception)
            {
                return 0;
            }
           
        }

        public int GetUsersLength()
        {
            try
            {
                return m_db.Users.Count();
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        
        
        #endregion
        #region AddFunctions

        public User AddUser(User p_user)
        {
            try
            {
                m_db.Users.Add(p_user);
                m_db.SaveChanges();
            }
            catch(Exception e)
            {
                return null;
            }
            return p_user;
        }

        public Ride AddRide(Ride p_ride)
        {
            try
            {
                m_db.Rides.Add(p_ride);
                m_db.SaveChanges();
            }
            catch(Exception)
            {
                return null;
            }
            return p_ride;
        }

        public RafaelMember AddRafaelMemeber(RafaelMember p_rafaelMemebr)
        {
            try
            {
                m_db.RafaelMembers.Add(p_rafaelMemebr);
                m_db.SaveChanges();
            }
            catch(Exception e)
            {
                return null;
            }
            return p_rafaelMemebr;
        }

        public GroupUser AddGroupUser(GroupUser p_groupUser)
        {
            try
            {
                m_db.GroupUsers.Add(p_groupUser);
                m_db.SaveChanges();
            }
            catch(Exception)
            {
                return null;
            }
            return p_groupUser;
        }

        public Group AddGroup(Group p_group)
        {
            try
            {
                m_db.Groups.Add(p_group);
                m_db.SaveChanges();
            }
            catch(Exception)
            {
                return null;
            }
            return p_group;
        }
        public Match AddMatch(Match p_match)
        {
            try
            {
                m_db.Matches.Add(p_match);
                m_db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return p_match;
        }
        public RideRequest AddRideRequest(RideRequest p_request)
        {
            try
            {
                m_db.RideRequests.Add(p_request);
                m_db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return p_request;
        }
        public RideUser AddRideUser(RideUser p_rideUser)
        {
            try
            {
                m_db.RideUsers.Add(p_rideUser);
                m_db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return p_rideUser;
        }

        #endregion

        #region GetAllFunctions

        public List<User> GetAllUsers()
        {
            return m_db.Users.ToList();
        }

        public List<Ride> GetAllRides()
        {
            return m_db.Rides.ToList();
        }

        public List<RafaelMember> GetAllRafaelMembers()
        {
            return m_db.RafaelMembers.ToList();
        }

        public List<GroupUser> GetAllGroupUsers()
        {
            return m_db.GroupUsers.ToList();
        }

        public List<Group> GetAllGroups()
        {
            return m_db.Groups.ToList();
        }

        public List<RideUser> GetAllRideUsers()
        {
            return m_db.RideUsers.ToList();
        }

        public List<Match> GetAllMatches()
        {
            return m_db.Matches.ToList();
        }

        public List<RideRequest> GetAllRideRequests()
        {
            return m_db.RideRequests.ToList();
        }

        #endregion

        #region UpdateFunctions
        
        public User UpdateUser(int p_userId, User p_user)
        {
            try
            {
                User user = m_db.Users.First(userRecord => userRecord.UserId == p_userId);
                user.IdFB = p_user.IdFB;
                user.Mileage = p_user.Mileage;
                user.NickName = p_user.NickName;
                user.PhoneNum = p_user.PhoneNum;
                user.Address = p_user.Address;
                user.Role = p_user.Role;
                m_db.SaveChanges();
                return user;
            }
            catch(Exception)
            {
                return null;
            }

        }

        public Ride UpdateRide(int p_rideId, Ride p_ride)
        {
            try
            {
                Ride ride = m_db.Rides.First(rideRecord => rideRecord.RideId == p_rideId);
                ride.Date = p_ride.Date;
                ride.Distance = p_ride.Distance;
                ride.Time = p_ride.Time;
                ride.RideId = p_ride.RideId;
                m_db.SaveChanges();
                return ride;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public GroupUser UpdateGroupUser(int p_groupUserId, GroupUser p_groupUser)
        {
            try
            {
                GroupUser groupUser = m_db.GroupUsers.
                    First(groupUserRecord => groupUserRecord.GroupId == p_groupUserId);
                groupUser.From = p_groupUser.From;
                groupUser.Matched = p_groupUser.Matched;
                groupUser.Role = p_groupUser.Role;
                groupUser.To = p_groupUser.To;
                groupUser.UserId = p_groupUser.UserId;
                m_db.SaveChanges();
                return groupUser;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Group UpdateGroups(int p_groupId, Group p_group)
        {
            try
            {
                Group group = m_db.Groups.First(groupRecord => groupRecord.GroupId == p_groupId);
                group.AdminName = p_group.AdminName;
                group.ExpireDate = p_group.ExpireDate;
                group.From = p_group.From;
                group.Name = p_group.Name;
                group.To = p_group.To;
                group.Type = group.Type;
                m_db.SaveChanges();
                return group;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public void UpdateMatchStatus(Match p_match, int p_status)
        {
            try
            {
                Match match = m_db.Matches.First(matchRecord => matchRecord.GroupId == p_match.GroupId
                                                    && matchRecord.UserId == p_match.UserId
                                                    && matchRecord.DriverId == p_match.DriverId);
                match.MatchStatus = p_status;
                m_db.SaveChanges();
            }
            catch(Exception)
            {

            }
        }

        public Match UpdateMatches(int p_groupId, Match p_match)
        {
            try
            {
                Match match = m_db.Matches.First(matchRecord => matchRecord.GroupId == p_groupId);
                match.DriverId = p_match.DriverId;
                match.MatchStatus = p_match.MatchStatus;
                match.UserId = p_match.UserId;
                m_db.SaveChanges();
                return match;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public RideRequest UpdateRideRequests(int p_userId, RideRequest p_rideRequest)
        {
            try
            {
                RideRequest request = m_db.RideRequests
                    .First(rideRequestRecord => rideRequestRecord.UserId == p_userId);
                request.From = p_rideRequest.From;
                request.GroupId = p_rideRequest.GroupId;
                request.Role = p_rideRequest.Role;
                request.Time = p_rideRequest.Time;
                request.To = p_rideRequest.To;
                m_db.SaveChanges();
                return request;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public RideUser UpdateRideUsers(int p_rideId, RideUser p_rideUser)
        {
            try
            {
                RideUser rideUser = m_db.RideUsers
                    .First(rideUserRecord => rideUserRecord.RideId == p_rideId);
                rideUser.UserId = p_rideUser.UserId;
                m_db.SaveChanges();
                return rideUser;
            }
            catch(Exception)
            {
                return null;
            }
        }

        #endregion

        #region GetByIdFunctions
        
        public User GetUser(int p_userId)
        {
            try
            {
                User user = m_db.Users.First(userRecord => userRecord.UserId == p_userId);
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public User GetUser(string p_phoneNum)
        {
            try
            {
                User user = m_db.Users.First(userRecord => userRecord.PhoneNum == p_phoneNum);
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Ride GetRide(int p_rideId)
        {
            try
            {
                Ride ride = m_db.Rides.First(rideRecord => rideRecord.RideId == p_rideId);
                return ride;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Ride GetRide(int p_driverId, int p_groupId)
        {
            try
            {
                Ride ride = m_db.Rides.
                    First(rideRecord => rideRecord.DriverId == p_driverId && rideRecord.GroupId == p_groupId);
                return ride;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public GroupUser GetGroupUser(int p_userId)
        {
            try
            {
                GroupUser user = m_db.GroupUsers
                    .First(groupUserRecord => groupUserRecord.UserId == p_userId);
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<GroupUser> GetGroupUsers(int p_groupId)
        {
            try
            {
                List<GroupUser> groupUsersList =
                    m_db.GroupUsers.Where(groupRecord => groupRecord.GroupId == p_groupId).ToList();
                
                return groupUsersList;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Group> GetUserGroups(int p_userId)
        {
            try
            {
                List<int> userGroupsIdsList =
                    m_db.GroupUsers.Where(groupUser => groupUser.UserId == p_userId)
                                        .Select(groupUser => groupUser.GroupId).ToList();
                List<Group> userGroupsList = new List<Group>();
                foreach(var id in userGroupsIdsList)
                {
                    userGroupsList.Add(GetGroup(id));
                }
                return userGroupsList;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Group GetGroup(int p_groupId)
        {
            try
            {
                Group group = m_db.Groups.First(groupRecord => groupRecord.GroupId == p_groupId);
                return group;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Match GetMatch(int p_groupId)
        {
            try
            {
                Match match = m_db.Matches.First(matchRecord => matchRecord.GroupId == p_groupId);
                return match;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Match> GetMatches (int p_groupId)
        {

            try
            {
                List<Match> matches = m_db.Matches
                    .Where(match => match.GroupId == p_groupId).ToList();
                return matches;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public RideRequest GetRideRequest(int p_userId)
        {
            try
            {
                RideRequest rideRequest = m_db.RideRequests
                    .First(rideRequestRecord => rideRequestRecord.UserId == p_userId);
                return rideRequest;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<RideUser> GetRideUsers(int p_rideId)
        {
            try
            {
                List<RideUser> rideUsers = m_db.RideUsers
                    .Where(rideUserRecord => rideUserRecord.RideId == p_rideId).ToList();
                return rideUsers;
            }
            catch(Exception)
            {
                return null;
            }
        }

        
        public RafaelMember GetRafaelMember(string p_phoneNum)
        {
            try
            {
                RafaelMember member = m_db.RafaelMembers
                    .First(memberRecord => memberRecord.PhoneNum == p_phoneNum);
                return member;
            }
            catch(Exception)
            {
                return null;
            }
        }

        #endregion
  

        #region DeleteFunctions

        public User DeleteUser(int p_userId)
        {
            try
            {
                User user = GetUser(p_userId);
                m_db.Users.Remove(user);
                m_db.SaveChanges();
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Ride DeleteRide(int p_rideId)
        {
            try
            {
                Ride ride = GetRide(p_rideId);
                m_db.Rides.Remove(ride);
                m_db.SaveChanges();
                return ride;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public void DeleteRideUsers(int p_rideId)
        {
            try
            {
                List<RideUser> rideUsers = GetRideUsers(p_rideId);
                foreach(RideUser rideUser in rideUsers)
                {
                    m_db.RideUsers.Remove(rideUser);
                }
                m_db.SaveChanges();
            }
            catch(Exception)
            {
               
            }
        }

        public GroupUser DeleteGroupUser(int p_groupUserId)
        {
            try
            {
                GroupUser groupUser = GetGroupUser(p_groupUserId);
                m_db.GroupUsers.Remove(groupUser);
                m_db.SaveChanges();
                return groupUser;
            }
            catch
            {
                return null;
            }
        }

        public Group DeleteGroup(int p_groupId)
        {
            try
            {
                Group group = GetGroup(p_groupId);
                m_db.Groups.Remove(group);
                m_db.SaveChanges();
                return group;
            }
            catch
            {
                return null;
            }
        }

        public Match DeleteMatch(int p_groupId)
        {
            try
            {
                Match match = GetMatch(p_groupId);
                m_db.Matches.Remove(match);
                m_db.SaveChanges();
                return match;
            }
            catch
            {
                return null;
            }
        }

        public RideRequest DeleteRideRequest(int p_userId)
        {
            try
            {
                RideRequest rideRequest = GetRideRequest(p_userId);
                m_db.RideRequests.Remove(rideRequest);
                m_db.SaveChanges();
                return rideRequest;
            }
            catch
            {
                return null;
            }
        }

        //public RideUser DeleteRideUser(int p_rideId)
        //{
        //    try
        //    {
        //        RideUser rideUser = GetRideUser(p_rideId);
        //        m_db.RideUsers.Remove(rideUser);
        //        m_db.SaveChanges();
        //        return rideUser;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        
        #endregion

        #region Members

        private RideDBEntities5 m_db = new RideDBEntities5();

        #endregion

    }
    
}
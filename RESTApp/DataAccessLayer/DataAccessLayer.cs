using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.DataAccessLayerNameSpace
{
    public class DataAccessLayer
    {
        #region AddFunctions

        public User AddUser(User p_user)
        {
            try
            {
                m_db.Users.Add(p_user);
                m_db.SaveChanges();
            }
            catch(Exception)
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
            catch(Exception)
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

        #endregion

        #region UpdateFunctions
        
        public User UpdateUser(int p_userId, User p_user)
        {
            try
            {
                User user = m_db.Users.First(userRecord => userRecord.Id == p_userId);
                user.IdFB = p_user.IdFB;
                user.Mileage = p_user.Mileage;
                user.NickName = p_user.NickName;
                user.PhoneNum = p_user.PhoneNum;
                m_db.SaveChanges();
                return user;
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public Ride UpdateRide(int p_rideId, Ride p_ride)
        {
            try
            {
                Ride ride = m_db.Rides.First(rideRecord => rideRecord.Id == p_rideId);
                ride.Date = p_ride.Date;
                ride.Distance = p_ride.Distance;
                ride.DriverId = p_ride.DriverId;
                ride.Time = p_ride.Time;
                ride.UserId = p_ride.UserId;
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
                Group group = m_db.Groups.First(groupRecord => groupRecord.Id == p_groupId);
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

        #endregion

        #region GetByIdFunctions
        
        public User GetUser(int p_userId)
        {
            try
            {
                User user = m_db.Users.First(userRecord => userRecord.Id == p_userId);
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
                Ride ride = m_db.Rides.First(rideRecord => rideRecord.Id == p_rideId);
                return ride;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public GroupUser GetGroupUser(int p_groupUserId)
        {
            try
            {
                GroupUser groupUser = m_db.GroupUsers
                    .First(groupUserRecord => groupUserRecord.GroupId == p_groupUserId);
                return groupUser;
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
                Group group = m_db.Groups.First(groupRecord => groupRecord.Id == p_groupId);
                return group;
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
        
        #endregion

        #region Members

        private RideAppDBEntities m_db = new RideAppDBEntities();

        #endregion

    }
    
}
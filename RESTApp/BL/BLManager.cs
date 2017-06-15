using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RESTApp.DataAccessLayerNameSpace;


//using  RESTApp.Models;

namespace RESTApp.BL
{
    public sealed class BLManager
    {
        private static readonly BLManager m_instance = new BLManager();

        DataAccessLayer m_dal = new DataAccessLayer();
        //private  SqlConnection m_appDBConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\YONATANT\DOWNLOADS\SERVERAPP\SERVERAPP\RESTAPP\APP_DATA\RIDEAPPDB.MDF;Integrated Security=True");
        private int m_userIDIndex = 0;
        private int m_groupIDIndex = 0;
        private int m_rideIDIndex = 0;


        private BLManager() { }

        public static BLManager Instance
        {
            get
            {
                return m_instance;
            }
        }

        public int AddNewUser(User user)
        {

            ++m_userIDIndex;
            //add new user to DB
            user.Id = m_userIDIndex;
            m_dal.AddUser(user);

            return m_userIDIndex;
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


        public int AddNewGroup(Group group)
        {

            ++m_groupIDIndex;
            //add new group to DB
            return m_groupIDIndex;
        }

        public Group GetGroup(int groupID)
        {
            Group groupObj = new Group();
            //get user data from DB
            return groupObj;
        }

        public void UpdateGroup(int groupID, Group groupObj)
        {
            //update groups table
        }

        public void DeleteGroup(int groupID)
        {
            //delete from groups table
        }



        public void AddNewGroupUser(int goupID, GroupUser user)
        {

            
            //add new group user to DB
           
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
        }

        public void DeleteGroupUser(int groupID, int userId)
        {
            //delete from groups table
        }




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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace RESTApp.Controllers
{
    public class PersonController : ApiController
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yonatant\Documents\Visual Studio 2017\Projects\RESTApp\RESTApp\App_Data\DummyDB.mdf;Integrated Security=True");

        // GET: api/Person
        public IEnumerable<string> Get()
        {
            //SqlDataAdapter da = new SqlDataAdapter("SELECT Name FROM Contacts", conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            List<string> namesList = new List<string>();

            string query = "SELECT Name FROM Contacts";
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        namesList.Add(reader.GetString(0));
                    }
                }
            }

                return namesList;
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
            string query = "INSERT INTO Contacts(Name) VALUES(@value)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value", value);
           var affected = cmd.ExecuteNonQuery();
            conn.Close();
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}

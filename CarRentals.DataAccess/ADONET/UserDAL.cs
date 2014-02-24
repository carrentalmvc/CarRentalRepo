using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model;

namespace CarRentals.DataAccess.ADONET
{
   public  class UserDAL
    {

       public UserDAL(string connString)
       {
           this.ConnectionString = connString;
       }

       public string ConnectionString { get; set; }

       public int AddUser(CarRentalUser user)
       {
           //This is the AddUserMethod
           int retVal = 0;
           using (var cmd = new SqlCommand("dbo.AddCarRentalUser"))
           {
               using (var con = new SqlConnection(ConnectionString))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.Connection = con;
                   con.Open();
                   cmd.Parameters.AddWithValue("@UserId", 0);
                   cmd.Parameters["@UserId"].Direction = System.Data.ParameterDirection.Output;
                   cmd.Parameters.AddWithValue("@UserName", user.EmailAddress);
                   cmd.Parameters.AddWithValue("@Password", user.Password);
                   retVal = cmd.ExecuteNonQuery();
               }
           
           }

           return retVal;
           

          
       }
    }
}

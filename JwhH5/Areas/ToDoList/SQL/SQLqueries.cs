using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using System.Data;

namespace JwhH5.Models
{
    public class SQLqueries
    {
       
        SqlConnection connectionString = new SqlConnection ("Server=(localdb)\\mssqllocaldb;Database=ServersideH5;Trusted_Connection=True;MultipleActiveResultSets=true");
        //ToDoModel toDoModel = new();
                
        public void InsertData()
        {
            //SqlCommand cmd = new SqlCommand(null, connectionString);
            //cmd.CommandType = CommandType.StoredProcedure;
                        
            //connectionString.Open();

            //cmd.CommandText = "INSERT INTO ToDo(Userid, Titel, Beskrivelse) VALUES (@UserName, @Titel, @Beskrivelse)";

            //cmd.Parameters.AddWithValue("@UserName", toDoModel.UserName);
            //cmd.Parameters.AddWithValue("@Titel", toDoModel.Titel);
            //cmd.Parameters.AddWithValue("@Beskrivelse", toDoModel.Beskrivelse);
            //cmd.ExecuteNonQuery();
            //connectionString.Close();
        }

        public void DisplayData()
        {
            //SqlCommand cmd = new SqlCommand(null, connectionString);
            //cmd.CommandType = CommandType.StoredProcedure;
                        
            //connectionString.Open();
            //cmd.CommandText = "SELECT FROM ToDo(UserName, Titel, Beskrivelse) WHERE UserName = @UserName";
            //cmd.Parameters.AddWithValue("@Userid", toDoModel.UserName);
            //cmd.ExecuteNonQuery();
            //connectionString.Close();
        }
    }
}

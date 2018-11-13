using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
      
            using (SqlConnection connection = new SqlConnection())
            {
                ConfigurationManager.AppSettings["isTest"].ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;
                connection.ConnectionString = connectionString;

                connection.Open();

                SqlCommand create = new SqlCommand();
                create.CommandText = "create table gruppa(id int,name string );";

            }
        }
    }
}

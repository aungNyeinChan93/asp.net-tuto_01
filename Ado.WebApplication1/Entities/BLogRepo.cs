
using Ado.WebApplication1.DataModels;
using Database_01.Models;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;

namespace Ado.WebApplication1.Entities
{
    public static class BLogRepo
    {
        private static readonly SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True");

        public static List<BlogDataModel>?  GetAll()
        {
            connection.Open();

            List<BlogDataModel> blogs = new List<BlogDataModel>();

            string query = @"select * from Tbl_blogs where Tbl_Blogs.DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                blogs.Add(new BlogDataModel
                {
                    BlogId = (int)reader["BLogId"],
                    Title = (string)reader["Title"],
                    Description = (string)reader["Description"],
                    AuthorName = (string)reader["AuthorName"],
                    DeleteFlag = (bool)reader["DeleteFlag"],
                });
                Console.WriteLine($"{reader["AuthorName"]}");
            }
            connection.Close();

            return blogs;
        }
    }
}

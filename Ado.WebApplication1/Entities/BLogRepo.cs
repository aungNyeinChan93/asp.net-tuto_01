
using Ado.WebApplication1.DataModels;
using Database_01.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
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

        public static BlogDataModel? GetOne(int? id)
        {
            connection.Open();
            string query = $@"select * from Tbl_BLogs where Tbl_BLogs.BLogId = @BlogId and DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId",id);
            SqlDataReader reader = cmd.ExecuteReader();

            BlogDataModel? blog = new BlogDataModel();

            while (reader.Read() && Convert.ToBoolean(reader["DeleteFlag"] is false))
            {
                blog = new BlogDataModel
                {
                    BlogId = Convert.ToInt32(reader["BLogId"]),
                    Title = Convert.ToString(reader["Title"]),
                    Description = Convert.ToString(reader["Description"]),
                    AuthorName = Convert.ToString(reader["AuthorName"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                };
            }

            connection.Close();

            return blog is not null ? blog :null;
        }

        public static bool Update(int? id,BlogDataModel blog)
        {
            connection.Open();

            string query = @"update Tbl_Blogs
                set
                    Title = @Title,
                    Description = @Desc,
                    AuthorName = @Author
                where Tbl_blogs.BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@Title", blog.Title);
            cmd.Parameters.AddWithValue("@Desc", blog.Description);
            cmd.Parameters.AddWithValue("@Author", blog.AuthorName);

            var res = cmd.ExecuteNonQuery();

            connection.Close();

            return res >= 1 ? true : false;
        }

        //public static bool UpdateOne(int? id ,BlogDataModel blog)
        //{
        //    connection.Open();

        //    string query = $@"update Tbl_Blogs
        //        set
        //            {(!string.IsNullOrEmpty(blog.Title) ? $"Title = {blog.Title}" : null)},
        //            {(!string.IsNullOrEmpty(blog.Description) ? $"Description = {blog.Description}": null)},
        //            {(!string.IsNullOrEmpty(blog.AuthorName) ? $"AuthorName = {blog.AuthorName}" :null)}
        //        where Tbl_blogs.BlogId = @BlogId";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@BlogId", id);
        //    var res = cmd.ExecuteNonQuery();
        //    connection.Close();

        //    return (res >= 1);
        //}

        public static bool UpdateByPatch(int? id, BlogDataModel blog)
        {
            connection.Open();

            string condition = "";

            if (!string.IsNullOrEmpty(blog.Title))
            {
                condition += "[Title] = @Title, ";
            }

            if (!string.IsNullOrEmpty(blog.Description))
            {
                condition += "[Description] = @Description, ";
            }

            if (!string.IsNullOrEmpty(blog.AuthorName))
            {
                condition += "[AuthorName] = @AuthorName, ";
            }

            if(condition.Length <= 0)
            {
                return false;
            }

            condition = condition.Substring(0,condition.Length - 2);

            string query = $@"update Tbl_Blogs 
                    set {condition}
                    where Tbl_Blogs.BlogId  = @BlogId";

            SqlCommand cmd = new SqlCommand(query,connection);

            
            cmd.Parameters.AddWithValue("@BlogId", id);

            if (!string.IsNullOrEmpty(blog.Title))
            {
                cmd.Parameters.AddWithValue("@Title", blog.Title);
            }

            if (!string.IsNullOrEmpty(blog.Description))
            {
                cmd.Parameters.AddWithValue("@Description", blog.Description);
            }
            if (!string.IsNullOrEmpty(blog.AuthorName))
            {
                cmd.Parameters.AddWithValue("@AuthorName", blog.AuthorName);
            }

            var res = cmd.ExecuteNonQuery();

            connection.Close();

            return res >= 1;
        }
    }
}

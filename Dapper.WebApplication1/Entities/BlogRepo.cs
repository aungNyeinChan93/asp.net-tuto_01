using Dapper.WebApplication1.DataModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.WebApplication1.Entities
{
    public static class BlogRepo
    {
        private static readonly IDbConnection _db = new SqlConnection("Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True");

        public static List<BlogDataModel>? AllBlogs()
        {
             var blogs = _db.Query<BlogDataModel>("select * from Tbl_blogs ").ToList();
            if (blogs.Count <= 0) return null;
            return blogs;
        }

        public static BlogDataModel? GetOne(int? id)
        {
            var blog = _db.Query<BlogDataModel>("select * from Tbl_blogs where TBl_Blogs.BlogId = @BlogId",new {BlogId = id}).FirstOrDefault();
            return blog is null ? null : blog;
        }

        public static bool Create(BlogDataModel blog)
        {
            var res = _db.Execute("insert into Tbl_Blogs values (@Title,@Description,@AuthorName,@DeleteFlag)",
                new BlogDataModel { Title = blog?.Title, AuthorName = blog?.AuthorName, Description = blog?.Description, DeleteFlag = false });
            return res >= 1;
        }

        public static bool Update(int id ,BlogDataModel blog)
        {
            string query = @"update Tbl_Blogs 
                    set
                        Title = @Title,
                        Description = @Description,
                        AuthorName = @AuthorName,
                        DeleteFlag = @DeleteFlag
                    where Tbl_BLogs.BlogId = @BlogId";

            var res = _db.Execute(query, new BlogDataModel
            {
                BlogId = id,
                Title = blog?.Title,
                AuthorName = blog?.AuthorName,
                Description = blog?.Description,
                DeleteFlag = false,
            }
            );
            return res >= 1;
        }

        public static bool Delete(int? id)
        {
            var res = _db.Execute("delete from Tbl_BLogs where Tbl_BLogs.BlogId = @BLogId", new { BlogId = id });
            return res >= 1;
        }
    }
}

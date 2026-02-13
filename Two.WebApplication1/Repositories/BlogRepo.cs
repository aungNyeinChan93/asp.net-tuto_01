using One.ShareProject;
using System.Data;
using Two.WebApplication1.Models;

namespace Two.WebApplication1.Repositories
{
    public class BlogRepo
    {
        private readonly string _connectionStr = "Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private readonly AdoDotNetService _AdoService;

        public BlogRepo()
        {
            _AdoService = new AdoDotNetService(_connectionStr);
        }

        public List<BlogDataModel>? getALl()
        {
            string query = @"select * from Tbl_BLogs where Tbl_blogs.DeleteFlag = @DeleteFlag";
            var blogs = _AdoService.Query(query,new SqlQueryParameter { Name = "@DeleteFlag" ,Value = 0});
            List<BlogDataModel>? blogList = blogs!.AsEnumerable().Select(r => new BlogDataModel
            {
                BLogId = r.Field<int>("BLogId"),
                Title = r.Field<string>("Title"),
                AuthorName = r.Field<string>("AuthorName"),
                Description = r.Field<string>("Description"),
                DeleteFlag = r.Field<bool>("DeleteFlag")
            }
            ).ToList();
            return blogList!;
        }

        public BlogDataModel? GetOne(int? id)
        {
            var dt = _AdoService.Query("Select * from Tbl_BLogs where Tbl_Blogs.BlogId = @BlogId",
                new SqlQueryParameter
                {
                    Name = "@BlogId",
                    Value = id,
                }
                );
            var blog = dt!.AsEnumerable().Select(r => new BlogDataModel
            {
                BLogId = r.Field<int>("BlogId"),
                Title = r.Field<string>("Title"),   
                AuthorName = r.Field<string>("AuthorName"),
                Description = r.Field<string>("Description"),
                DeleteFlag = r.Field<bool>("DeleteFlag")
            }
            ).FirstOrDefault();

            return blog;
        }
    }
}

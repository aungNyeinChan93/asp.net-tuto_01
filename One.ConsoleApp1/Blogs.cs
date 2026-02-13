using One.ShareProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace One.ConsoleApp1
{
    internal class Blogs
    {
        private readonly string _connectionStr = "Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private readonly AdoDotNetService _AdoService;
        public Blogs()
        {
            this._AdoService = new AdoDotNetService(this._connectionStr);
        }

        public void GatAllBlogs()
        {
            string query = "select * from Tbl_BLogs where DeleteFlag = @Id";
            var blogs = _AdoService.Query(query, new SqlQueryParameter { Name = "@id", Value = 0 });
            foreach (DataRow blog in blogs!.Rows)
            {
                Console.WriteLine($"Author Name is {blog["AuthorName"]} \nTitle Name is {blog["Title"]}");
            }
            Console.WriteLine("Get All Blogs End ...");
        }

        public void GetById(int? id = 0)
        {
            var blogs = _AdoService.Query("select * from Tbl_BLogs where BlogId = @id", new SqlQueryParameter { Name = "@id", Value = id });
            for (int i = 0; i < blogs?.Rows.Count; i++)
            {
                Console.WriteLine($"Description = {blogs.Rows[i]["Description"]} \n");
            }
            Console.WriteLine("End");
        }

        public void Create(string title,string desc,string author)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blogs]
                           ([Title]
                           ,[Description]
                           ,[AuthorName]
                           ,[DeleteFlag])
                     VALUES
                           (@Title
                           ,@Description
                           ,@AuthorName
                           ,0)";

             bool isSuccess =_AdoService.Excute(query,
                new SqlQueryParameter
                {
                    Name = "@Title",
                    Value = title
                },
                new SqlQueryParameter
                {
                    Name = "@Description",
                    Value = desc
                },
                new SqlQueryParameter
                {
                    Name = "@AuthorName",
                    Value = author
                }
 
            );

            Console.WriteLine(isSuccess ? "Create Success":"Create Fail");
        }

        public string Update(int id ,string titel ,string desc,string author)
        {
            string query = @"update tbl_blogs
                             set
                                Title = @Title,
                                Description = @Description,
                                AuthorName = @AuthorName
                             where tbl_blogs.BlogId = @BlogId
                            ";
            bool isUpdateSuccess = _AdoService.Excute(query,
                new SqlQueryParameter
                {
                    Name= "@Title",
                    Value = titel
                },
                new SqlQueryParameter
                {
                    Name = "@Description",
                    Value = desc
                },
                new SqlQueryParameter
                {
                    Name = "@AuthorName",
                    Value = author
                },
                new SqlQueryParameter
                {
                    Name = "@BlogId",
                    Value = id
                }
                );
            return isUpdateSuccess ? "Update Success":"Update Fail";
        }

        public string UpdateOne(int id, string? title= "", string? desc ="", string? author ="")
        {
            string conditions = "";

            if (!string.IsNullOrEmpty(title))
            {
                conditions += "[Title] = @Title, ";
            }
            ;

            if (!string.IsNullOrEmpty(desc))
            {
                conditions += "[Description] = @Description, ";
            }

            if (!string.IsNullOrEmpty(author))
            {
                conditions += "[AuthorName] = @AuthorName, ";

            }

            conditions = conditions.Length >= 1 ? conditions.Substring(0, conditions.Length - 2) : conditions;

            string query = $@"update tbl_blogs 
                            set {conditions}
                            where tbl_blogs.BlogId = @BlogId
                            ";

            List<SqlQueryParameter>? parameters = new List<SqlQueryParameter>
            {
                title is not null ? new SqlQueryParameter{Name = "@Title", Value = title}:null!,
                desc is not null? new SqlQueryParameter{Name = "@Description", Value = desc}: null!,
                author is not null ? new SqlQueryParameter{Name = "@AuthorName",Value = author}:null!,
                new SqlQueryParameter {Name = "@BlogId",Value =id}
            };

            var isSuccess = _AdoService.Excute(query, parameters);

            return isSuccess ? "Update Success" : "Update Fail";

        }

        public string Delete(int? id)
        {
            var isSuccess = _AdoService.Excute("delete from tbl_blogs where BlogId = @BlogId",
                new SqlQueryParameter { Name = "@BlogId",Value = id});

            return isSuccess ? "Delete success" : "delete fail";
        }
    }
}

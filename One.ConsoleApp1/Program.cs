
using One.ConsoleApp1;
using One.ShareProject;
using System.Data;

//string myConnection = "Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

//AdoDotNetService adoService = new AdoDotNetService(myConnection);


//string query = @"select * from Tbl_BLogs where Tbl_BLogs.DeleteFlag = @DeleteFlag";

////List<SqlQueryParameter> sqlParameterList = new List<SqlQueryParameter>
////{
////    new SqlQueryParameter {Name = "@DeleteFlag" ,Value = 0}
////};

//var blogs = adoService.Query(query, new SqlQueryParameter { Name = "@DeleteFlag", Value = 0 });

//if(blogs is null)
//{
//    Console.WriteLine("Blogs not found!");
//    return;
//}

//foreach (DataRow blog in blogs.Rows)
//{
//    Console.WriteLine($"Author Name is {blog["AuthorName"]} \n");
//}

Blogs blogs = new Blogs();

//blogs.GatAllBlogs();

//blogs.GetById(42);

//blogs.Create(title : "this is new Title",desc: "this is desc", author:"ngng");

//blogs.Create("Title","Desc","gogo");

//Console.WriteLine(blogs.Update(57, "update title","update desc","gogogoggo"));

//Console.WriteLine(blogs.UpdateOne(57,title :"Change Title"));

Console.WriteLine(blogs.Delete(57));




using One.ShareProject;
using System.Data;

string myConnection = "Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

AdoDotNetService adoService = new AdoDotNetService(myConnection);


string query = @"select * from Tbl_BLogs where Tbl_BLogs.DeleteFlag = @DeleteFlag";
List<SqlQueryParameter> sqlParameterList = new List<SqlQueryParameter>
{
    new SqlQueryParameter {Name = "@DeleteFlag" ,Value = 0}
};

var blogs = adoService.Query(query,sqlParameterList);

if(blogs is null)
{
    Console.WriteLine("Blogs not found!");
    return;
}

foreach (DataRow blog in blogs.Rows)
{
    Console.WriteLine($"Author Name is {blog["AuthorName"]} \n");
}
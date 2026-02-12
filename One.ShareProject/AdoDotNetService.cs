using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace One.ShareProject
{
    public class AdoDotNetService
    {
        private readonly string _connection = "";

        public AdoDotNetService(string connection)
        {
            this._connection = connection;
        }

        public DataTable? Query(string query, List<SqlQueryParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(this._connection);
            SqlCommand cmd = new SqlCommand(query, connection);


            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter?.Name, parameter?.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

    }

    public class SqlQueryParameter
    {
        public string? Name  { get; set; }

        public object? Value { get; set; }
    }

}

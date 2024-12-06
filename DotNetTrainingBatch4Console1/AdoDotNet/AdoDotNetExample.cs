using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4Console1.AdoDotNet
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Testing1",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true,

        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_blog", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["BlogId"]);
                Console.WriteLine(row["BlogTitle"]);
                Console.WriteLine(row["BlogAuthor"]);
                Console.WriteLine(row["BlogContent"]);

            }

        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand($"select * from tbl_blog where BlogId = '{id}'", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow row = dt.Rows[0];
            Console.WriteLine(row["BlogId"]);
            Console.WriteLine(row["BlogTitle"]);
            Console.WriteLine(row["BlogAuthor"]);
            Console.WriteLine(row["BlogContent"]);


        }

        public void Create(string title,string author,string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

            string message = result > 0 ? "saving succesfull." : "Saving Failed";

            Console.WriteLine(message);

        }


    }
}

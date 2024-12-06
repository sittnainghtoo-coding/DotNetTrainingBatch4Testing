using Dapper;
using DotNetTrainingBatch4Console1.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4Console1.Dapper
{
    public class Dapper
    {

        private readonly string _connectionString = AppSetting.sqlConnectionStringBuilder.ConnectionString;
    
            public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            List<BlogDto> lst = connection
                .Query<BlogDto>("select * from tbl_blog")
                .ToList();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            var item = connection.Query<BlogDto>($"Select * from tbl_blog where BlogId = '{id}'")
                .FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

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

            using IDbConnection  connection = new SqlConnection(_connectionString);
            var result = connection.Execute(query);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);



        }

        


        }
    }

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4Console1
{
    public static class AppSetting
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder { get; } = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Testing1",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true
        };
    }
}

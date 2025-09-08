﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace ClickMart.API.DAO
{
    public static class DbConnectionFactory
    {
        private static readonly string _connectionString =
            "Server=localhost\\SQLEXPRESS01;Database=ClickMart;User Id=lfcro;Password=qkys32rj;TrustServerCertificate=True;";

        public static IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
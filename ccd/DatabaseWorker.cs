using System;
using System.Data;
using System.Data.SqlClient;

namespace ccd
{
    public class DatabaseWorker
    {
        private const string _connectionString = @"server=.\SQL_EXPRESS_2012;Database=CCD;Integrated Security=SSPI;";
        private IDbConnection _connection;

        private void _initConnection()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public Card GetCardById(Guid cardId)
        {
            _initConnection();
            _connection.BeginTransaction();

            _connection.Close();
            
            throw new Exception();
        }
    }
}

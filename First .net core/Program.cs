using System;
using System.Data.SqlClient;

namespace First_.net_core
{
    class Program
    {
        private const string CONNECTIONSTRING = "Data Source=WIN-0TNQQV8DGU0;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            using (var sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine(sqlConnection.Database);
                    var sqlCommand = "insert into Books values ('Лев Толстой', 'Война и Мир')";
                    using (var command = new SqlCommand(sqlCommand, sqlConnection))
                    {
                        var affectedRows = command.ExecuteNonQuery();
                        Console.WriteLine(affectedRows);
                    }
                }
                catch(SqlException exception)
                {
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine(string.Format("Соединение не установлено: {0}", exception.Message));
                    }
                    Console.WriteLine(string.Format("Другая проблема: {0}", exception.Message));
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
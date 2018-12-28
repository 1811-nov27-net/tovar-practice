using System;
using System.Data.SqlClient;

namespace ADONetConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.NET is techincally Microsofts umbrella name for all data-related libraries
            // including Entity Framework
            // but when we say "ADO.NET" we typically are talking about the older
            // way of doing thing with DataReader, DataAdapter bojects.

            // in various GUIs, you need the server URL, login, password./
            //in code, we have developed a convention to use what we call a
            //"connection string" which will jam all that data into one string
            // to connect to some data source in SQL Server

            // never commit your connection strings to source control like git.
            // they're basically passwords

            var connectionString = SecretConfiguration.ConnectionString;

            //var commandString = "SELECT * FROM Movies.Movie";

            Console.WriteLine("Enter name of movie");
            var input = Console.ReadLine();

            var commandString = $"SELECT * FROM Movies.Movie WHERE Name = '{input}';";
            // allows "SQL Injection" <-- KNOW THIS FOR EXAM
            // un-sanitized user input must not be used to construct SQL Queries
            // directly, or else hackers can access or destroy things


            // connected architecture -- we're going to receive the whole result
            // have it waiting in the network buffer
            // and use a "cursor"/iterator to read it in the row by row

            using (var connection = new SqlConnection(connectionString))
            {
                // connected architecture 
                // step 1: open the connection
                connection.Open();

                //step 2: exexcute the query
                //  (we are keeping the connection open while we are processing the results)
                using (var command = new SqlCommand(commandString, connection))

               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // command.ExecuteReader for SELECT Queriest that return things
                    //      (returns a DataReader)
                    //  command.ExcecureNonQuery for all other commands (that don't return things)
                    //      (returns an int for number of rows affected)

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object id = reader["ID"]; // access values by column name

                            object name = reader["Name"];

                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
                    }
                }
                connection.Close();
            }


        }
    }
}

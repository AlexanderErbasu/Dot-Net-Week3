using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MagazinOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source = (local);Initial Catalog=MagazinOnline; integrated security = true";

            var clientID = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //folosim using pentru ca este disposable
                SqlCommand command = new SqlCommand();
                //command.CommandText = "select * from dbo.F_GetComenziValoareMinima(@valoare)";\
                command.CommandText = "select * from client";
                //Nu folosim String.Format !!!!! (SQL Injection)
                command.Parameters.AddWithValue("@valoare", 2000);

                command.Connection = connection;

                connection.Open();

                using (SqlDataReader result = command.ExecuteReader())
                {
                    List<Client> clientList = new List<Client>();
                    while (result.Read())
                    {

                        //Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", result[0], result[1], result[2], result[3]));
                        var client = new Client();
                        client.ClientID = Convert.ToInt32(result[0]);
                        client.Nume = Convert.ToString(result[1]);
                        client.Prenume = Convert.ToString(result[2]);
                        client.CNP = Convert.ToString(result[3]);

                        clientList.Add(client);
                        
                    }
                    foreach(var client in clientList)
                        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", client.ClientID, client.Nume, client.Prenume, client.CNP));
                }

                Console.ReadLine();
            }
        }
    }
}
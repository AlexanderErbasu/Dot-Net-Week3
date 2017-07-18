using ErpDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.RepositoriesImpl
{
    public class ClientRepository : IClientRepository
    {
        string connectionString;

        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "delete from Client where ClientID=@ID";

                command.Parameters.AddWithValue("@ID", id);

                command.Connection = connection;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public IList<Client> GetAll()
        {
            var clientList = new List<Client>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "select * from Client";

                command.Connection = connection;

                connection.Open();



                using (SqlDataReader result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var client = new Client();

                        client.ClientId = Convert.ToInt32(result[0]);
                        client.Nume = Convert.ToString(result[1]);
                        client.Prenume = Convert.ToString(result[2]);
                        client.CNP = Convert.ToString(result[3]);

                        clientList.Add(client);
                    }
                }

                connection.Close();


            }
            return clientList;
        }

        public Client GetById(int id)
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "select * from Client where ClientID=@ID";

                command.Parameters.AddWithValue("@ID", id);

                command.Connection = connection;

                connection.Open();



                using (SqlDataReader result = command.ExecuteReader())
                {
                    if (result.Read())
                    {
                        var client = new Client();

                        client.ClientId = Convert.ToInt32(result[0]);
                        client.Nume = Convert.ToString(result[1]);
                        client.Prenume = Convert.ToString(result[2]);
                        client.CNP = Convert.ToString(result[3]);
                        return client;
                    }
                }
            }
            return null;
        }
        public int Insert(Client entity)
        {
            int SmthElse;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "insert into Client(Nume,Prenume,CNP) values (@Nume,@Prenume,@CNP); select max(ClientID) from Client";

                command.Parameters.AddWithValue("@Nume", entity.Nume);
                command.Parameters.AddWithValue("@Prenume", entity.Prenume);
                command.Parameters.AddWithValue("@CNP", entity.CNP);

                command.Connection = connection;

                connection.Open();
                

                SqlDataReader result = command.ExecuteReader();

                if (result.Read())
                {
                    SmthElse = Convert.ToInt32(result[0]);

                    return SmthElse;
                }


            }


            return -1000;

        }

        public void Update(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "Update Client set Nume = @Nume, Prenume = @Prenume, CNP = @CNP where ClientID=@ClientID";

                command.Parameters.AddWithValue("@Nume", entity.Nume);
                command.Parameters.AddWithValue("@Prenume", entity.Prenume);
                command.Parameters.AddWithValue("@CNP", entity.CNP);
                command.Parameters.AddWithValue("@ClientID", entity.ClientId);

                command.Connection = connection;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();

            }

        }
    }
}

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
            throw new NotImplementedException();
        }

        public IList<Client> GetAll()
        {
            var clientList = new List<Client>();

            using(var connection = CreateConnection())
            {
                using (var command = CreateCommand("select * from Client", connection))
                {
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entity = ReaderToEntity(reader);

                            clientList.Add(entity);
                        }
                    }
                }
            }

            return clientList;
        }

        public Client GetById(int id)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand("select * from Client where ClientId = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var entity = ReaderToEntity(reader);

                            return entity;
                        }
                    }
                }
            }

            return null;
        }

        public int Insert(Client entity)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand("insert into Client(Nume, Prenume, CNP) values (@Nume, @Prenume, @CNP); select cast(IDENT_CURRENT( 'Client' ) as int) ", connection))
                {
                    command.Parameters.AddWithValue("@Nume", entity.Nume);
                    command.Parameters.AddWithValue("@Prenume", entity.Prenume);
                    command.Parameters.AddWithValue("@CNP", entity.CNP);

                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var id = (int)reader[0];

                        return id;
                    }
                }
            }
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }

        private SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }

        private SqlCommand CreateCommand(string text, SqlConnection connection)
        {
            return new SqlCommand(text, connection);
        }

        private Client ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Client();

            entity.ClientId = (int)reader["ClientId"];
            entity.Nume = (string)reader["Nume"];
            entity.Prenume = (string)reader["Prenume"];
            entity.CNP = (string)reader["CNP"];

            return entity;
        }
    }
}

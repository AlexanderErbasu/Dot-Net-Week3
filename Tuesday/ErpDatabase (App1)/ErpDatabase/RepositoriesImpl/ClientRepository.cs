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
        string deleteSql = @"delete Client where ClientId = @id";
        string updateSql = @"update Client set Nume = @Nume, Prenume = @Prenume, CNP = @CNP where ClientId = @id";
        string insertSql = @"insert into Client(Nume, Prenume, CNP) values (@Nume, @Prenume, @CNP); select IDENT_CURRENT('Client')";
        string getOneSql = @"select ClientID, Nume, Prenume, CNP from Client where ClientId = @id ";
        string getAllSql = @"select ClientID, Nume, Prenume, CNP from Client ";

        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private SqlCommand CreateCommand(string sqlText, SqlConnection connection)
        {
            return new SqlCommand(sqlText, connection); 
        }

        public void Delete(int id)
        {
            using(var connection = OpenConnection())
            {
                using(var command = CreateCommand(deleteSql, connection))
                {
                    command.Parameters.AddWithValue(@"@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IList<Client> GetAll()
        {
            var list = new List<Client>();

            using (var connection = OpenConnection())
            {
                using (var command = CreateCommand(getAllSql, connection))
                {
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReaderToEntity(reader));
                        }
                    }
                }
            }

            return list;
        }

        public Client GetById(int id)
        {
            using (var connection = OpenConnection())
            {
                using (var command = CreateCommand(getOneSql, connection))
                {
                    command.Parameters.AddWithValue(@"@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReaderToEntity(reader);
                        }
                    }
                }
            }

            return null;
        }

        public int Insert(Client entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");
                
            using (var connection = OpenConnection())
            {
                using (var command = CreateCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue(@"@Nume", entity.Nume);
                    command.Parameters.AddWithValue(@"@Prenume", entity.Prenume);
                    command.Parameters.AddWithValue(@"@CNP", entity.CNP);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void Update(Client entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");

            using (var connection = OpenConnection())
            {
                using (var command = CreateCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue(@"@id", entity.ClientId);
                    command.Parameters.AddWithValue(@"@Nume", entity.Nume);
                    command.Parameters.AddWithValue(@"@Prenume", entity.Prenume);
                    command.Parameters.AddWithValue(@"@CNP", entity.CNP);

                    command.ExecuteNonQuery();
                }
            }
        }

        private Client ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Client();

            entity.ClientId = Convert.ToInt32(reader["ClientId"]);
            entity.CNP = Convert.ToString(reader["CNP"]);
            entity.Nume = Convert.ToString(reader["Nume"]);
            entity.Prenume = Convert.ToString(reader["Prenume"]);

            return entity;
        }
    }
}

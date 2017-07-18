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
    public class CategorieRepository : ICategorieRepository
    {
        string connectionString;
        string deleteSql = @"delete Categorie where CategorieId = @id";
        string updateSql = @"update Categorie set Nume = @Nume where CategorieId = @id";
        string insertSql = @"insert into Categorie(Nume) values (@Nume); select IDENT_CURRENT('Categorie')";
        string getOneSql = @"select CategorieId, Nume from Categorie where CategorieId = @id ";
        string getAllSql = @"select CategorieId, Nume from Categorie ";

        public CategorieRepository(string connectionString)
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

        public IList<Categorie> GetAll()
        {
            var list = new List<Categorie>();

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

        public Categorie GetById(int id)
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

        public int Insert(Categorie entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");
                
            using (var connection = OpenConnection())
            {
                using (var command = CreateCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue(@"@Nume", entity.Nume);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void Update(Categorie entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");

            using (var connection = OpenConnection())
            {
                using (var command = CreateCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue(@"@id", entity.CategorieId);
                    command.Parameters.AddWithValue(@"@Nume", entity.Nume);

                    command.ExecuteNonQuery();
                }
            }
        }

        private Categorie ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Categorie();

            entity.CategorieId = Convert.ToInt32(reader["CategorieId"]);
            entity.Nume = Convert.ToString(reader["Nume"]);

            return entity;
        }
    }
}

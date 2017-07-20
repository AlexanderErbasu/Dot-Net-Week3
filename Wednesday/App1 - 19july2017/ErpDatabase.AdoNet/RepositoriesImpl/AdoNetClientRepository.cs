using ErpDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.AdoNet.RepositoriesImpl
{
    public class AdoNetClientRepository : AdoNetAbstractRepository<Client>, IClientRepository
    {
        public AdoNetClientRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override string deleteSql()
        {
            return @"delete Client where ClientId = @id";
        }
        protected override string updateSql()
        {
            return @"update Client set Nume = @Nume, Prenume = @Prenume, CNP = @CNP where ClientId = @id";
        }
        protected override string insertSql()
        {
            return @"insert into Client(Nume, Prenume, CNP) values (@Nume, @Prenume, @CNP); select IDENT_CURRENT('Client')";
        }
        protected override string getOneSql()
        {
            return @"select ClientID, Nume, Prenume, CNP from Client where ClientId = @id ";
        }
        protected override string getAllSql()
        {
            return @"select ClientID, Nume, Prenume, CNP from Client ";
        }

        protected override  Client ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Client();

            entity.Id = Convert.ToInt32(reader["ClientId"]);
            entity.CNP = Convert.ToString(reader["CNP"]);
            entity.Nume = Convert.ToString(reader["Nume"]);
            entity.Prenume = Convert.ToString(reader["Prenume"]);

            return entity;
        }

        protected override void AddUpdateParameters(SqlCommand command, Client entity)
        {
            command.Parameters.AddWithValue(@"@id", entity.Id);
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@Prenume", entity.Prenume);
            command.Parameters.AddWithValue(@"@CNP", entity.CNP);
        }

        protected override void AddInsertParameters(SqlCommand command, Client entity)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@Prenume", entity.Prenume);
            command.Parameters.AddWithValue(@"@CNP", entity.CNP);
        }
    }
}

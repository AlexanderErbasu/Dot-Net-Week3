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
    public class AdoNetProdusRepository : AdoNetAbstractRepository<Produs>, IProdusRepository
    {
        public AdoNetProdusRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override string deleteSql()
        {
            return @"delete Produs where ProdusId = @id";
        }
        protected override string updateSql()
        {
            return @"update Produs set Nume = @Nume, CategorieId = @CategorieId, Pret = @Pret where ProdusId = @id";
        }
        protected override string insertSql()
        {
            return @"insert into Produs(Nume, CategorieId, Pret) values (@Nume, @CategorieId, @Pret); select IDENT_CURRENT('Produs')";
        }
        protected override string getOneSql()
        {
            return @"select ProdusID, Nume, CategorieId, Pret from Produs where ProdusId = @id ";
        }
        protected override string getAllSql()
        {
            return @"select ProdusID, Nume, CategorieId, Pret from Produs ";
        }

        protected override  Produs ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Produs();

            entity.Id = Convert.ToInt32(reader["ProdusId"]);
            entity.CategorieId = Convert.ToInt32(reader["CategorieId"]);
            entity.Nume = Convert.ToString(reader["Nume"]);
            entity.Pret = Convert.ToDecimal(reader["Pret"]);

            return entity;
        }

        protected override void AddUpdateParameters(SqlCommand command, Produs entity)
        {
            command.Parameters.AddWithValue(@"@id", entity.Id);
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@CategorieId", entity.CategorieId);
            command.Parameters.AddWithValue(@"@Pret", entity.Pret);
        }

        protected override void AddInsertParameters(SqlCommand command, Produs entity)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@CategorieId", entity.CategorieId);
            command.Parameters.AddWithValue(@"@Pret", entity.Pret);
        }
    }
}

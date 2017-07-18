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
    public class ProdusRepository : AbstractRepository<Produs>, IProdusRepository
    {
        public ProdusRepository(SqlConnection connectionString) : base(connectionString)
        {
        }

        protected override void AddInsertParameters(SqlCommand command, Produs entity)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@CategorieID", entity.CategorieID);
            command.Parameters.AddWithValue(@"@Pret", entity.Pret);
        }

        protected override void AddUpdateParameters(SqlCommand command, Produs entity)
        {
            command.Parameters.AddWithValue(@"@id", entity.Id);
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@CategorieID", entity.CategorieID);
            command.Parameters.AddWithValue(@"@Pret", entity.Pret);
        }

        protected override string deleteSql()
        {
            return "delete from Produs where ProdusID = @id";
        }

        protected override string getAllSql()
        {
            return "select * from Produs";
        }

        protected override string getOneSql()
        {
            return "select * from Produs where ProdusID = @id";
        }

        protected override string insertSql()
        {
            return "insert into Produs (Nume,CategorieID,Pret) values (@Nume,@CategorieID,@Pret); select IDENT_CURRENT('Produs')";
        }

        protected override Produs ReaderToEntity(SqlDataReader reader)
        {
            var produs = new Produs();

            produs.Id = Convert.ToInt32(reader["ProdusID"]);
            produs.Nume = Convert.ToString(reader["Nume"]);
            produs.CategorieID = Convert.ToInt32(reader["CategorieID"]);
            produs.Pret = Convert.ToDecimal(reader["Pret"]);

            return produs;
        }

        protected override string updateSql()
        {
            return @"update Produs set Nume = @Nume, CategorieID = @CategorieID, Pret = @Pret where ProdusID = @id";
        }
    }
}

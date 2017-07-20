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
    public class AdoNetCategorieRepository : AdoNetAbstractRepository<Categorie>, ICategorieRepository
    {
        public AdoNetCategorieRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override string deleteSql()
        {
            return @"delete Categorie where CategorieId = @id";
        }

        protected override string updateSql()
        {
            return @"update Categorie set Nume = @Nume where CategorieId = @id";
        }

        protected override string insertSql()
        {
            return @"insert into Categorie(Nume) values (@Nume); select IDENT_CURRENT('Categorie')";
        }

        protected override string getOneSql()
        {
            return @"select CategorieId, Nume from Categorie where CategorieId = @id ";
        }

        protected override string getAllSql()
        {
            return @"select CategorieId, Nume from Categorie ";
        }

        protected override Categorie ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Categorie();

            entity.Id = Convert.ToInt32(reader["CategorieId"]);
            entity.Nume = Convert.ToString(reader["Nume"]);

            return entity;
        }

        protected override void AddUpdateParameters(SqlCommand command, Categorie entity)
        {
            command.Parameters.AddWithValue("@id", entity.Id);
            command.Parameters.AddWithValue("@Nume", entity.Nume);
        }

        protected override void AddInsertParameters(SqlCommand command, Categorie entity)
        {
            command.Parameters.AddWithValue("@Nume", entity.Nume);
        }
    }
}

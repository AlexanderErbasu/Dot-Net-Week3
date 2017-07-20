using ErpDatabase.Entities;
using ErpDatabase.AdoNet.RepositoriesImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class AdoNetComplexTest
    {
        protected string connectionString = @"Data Source=.\sql2014;Initial Catalog=MagazinOnline;User ID=sa;Password=1234%asd;";

        [TestInitialize]
        public void Initialize()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var cleanupClient = new SqlCommand(@"delete Client where Nume = 'Client XXX'", connection))
                {
                    cleanupClient.ExecuteNonQuery();
                }
                using (var cleanupCategorie = new SqlCommand(@"delete Categorie where Nume = 'Produs XXX'", connection))
                {
                    cleanupCategorie.ExecuteNonQuery();
                }
                using (var cleanupProdus = new SqlCommand(@"delete Produs where Nume = 'Produs YYY'", connection))
                {
                    cleanupProdus.ExecuteNonQuery();
                }
            }
        }

        [TestMethod]
        public void WhenInserting3EntitiesInTransactionWeGetAll3()
        {
            // insert 3 entitati Categorie, Client, Produs
            var categorie = new Categorie { Nume = "Produs XXX" };
            var client = new Client { Nume = "Client XXX", CNP = "232323232", Prenume = "Client XXX prenume" };
            var produs = new Produs { Nume = "Produs YYY", CategorieId = 1, Pret = 12 };

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var categorieRepository = new AdoNetCategorieRepository(connection);
                var clientRepository = new AdoNetClientRepository(connection);
                var produsRepository = new AdoNetProdusRepository(connection);

                var categorieId = categorieRepository.Insert(categorie);
                var clientId = clientRepository.Insert(client);
                var produsId = produsRepository.Insert(produs);

                var categorieActual = categorieRepository.GetById(categorieId);
                var clientActual = clientRepository.GetById(clientId);
                var produsActual = produsRepository.GetById(produsId);

                categorie.AssertAreSame(categorieActual, false);
                client.AssertAreSame(clientActual, false);
                produs.AssertAreSame(produsActual, false);
            }
        }

        [TestMethod]
        public void WhenInserting3EntitiesWithCategorieNonExistentWeGet()
        {
            // insert 3 entitati Categorie, Client, Produs
            var categorie = new Categorie { Nume = "Produs XXX" };
            var client = new Client { Nume = "Client XXX", CNP = "232323232", Prenume = "Client XXX prenume" };
            var produs = new Produs { Nume = "Produs YYY", CategorieId = 99999999, Pret = 12 };

            int categorieId = 0;
            int clientId = 0;
            int produsId = 0;

            Categorie categorieActual = null;
            Client clientActual = null;
            Produs produsActual = null;

            try
            {
                using (var transactionScope = new TransactionScope())
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        var categorieRepository = new AdoNetCategorieRepository(connection);
                        var clientRepository = new AdoNetClientRepository(connection);
                        var produsRepository = new AdoNetProdusRepository(connection);

                        categorieId = categorieRepository.Insert(categorie);
                        clientId = clientRepository.Insert(client);
                        produsId = produsRepository.Insert(produs);

                        categorieActual = categorieRepository.GetById(categorieId);
                        clientActual = clientRepository.GetById(clientId);
                        produsActual = produsRepository.GetById(produsId);

                        categorie.AssertAreSame(categorieActual, false);
                        client.AssertAreSame(clientActual, false);
                        produs.AssertAreSame(produsActual, false);
                    }

                    transactionScope.Complete();
                }
            }
            catch (SqlException)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var categorieRepository = new AdoNetCategorieRepository(connection);
                    var clientRepository = new AdoNetClientRepository(connection);
                    var produsRepository = new AdoNetProdusRepository(connection);

                    categorieActual = categorieRepository.GetById(categorieId);
                    clientActual = clientRepository.GetById(clientId);
                    produsActual = produsRepository.GetById(produsId);

                }

                Assert.IsNull(categorieActual);
                Assert.IsNull(clientActual);
                Assert.IsNull(produsActual);
            }
        }
    }
}

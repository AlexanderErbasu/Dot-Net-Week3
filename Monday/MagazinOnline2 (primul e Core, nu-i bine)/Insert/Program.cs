using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert
{
    class Program
    {
        static void AfiseazaProduse(string connectionString, string CommandText)
        {
                       
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = CommandText;
                
                command.Connection = connection;

                connection.Open();


                var result = command.ExecuteScalar();


                Console.WriteLine("Numar produse= " + Convert.ToInt32(result));

                connection.Close();
            }

        }
        static void AdaugaProduse(string connectionString, string CommandText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = CommandText;

                command.Connection = connection;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
            static void Main(string[] args)
        {
            var connectionString = @"Data Source = (local);Initial Catalog=MagazinOnline; integrated security = true";
            
            AfiseazaProduse(connectionString, "select count(*) from Produs");


            AdaugaProduse(connectionString, String.Format("insert into Produs(Nume,CategorieID,Pret) values ({0}, {1}, {2})", "'Telefon Alcatel'", 3, 1000));

            AfiseazaProduse(connectionString, "select count(*) from Produs");

            Console.ReadLine();
        }
    }
}

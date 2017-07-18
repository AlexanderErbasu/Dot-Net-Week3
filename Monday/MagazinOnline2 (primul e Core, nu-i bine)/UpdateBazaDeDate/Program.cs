using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateBazaDeDate
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source = (local);Initial Catalog=MagazinOnline; integrated security = true";

            var prenume = "Robert22";
            var ID = "1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "update client set Prenume = @prenume where ClientID=@ID";
                command.Parameters.AddWithValue("@prenume", prenume);
                command.Parameters.AddWithValue("@ID", ID);

                command.Connection = connection;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}

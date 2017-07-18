using System;


namespace MagazinOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source = local; Catalog=MagazinOnline; integrated security = true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //folosim using pentru ca este disposable
                SqlCommand command = new SqlCommand();
                command.CommandText = "select * from Client";
                command.Connection = connection;

                connection.Open();

                using (SqlDataReader result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}",result[0], result[1], result[2], result[3]));
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
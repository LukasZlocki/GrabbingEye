using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows;
using System.Data;

using SludgeProCreator.Models;

namespace SludgeProCreator.ModelsSql
{
    class SqlAdapter
    {
        #region def of static connection server parameters 
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=PolishStocks;Integrated Security=True";
        //static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=OrdersStatus;Integrated Security=True";
        #endregion


        // constr
        public SqlAdapter()
        {
            // ToDo : Not needed delete it and cancel button "ServerOn"
            /*   
               string connectionString = SERVER_CONFIG;
               string queryString = "SELECT * FROM PolishStocksCompanies";

               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                   SqlCommand command = new SqlCommand(queryString, connection);
                   connection.Open();

                   SqlDataReader reader = command.ExecuteReader();

                   int _readCount = 0;
                   while (reader.Read())
                   {
                       _readCount++;
                       MessageBox.Show(" " + _readCount);
                   }

                   reader.Close();

               }
               */
        }


        // GET all companies (polish stocks)
        public void GetPolishCompanies(ref List<StocksPolishCompany> stocksPolishCompanies)
        {
            // ToDo : code to get data from Sql
            string connectionString = SERVER_CONFIG;
            string queryString = "SELECT * FROM PolishStocksCompanies";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSqlSingleRows((IDataRecord)reader);
                }

                reader.Close();

            }
        }

        private void ReadSqlSingleRows(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", record[0], record[1], record[2], record[3]));
        }

    }
}

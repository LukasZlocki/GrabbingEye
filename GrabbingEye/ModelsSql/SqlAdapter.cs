using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows;
using System.Data;

using GrabbingEye.Models;

namespace GrabbingEye.ModelsSql
{
    class SqlAdapter
    {
        #region def of static connection server parameters 
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=PolishStocks;Integrated Security=True";
        #endregion

        List<PolishCompany> ListOfPolishCompanies = new List<PolishCompany>();

        // constr
        public SqlAdapter()
        {         
            LoadPolishCompanies(ref ListOfPolishCompanies);
        }


        // GET all companies (polish stocks)
        private void LoadPolishCompanies(ref List<PolishCompany> listOfPolishCompanies)
        {
            // ToDo : code to get data from Sql
            string connectionString = SERVER_CONFIG;
            string queryString = "SELECT * FROM PolishCompanies";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AddCompanyToList((IDataRecord)reader, ref listOfPolishCompanies);
                }
                reader.Close();
            }
        }

        private void AddCompanyToList(IDataRecord record, ref List<PolishCompany> companyList)
        {
            PolishCompany company = new PolishCompany();

            company.Id = Convert.ToInt32(record[0]);
            company.Name = Convert.ToString(record[1]);
            company.Ticker = Convert.ToString(record[2]);
            company.Index = Convert.ToString(record[3]);
            company.ISIN = Convert.ToString(record[4]);

            companyList.Add(company);

           // Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", record[0], record[1], record[2], record[3], record[4]));            
        }

        // GET - raport
        public string GetRaport()
        {
            string _raport = "";
            int _quantity = 0;

            _quantity = this.ListOfPolishCompanies.Count;
            _raport = "Companies loaded : " + _quantity;

            return (_raport);
        }

    }
}

using GrabbingEye.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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


        // load all companies (polish stocks)
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

        public List<PolishCompany> GetListOfCompanies()
        {
            return (this.ListOfPolishCompanies);
        }


        //SAVE - Financial data to Sql
        public void SaveFinancialDataOnSqlServer(List<FinancialRaport> FinancialRaportsList)
        {
            using (SqlConnection connection = new SqlConnection(SERVER_CONFIG))
            {
                String query = "INSERT INTO dbo.FinancialData (CompanyName,RaportYear,PrzychodyZeSprzedazy,ZyskZeSprzedazy,ZyskOperacyjny,ZyskZDzialalnosciGospodarczej,ZyskPrzedOpodatkowaniem,ZyskNetto,ZyskNettoAkcjonariuszyJednostkiDominujacej,EBITDA) "
                    + "VALUES "
                    + "(@CompanyName, @RaportYear, @PrzychodyZeSprzedazy, @ZyskZeSprzedazy, @ZyskOperacyjny, @ZyskZDzialalnosciGospodarczej, @ZyskPrzedOpodatkowaniem, @ZyskNetto, @ZyskNettoAkcjonariuszyJednostkiDominujacej, @EBITDA)";

                for (int i = 0; i < FinancialRaportsList.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                    
                        command.Parameters.AddWithValue("@CompanyName", FinancialRaportsList[i].ComapanyName);
                        command.Parameters.AddWithValue("@RaportYear", FinancialRaportsList[i].RaportYear);
                        command.Parameters.AddWithValue("@PrzychodyZeSprzedazy", FinancialRaportsList[i].ProfitAndLose.PrzychodyZeSprzedazy);
                        command.Parameters.AddWithValue("@ZyskZeSprzedazy", FinancialRaportsList[i].ProfitAndLose.ZyskZeSprzedazy);
                        command.Parameters.AddWithValue("@ZyskOperacyjny", FinancialRaportsList[i].ProfitAndLose.ZyskOperacyjny);
                        command.Parameters.AddWithValue("@ZyskZDzialalnosciGospodarczej", FinancialRaportsList[i].ProfitAndLose.ZyskZDzialalnosciGospodarczej);
                        command.Parameters.AddWithValue("@ZyskPrzedOpodatkowaniem", FinancialRaportsList[i].ProfitAndLose.ZyskPrzedOpodatkowaniem);
                        command.Parameters.AddWithValue("@ZyskNetto", FinancialRaportsList[i].ProfitAndLose.ZyskNetto);
                        command.Parameters.AddWithValue("@ZyskNettoAkcjonariuszyJednostkiDominujacej", FinancialRaportsList[i].ProfitAndLose.ZyskNettoAkcjonariuszyJednostkiDominujacej);
                        command.Parameters.AddWithValue("@EBITDA", FinancialRaportsList[i].ProfitAndLose.EBITDA);

                        connection.Open();
                        
                        int result = command.ExecuteNonQuery();
                        connection.Close();
                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        if (result == 1 )
                        {
                            Console.WriteLine("Sql Upload complete!");
                        }
                    }
                }
            }
        }

    }
}

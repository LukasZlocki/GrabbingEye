using GrabbingEye.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.ModelsSql
{
    class SqlAdapterFinanceProfitAndLose
    {
        #region def of static connection server parameters 
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=PolishStocks;Integrated Security=True";
        #endregion

        // PUSH - financial balance data on server
        public void PushFinanceProfitAndLoseRaport(List<FinanceProfitAndLose> ProfitAndLoseRaportList)
        {
            // code pushing data here
            using (SqlConnection connection = new SqlConnection(SERVER_CONFIG))
            {
                // ToDo : add database ProfitAndLoseData to Sql
                String query = "INSERT INTO dbo.ProfitAndLoseData (CompanyName,RaportYear,PrzychodyZeSprzedazy,ZyskZeSprzedazy,ZyskOperacyjny,ZyskZDzialalnosciGospodarczej,ZyskPrzedOpodatkowaniem,ZyskNetto,ZyskNettoAkcjonariuszyJednostkiDominujacej,EBITDA) "
                    + "VALUES "
                    + "(@CompanyName, @RaportYear, @PrzychodyZeSprzedazy, @ZyskZeSprzedazy, @ZyskOperacyjny, @ZyskZDzialalnosciGospodarczej, @ZyskPrzedOpodatkowaniem, @ZyskNetto, @ZyskNettoAkcjonariuszyJednostkiDominujacej, @EBITDA)";

                for (int i = 0; i < ProfitAndLoseRaportList.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", ProfitAndLoseRaportList[i].ComapanyName);
                        command.Parameters.AddWithValue("@RaportYear", ProfitAndLoseRaportList[i].RaportYear);
                        command.Parameters.AddWithValue("@PrzychodyZeSprzedazy", ProfitAndLoseRaportList[i].PrzychodyZeSprzedazy);
                        command.Parameters.AddWithValue("@ZyskZeSprzedazy", ProfitAndLoseRaportList[i].ZyskZeSprzedazy);
                        command.Parameters.AddWithValue("@ZyskOperacyjny", ProfitAndLoseRaportList[i].ZyskOperacyjny);
                        command.Parameters.AddWithValue("@ZyskZDzialalnosciGospodarczej", ProfitAndLoseRaportList[i].ZyskZDzialalnosciGospodarczej);
                        command.Parameters.AddWithValue("@ZyskPrzedOpodatkowaniem", ProfitAndLoseRaportList[i].ZyskPrzedOpodatkowaniem);
                        command.Parameters.AddWithValue("@ZyskNetto", ProfitAndLoseRaportList[i].ZyskNetto);
                        command.Parameters.AddWithValue("@ZyskNettoAkcjonariuszyJednostkiDominujacej", ProfitAndLoseRaportList[i].ZyskNettoAkcjonariuszyJednostkiDominujacej);
                        command.Parameters.AddWithValue("@EBITDA", ProfitAndLoseRaportList[i].EBITDA);

                        connection.Open();

                        int result = command.ExecuteNonQuery();
                        connection.Close();
                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        if (result == 1)
                        {
                            Console.WriteLine("Sql Upload complete!");
                        }
                    }
                }

            }
        }

    }
}

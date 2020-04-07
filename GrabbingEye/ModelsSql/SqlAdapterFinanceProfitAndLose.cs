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
        public void PushFinanceProfitAndLoseRaport(List<FinancialRaport> RaportList)
        {
            // code pushing data here
            using (SqlConnection connection = new SqlConnection(SERVER_CONFIG))
            {
                // ToDo : add database ProfitAndLoseData to Sql
                String query = "INSERT INTO dbo.ProfitAndLoseData (CompanyName,RaportYear,PrzychodyZeSprzedazy,ZyskZeSprzedazy,ZyskOperacyjny,ZyskZDzialalnosciGospodarczej,ZyskPrzedOpodatkowaniem,ZyskNetto,ZyskNettoAkcjonariuszyJednostkiDominujacej,EBITDA) "
                    + "VALUES "
                    + "(@CompanyName, @RaportYear, @PrzychodyZeSprzedazy, @ZyskZeSprzedazy, @ZyskOperacyjny, @ZyskZDzialalnosciGospodarczej, @ZyskPrzedOpodatkowaniem, @ZyskNetto, @ZyskNettoAkcjonariuszyJednostkiDominujacej, @EBITDA)";

                for (int i = 0; i < RaportList.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", RaportList[i].ProfitAndLose.ComapanyName);
                        command.Parameters.AddWithValue("@RaportYear", RaportList[i].ProfitAndLose.RaportYear);
                        command.Parameters.AddWithValue("@PrzychodyZeSprzedazy", RaportList[i].ProfitAndLose.PrzychodyZeSprzedazy);
                        command.Parameters.AddWithValue("@ZyskZeSprzedazy", RaportList[i].ProfitAndLose.ZyskZeSprzedazy);
                        command.Parameters.AddWithValue("@ZyskOperacyjny", RaportList[i].ProfitAndLose.ZyskOperacyjny);
                        command.Parameters.AddWithValue("@ZyskZDzialalnosciGospodarczej", RaportList[i].ProfitAndLose.ZyskZDzialalnosciGospodarczej);
                        command.Parameters.AddWithValue("@ZyskPrzedOpodatkowaniem", RaportList[i].ProfitAndLose.ZyskPrzedOpodatkowaniem);
                        command.Parameters.AddWithValue("@ZyskNetto", RaportList[i].ProfitAndLose.ZyskNetto);
                        command.Parameters.AddWithValue("@ZyskNettoAkcjonariuszyJednostkiDominujacej", RaportList[i].ProfitAndLose.ZyskNettoAkcjonariuszyJednostkiDominujacej);
                        command.Parameters.AddWithValue("@EBITDA", RaportList[i].ProfitAndLose.EBITDA);

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

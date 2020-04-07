using GrabbingEye.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.ModelsSql
{
    class SqlAdapterFinanceBalance 
    {
        #region def of static connection server parameters 
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=PolishStocks;Integrated Security=True";
        #endregion

        // PUSH - financial balance data on server
        public void PushFinanceBalanceRaport(List<FinanceBalance> BalanceRaportList)
        {
            // code pushing data here
            using (SqlConnection connection = new SqlConnection(SERVER_CONFIG))
            {
                // ToDo : add database ProfitAndLoseData to Sql
                String query = "INSERT INTO dbo.BalanceData (CompanyName,RaportYear,AktywaTrwale,AktywaObrotowe,AktywaRazem,KapitalWlasnyAkcjonariuszyJednostkiDominujacej,UdzialyNiekontrolujace,ZobowiazaniaDlugoterminowe,ZobowiazaniaKrotkoterminowe,PasywaRazem) "
                    + "VALUES "
                    + "(@CompanyName, @RaportYear, @AktywaTrwale, @AktywaObrotowe, @AktywaRazem, @KapitalWlasnyAkcjonariuszyJednostkiDominujacej, @UdzialyNiekontrolujace, @ZobowiazaniaDlugoterminowe, @ZobowiazaniaKrotkoterminowe, @PasywaRazem)";

                for (int i = 0; i < BalanceRaportList.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", BalanceRaportList[i].ComapanyName);
                        command.Parameters.AddWithValue("@RaportYear", BalanceRaportList[i].RaportYear);
                        command.Parameters.AddWithValue("@AktywaTrwaley", BalanceRaportList[i].AktywaTrwale);
                        command.Parameters.AddWithValue("@AktywaObrotowe", BalanceRaportList[i].AktywaObrotowe);
                        command.Parameters.AddWithValue("@AktywaRazem", BalanceRaportList[i].AktywaRazem);
                        command.Parameters.AddWithValue("@KapitalWlasnyAkcjonariuszyJednostkiDominujacej", BalanceRaportList[i].KapitalWlasnyAkcjonariuszyJednostkiDominujacej);
                        command.Parameters.AddWithValue("@UdzialyNiekontrolujace", BalanceRaportList[i].UdzialyNiekontrolujace);
                        command.Parameters.AddWithValue("@ZobowiazaniaDlugoterminowe", BalanceRaportList[i].ZobowiazaniaDlugoterminowe);
                        command.Parameters.AddWithValue("@ZobowiazaniaKrotkoterminowe", BalanceRaportList[i].ZobowiazaniaKrotkoterminowe);
                        command.Parameters.AddWithValue("@PasywaRazem", BalanceRaportList[i].PasywaRazem);

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



        // GET - Operation raport



        // GET - Balance Financial Raport 
        public void GetFinanceBalanceRaport()
        {
            // code gettting data here
        }

    }
}

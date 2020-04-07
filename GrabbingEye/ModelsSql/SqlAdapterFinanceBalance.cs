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
        public void PushFinanceBalanceRaport(List<FinancialRaport> RaportList)
        {
            // code pushing data here
            using (SqlConnection connection = new SqlConnection(SERVER_CONFIG))
            {
                // ToDo : add database ProfitAndLoseData to Sql
                String query = "INSERT INTO dbo.BalanceData (CompanyName,RaportYear,AktywaTrwale,AktywaObrotowe,AktywaRazem,KapitalWlasnyAkcjonariuszyJednostkiDominujacej,UdzialyNiekontrolujace,ZobowiazaniaDlugoterminowe,ZobowiazaniaKrotkoterminowe,PasywaRazem) "
                    + "VALUES "
                    + "(@CompanyName, @RaportYear, @AktywaTrwale, @AktywaObrotowe, @AktywaRazem, @KapitalWlasnyAkcjonariuszyJednostkiDominujacej, @UdzialyNiekontrolujace, @ZobowiazaniaDlugoterminowe, @ZobowiazaniaKrotkoterminowe, @PasywaRazem)";

                for (int i = 0; i < RaportList.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", RaportList[i].Balance.ComapanyName);
                        command.Parameters.AddWithValue("@RaportYear", RaportList[i].Balance.RaportYear);
                        command.Parameters.AddWithValue("@AktywaTrwaley", RaportList[i].Balance.AktywaTrwale);
                        command.Parameters.AddWithValue("@AktywaObrotowe", RaportList[i].Balance.AktywaObrotowe);
                        command.Parameters.AddWithValue("@AktywaRazem", RaportList[i].Balance.AktywaRazem);
                        command.Parameters.AddWithValue("@KapitalWlasnyAkcjonariuszyJednostkiDominujacej", RaportList[i].Balance.KapitalWlasnyAkcjonariuszyJednostkiDominujacej);
                        command.Parameters.AddWithValue("@UdzialyNiekontrolujace", RaportList[i].Balance.UdzialyNiekontrolujace);
                        command.Parameters.AddWithValue("@ZobowiazaniaDlugoterminowe", RaportList[i].Balance.ZobowiazaniaDlugoterminowe);
                        command.Parameters.AddWithValue("@ZobowiazaniaKrotkoterminowe", RaportList[i].Balance.ZobowiazaniaKrotkoterminowe);
                        command.Parameters.AddWithValue("@PasywaRazem", RaportList[i].Balance.PasywaRazem);

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

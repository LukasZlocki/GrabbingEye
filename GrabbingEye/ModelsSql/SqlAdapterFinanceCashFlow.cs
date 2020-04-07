using GrabbingEye.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.ModelsSql
{
    class SqlAdapterFinanceCashFlow
    {
        #region def of static connection server parameters 
        static string SERVER_CONFIG = "Data Source=DESKTOP-4AAFF58\\SQLEXPRESS;Initial Catalog=PolishStocks;Integrated Security=True";
        #endregion

        // PUSH - financial balance data on server
        public void PushFinanceCashFlowRaport(List<FinanceCashFlow> CashFlowRaportList)
        {
            // code pushing data here
            using (SqlConnection connection = new SqlConnection(SERVER_CONFIG))
            {
                // ToDo : add database ProfitAndLoseData to Sql
                String query = "INSERT INTO dbo.CashFlowData (CompanyName,RaportYear, PrzeplywyZDzialalnosciOperacyjnej, PrzeplywyZDzialalnosciInvestycyjnej, PrzeplywyZDzialalnosciFinansowej, PrzeplywyRazem) "
                    + "VALUES "
                    + "(@CompanyName, @RaportYear, @PrzeplywyZDzialalnosciOperacyjnej, @PrzeplywyZDzialalnosciInvestycyjnej, @PrzeplywyZDzialalnosciFinansowej, @PrzeplywyRazem)";

                for (int i = 0; i < CashFlowRaportList.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", CashFlowRaportList[i].ComapanyName);
                        command.Parameters.AddWithValue("@RaportYear", CashFlowRaportList[i].RaportYear);
                        command.Parameters.AddWithValue("@PrzeplywyZDzialalnosciOperacyjnej", CashFlowRaportList[i].PrzeplywyZDzialalnosciOperacyjnej);
                        command.Parameters.AddWithValue("@PrzeplywyZDzialalnosciInvestycyjnej", CashFlowRaportList[i].PrzeplywyZDzialalnosciInvestycyjnej);
                        command.Parameters.AddWithValue("@PrzeplywyZDzialalnosciFinansowej", CashFlowRaportList[i].PrzeplywyZDzialalnosciFinansowej);
                        command.Parameters.AddWithValue("@PrzeplywyRazem", CashFlowRaportList[i].PrzeplywyRazem);

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

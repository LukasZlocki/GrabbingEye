using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class DataSnifferBiznesradar
    {
        private string Url = @"https://www.biznesradar.pl/raporty-finansowe-rachunek-zyskow-i-strat/WIELTON";
        private string HtmlExtracted = "";

        private string FullRaportStringFormat = "";

        YearlyFinancialRaportFull FullRaport = new YearlyFinancialRaportFull();

        public DataSnifferBiznesradar(string StockName, int RaportByYear)
        {
            int _raportTablePossition = 0;
            int _raportTableLenght = 0;
            GetTablePossitionAndLenght(Url, RaportByYear, ref _raportTablePossition, ref _raportTableLenght);
            SniffForRaport(Url, RaportByYear, _raportTablePossition, ref FullRaport );
            ConvertFinancialRaportToString(FullRaport, ref FullRaportStringFormat);
        }

        /// <summary>
        /// Checking table possition of raport for given year
        /// </summary>
        /// <param name="url">web url</param>
        /// <param name="raportYear">Year of raport user is looking for</param>
        /// <param name="raportTablePossition"> ref to count possition of raport in table at web</param>
        private static void GetTablePossitionAndLenght(string url,int raportYear, ref int raportTablePossition, ref int raportTableLenght)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//th[contains(@class, 'thq h')]");

            int i = 0;
            int _count = 0; 
            raportTablePossition = 0;
            

            string convertedString = "";

            foreach (var extracted in extractedData)
            {
                StringConverter stringConvert = new StringConverter();
                convertedString = stringConvert.RepleaceString(extracted.InnerText, "\t");
                convertedString = stringConvert.RepleaceString(convertedString, "\n");
                try
                {
                    i = Convert.ToInt32(convertedString);
                    Console.WriteLine("" + i);
                    _count++;
                    if (raportYear == i) 
                    { 
                        raportTablePossition = _count; 
                    }
                }
                catch
                {
                    Console.WriteLine("Error !");
                }
                raportTableLenght++;
            }
        }

        private static void SniffForRaport(string url, int raportYear, int raportTablePossition, ref YearlyFinancialRaportFull fullRaport)
        {
            // ToDo : code sniffing raport here
        }

        private void ConvertFinancialRaportToString(YearlyFinancialRaportFull financialRaport, ref string finacialRaportAsString)
        {
            // ToDo : Code to Convert  Raport to string
        }

        

        

    }
}

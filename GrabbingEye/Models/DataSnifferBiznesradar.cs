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
        string Url = @"https://www.biznesradar.pl/raporty-finansowe-rachunek-zyskow-i-strat/WIELTON";
        string HtmlExtracted = "";

        private int RaportTablePossition = 0; 


        public DataSnifferBiznesradar(string StockName, int RaportByYear)
        {
            // ToDo : Code to find RaportTablePossition
            GetTablePossition(Url, RaportByYear, ref RaportTablePossition);
                // ToDo : Extract Data on RaportTable Possition 
        }

        private static void GetTablePossition(string url,int raportYear, ref int raportTablePossition)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//th[contains(@class, 'thq h')]");

            int i = 0;
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
                    if (raportYear == i) { raportTablePossition = i; }
                }
                catch
                {
                    Console.WriteLine("Error !");
                }
            }
        }


    }
}

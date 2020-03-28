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
        private static string URL_ZYSKI_STRATY = @"https://www.biznesradar.pl/raporty-finansowe-rachunek-zyskow-i-strat/WIELTON";
        private static string URL_BILANS = @"https://www.biznesradar.pl/raporty-finansowe-bilans/WIELTON";
      
        RaportConverter ConvertedRaport;

        // Constructor
        public DataSnifferBiznesradar(string StockName, int RaportByYear)
        {
            int _raportTablePossition = 0;
            int _raportTableLenght = 0;

            // list with all yearly finanancial data
            List<int> _dataList = new List<int>();

            GetTablePossitionAndLenght(URL_ZYSKI_STRATY, RaportByYear, ref _raportTablePossition, ref _raportTableLenght);
            SniffForRaport(URL_ZYSKI_STRATY, _raportTablePossition,_raportTableLenght, ref _dataList);
            SniffForRaport(URL_BILANS, _raportTablePossition, _raportTableLenght, ref _dataList);
            ConvertRaportToClassAndString(_dataList, ref ConvertedRaport);           
        }

        /// <summary>
        /// Checking table possition and lenght of raport 
        /// </summary>
        /// <param name="url">web url</param>
        /// <param name="raportYear">Year of raport user is looking for</param>
        /// <param name="raportTablePossition"> ref to count possition of raport in table at web</param>
        /// <param name="raportTableLenght"> ref to count length of raport in table at web</param>
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

        /// <summary>
        /// Grabing data from web
        /// </summary>
        /// <param name="url">web url</param>
        /// <param name="raportTablePossition">possition in table on web</param>
        /// <param name="raportTableLenght">lenght of raport</param>
        /// <param name="dataList">ref to list with grabbed data</param>
        private static void SniffForRaport(string url, int raportTablePossition, int raportTableLenght, ref List<int> dataList)
        {
            int _loopCounter = 1;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@class, 'bold')]/td/span");


            foreach (var extracted in extractedData)
            {
                Console.WriteLine("" + extracted.InnerText);

                // save data when correct year possition in table
                if (_loopCounter == raportTablePossition)
                {
                    string _convertedString = "";
                    int _dataConverted; 

                    StringConverter stringConvert = new StringConverter();
                    _convertedString = stringConvert.RepleaceString(extracted.InnerText, " ");
                    _dataConverted = Convert.ToInt32(_convertedString);

                    dataList.Add(_dataConverted);
                }

                //reset row counting
                if (_loopCounter == raportTableLenght)
                {
                    _loopCounter = 0;
                }
                _loopCounter++;
            }
        }

        /// <summary>
        /// Converting raport to string and class object - see RaportConverter class 
        /// </summary>
        /// <param name="dataList">list with grabbed data</param>
        /// <param name="convertedRaport">ref to class that converts raport to string and class</param>
        private void ConvertRaportToClassAndString(List<int> dataList, ref RaportConverter convertedRaport)
        {
            convertedRaport = new RaportConverter(dataList);
        }


        #region GET

        // GET - Raport
        public string GetFullYearlyRaportAsString()
        {
            return (this.ConvertedRaport.GetFinancialRaportAsString());
        }

        public YearlyFinancialRaportFull GetFullYearRaportAsClass()
        {
            return (this.ConvertedRaport.GetFinancialRaportAsClass());
        }

        #endregion

    }
}

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GrabbingEye.Models
{
    class DataSnifferBiznesradar
    {
        private static string URL_ZYSKI_STRATY = @"https://www.biznesradar.pl/raporty-finansowe-rachunek-zyskow-i-strat/";
        private static string URL_BILANS = @"https://www.biznesradar.pl/raporty-finansowe-bilans/";
        private static string URL_CASH_FLOW = @"https://www.biznesradar.pl/raporty-finansowe-przeplywy-pieniezne/";

        RaportConverter ConvertedRaport;


        // construstor - one search only
        public DataSnifferBiznesradar(string StockName, int RaportByYear)
        {
            // dummy id !
            int Id = 0;

            int _raportTablePossition = -1;
            int _raportTableLenght = -1;

            string _StockName = StockName.ToUpper();


            // list with all yearly finanancial data
            List<int> _dataList = new List<int>();

            GetTablePossitionAndLenght(URL_ZYSKI_STRATY + "" + _StockName, RaportByYear, ref _raportTablePossition, ref _raportTableLenght);

            SniffForRaport(URL_ZYSKI_STRATY + "" + _StockName, _raportTablePossition, _raportTableLenght, ref _dataList);
            SniffForRaport(URL_BILANS + "" + _StockName, _raportTablePossition, _raportTableLenght, ref _dataList);
            SniffForRaport(URL_CASH_FLOW + "" + _StockName, _raportTablePossition, _raportTableLenght, ref _dataList);

            if (_dataList.Count > 0)
            {
                ConvertRaportToClassAndString(Id, StockName, RaportByYear, _dataList, ref ConvertedRaport);
            }
            else
            {
              //  MessageBox.Show("Brak danych");
            }
        }



        /// <summary>
        /// Checking table possition and lenght of raport 
        /// </summary>
        /// <param name="url">web url</param>
        /// <param name="raportYear">Year of raport user is looking for</param>
        /// <param name="raportTablePossition"> ref to count possition of raport in table at web</param>
        /// <param name="raportTableLenght"> ref to count length of raport in table at web</param>
        private static void GetTablePossitionAndLenght(string url, int raportYear, ref int raportTablePossition, ref int raportTableLenght)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//th[contains(@class, 'thq h')]");

            int i = 0;
            int _count = 0;
            raportTablePossition = 0;


            string convertedString = "";
            try
            {
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
            catch
            {
             //   MessageBox.Show("Nie ma takiej spolki");
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

            try
            {
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
            catch
            {
              //  MessageBox.Show("Brak danych dla tej spolki");
            }
        }

        /// <summary>
        /// Converting raport to string and class object - see RaportConverter class 
        /// </summary>
        /// <param name="dataList">list with grabbed data</param>
        /// <param name="convertedRaport">ref to class that converts raport to string and class</param>
        private void ConvertRaportToClassAndString(int Id, string stockName, int raportYear,  List<int> dataList, ref RaportConverter convertedRaport)
        {
            convertedRaport = new RaportConverter(Id, stockName, raportYear, dataList);
        }


        #region GET

        // GET - Raport
        public string GetFullYearlyRaportAsString()
        {
            try
            {
                return (this.ConvertedRaport.GetFinancialRaportAsString());
            }
            catch
            {
              //  MessageBox.Show("Brak danych - nie przesylam raportu string");
            }
            return ("");
        }

        public FinancialRaport GetFullYearRaportAsClass()
        {
            FinancialRaport raport = new FinancialRaport();

            try
            {
                return (this.ConvertedRaport.GetFinancialRaportAsClass());
            }
            catch
            {
             //   MessageBox.Show("Brak danych - nie przesylam raportu do listy");
            }
            return (raport = null);
        }

        #endregion

    }
}

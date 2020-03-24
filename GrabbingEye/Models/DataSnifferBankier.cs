using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HtmlAgilityPack;

using GrabbingEye.Models;




namespace GrabbingEye.Models
{
    class DataSnifferBankier
    {
        static string URL_1 = "https://www.bankier.pl/gielda/notowania/akcje/";
        static string URL_2 = "/wyniki-finansowe/skonsolidowany/roczny/standardowy/";

        YearlyFinancialRaportStandard FinancialRaport = new YearlyFinancialRaportStandard();

        int RaportPage = 0;
        int RaportTablePossition = 0;
        int RaportTablePossitionsOnWeb = 0;




        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="stockName">Name of stock</param>
        /// <param name="yearRaport">Year of report to find</param>
        public DataSnifferBankier(string stockName, int yearRaport)
        {
            RaportParameters raportParameters = new RaportParameters();

            FinancialRaport.Name = stockName;
            FinancialRaport.Year = yearRaport;

            FindPageWithYearAndPossitionInTable(yearRaport, stockName, ref raportParameters);

            if (raportParameters.RaportPage != 0)
            {
                // data found :) Extracting raport from table
                ExtractRaport(stockName, raportParameters, ref FinancialRaport);
            }
            else
            {
                MessageBox.Show("No data found");
            }
        }

        /// <summary>
        /// Method for finding Web page and column with raport data for given year and stock name
        /// </summary>
        /// <param name="year">Year of raport which user is looking for</param>
        /// <param name="stock">Stock Name</param>
        /// <param name="raportPage">Information will be given at which page is raport</param>
        /// <param name="raportTablePossition">Information will be set in what table is data which user is looking for</param>
        /// <returns></returns>
        private void FindPageWithYearAndPossitionInTable(int year, string stock, ref RaportParameters raportParams)
        {
            // Todo : [Test IT] !  code finding page and table possition for financial raport

            bool pageIsFound = false;
            int _lastTableQuantity = 0;

            #region Extracting Page and year
            for (int webP = 1; webP < 8; webP++)
            {
                // Generating proper URL
                string Url = @"" + URL_1 + stock + URL_2 + webP;

                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(Url);

                var htmlBody = htmlDoc.DocumentNode.SelectNodes("//th[contains(@class, 'textAlignCenter')]");

                try
                {
                    PassingQuantityOfTables(ref raportParams, _lastTableQuantity, pageIsFound);

                    int _wwwTableCount = 0; // table possition counter
                    pageIsFound = false;

                    foreach (var dane in htmlBody)
                    {
                        _lastTableQuantity = _wwwTableCount; // for calculating of tables on web purpose
                        int _readYear = Convert.ToInt32(dane.InnerText);

                        if (_readYear == year)
                        {
                            raportParams.RaportTablePossition = _wwwTableCount; // ! Table possition found
                            raportParams.RaportPage = webP;  // ! Web page found
                            pageIsFound = true;
                        }
                        _wwwTableCount++;
                    }
                }
                catch
                {
                    //  MessageBox.Show("nie ma takiej spolki");
                }
            }
            #endregion
        }

        /// <summary>
        /// saving tables quantities which are on page where financial raport is
        /// </summary>
        /// <param name="raportParams">object with parameters of raport</param>
        /// <param name="tableQuantity">how many tables are on web with search raport</param>
        /// <param name="pageIsFound">bool if page is found and tables quantity need to be evaluated</param>
        private void PassingQuantityOfTables(ref RaportParameters raportParams, int tableQuantity, bool pageIsFound)
        {
            if (pageIsFound == true)
            {
                raportParams.HowManyTablesOnPage = tableQuantity;
            }
        }

        /// <summary>
        /// Extracting raport from web page.
        /// </summary>
        /// <param name="stockName">stock name</param>
        /// <param name="wwwPageNb">web page number where proper raport exist</param>
        /// <param name="wwwTablePossition">table possition where proper dasta for raport exist</param>
        /// <param name="financialRaport">reference object to put financial data</param>
        private void ExtractRaport(string stockName, RaportParameters raportParams, ref YearlyFinancialRaportStandard financialRaport)
        {
            // ToDo : [to check] Extract raport basis on page and position in table. Raport import to object financialRaport

            string Url = @"" + URL_1 + stockName + URL_2 + raportParams.RaportPage;
            int _counter = 0;
            int _objectPossitionData = 2; // start from second possition excluding year

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(Url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//td[contains(@class, 'textAlignRight')]");

            Console.WriteLine("Extrakcja danych z tabeli finansowej");

            try
            {
                foreach (var daneFin in extractedData)
                {

                    if (_counter == raportParams.RaportTablePossition && _objectPossitionData != 13) // possition 13 - table with raport check (string) which I do not need
                    {
                        string _trimmedString = "";

                        StringTrimmer stringTrimmer = new StringTrimmer();
                        _trimmedString = stringTrimmer.StringTrimm(daneFin.InnerText);

                        // adding data to raport object
                        financialRaport.SetDataForFinancialRaport(_trimmedString, _objectPossitionData);
                        _objectPossitionData++;
                    }
                    _counter++;
                    if (_counter == raportParams.HowManyTablesOnPage + 1) { _counter = 0; }

                }
            }
            catch
            {
                MessageBox.Show("brak danych");
            }
        }

        #region GET financial raport
        public YearlyFinancialRaportStandard GetFinancialRaport()
        {
            return (FinancialRaport);
        }
        #endregion





    }
}

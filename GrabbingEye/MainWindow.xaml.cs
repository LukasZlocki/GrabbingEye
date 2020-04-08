using GrabbingEye.Models;
using GrabbingEye.ModelsSql;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace GrabbingEye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PolishCompany> ListOfPolishCompanies = new List<PolishCompany>();
        List<FinancialRaport> ListOfYearlyRaports = new List<FinancialRaport>();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons

        // SEND - data to Sql
        private void btnExportData_Click(object sender, RoutedEventArgs e)
        {
            // ToDo : code connection here
            SqlAdapter SqlAdapter = new SqlAdapter();
            SqlAdapter.SaveFinancialDataOnSqlServer(ListOfYearlyRaports);
        }

        // GET financial raport basis on _stockName and _raportYear and www
        private void btnextract_Click(object sender, RoutedEventArgs e)
        {
            string _raportAsString = "";

            string _stockName = txtStockName.Text;
            int _raportYear = Convert.ToInt32(txtRaportYear.Text);

            DataSnifferBiznesradar finansialRaportBiznesradar = new DataSnifferBiznesradar(_stockName, _raportYear);
            try
            {
                _raportAsString = finansialRaportBiznesradar.GetFullYearlyRaportAsString();
                ShowRaportOnScreen(_raportAsString);
            }
            catch
            {
                MessageBox.Show("Brak raportu");
            }

        }

        // GET all companies from Sql and store them in StockPolishcompany list
        private void btGetAllCompaniesFromSql_Click(object sender, RoutedEventArgs e)
        {
            SqlAdapter SqlAdapt = new SqlAdapter();
            ListOfPolishCompanies = SqlAdapt.GetCompaniesList();
            ShowRaportOnScreen(SqlAdapt.GetRaport());

        }

        // GET - data from biznesradar web
        private void btnGrabData_Click(object sender, RoutedEventArgs e)
        {
            int _year = Convert.ToInt32(txtDownloadYear.Text);
            MassiveDataGrabing(ListOfPolishCompanies, ref ListOfYearlyRaports, _year);
        }

        #region Massive Grabbing

        private void MassiveDataGrabing(List<PolishCompany> listOfPolishCompanies, ref List<FinancialRaport> listOfYearlyFinancialRaports, int year)
        {
            int _counterOK = 0;
            int _counterALL = 0;

            // ToDo : code loops to gather data
            //   for (int i = 0; i < listOfPolishCompanies.Count; i++)
            for (int j = 2000; j < 2009; j++)
            {
                // to skasowac
                year = j;
                for (int i = 0; i < 5; i++)
                {
                    DataSnifferBiznesradar sniff = new DataSnifferBiznesradar(listOfPolishCompanies[i].Name, year);

                    // check if dat exist before inserting to list
                    if (!(sniff.GetFullYearRaportAsClass() == null))
                    {
                        if (isGrabberReady(listOfPolishCompanies[i].Name))
                        {
                            listOfYearlyFinancialRaports.Add(sniff.GetFullYearRaportAsClass());
                            _counterOK++;
                            Thread.Sleep(3000);
                        }

                    }
                    else
                    {
                     //   MessageBox.Show("Brak raportu na stonie WWWW");
                    }
                    _counterALL++;
                }
                ShowRaportOnScreen("ALL : " + _counterALL + ", OK : " + _counterOK + " Rok : " + j);
            }
        }

        /// <summary>
        /// check if grabber is ready to grab data from web / Banks are not ready ! 
        /// </summary>
        /// <param name="company">company name to check</param>
        /// <returns>bool, true if ready</returns>
        private bool isGrabberReady(string company)
        {
            bool _isready = true;
            switch (company)
            {
                case "PEKAO":
                    _isready = false;
                    break;
                case "ALIOR":
                    _isready = false;
                    break;
                case "MBANK":
                    _isready = false;
                    break;
                case "PKOBP":
                    _isready = false;
                    break;
                case "SANPL":
                    _isready = false;
                    break;
                case "BNPPPL":
                    _isready = false;
                    break;
                case "GETIN":
                    _isready = false;
                    break;
                case "HANDLOWY":
                    _isready = false;
                    break;
                case "INGBSK":
                    _isready = false;
                    break;
                case "MILLENNIUM":
                    _isready = false;
                    break;
                case "BOS":
                    _isready = false;
                    break;
                case "IDEABANK":
                    _isready = false;
                    break;
                case "COMARCH":
                    _isready = false;
                    break;
                case "LIVECHAT":
                    _isready = false;
                    break;
                case "ALUMETAL":
                    _isready = false;
                    break;
                case "PBKM":
                    _isready = false;
                    break;
                case "R22":
                    _isready = false;
                    break;
            }
            return (_isready);
        }

        #endregion

        #endregion

        #region Radio buttons
        private void RbBiznesradar_Checked(object sender, RoutedEventArgs e)
        {
            RbBiznesradar.IsChecked = true;
        }
        #endregion

        #region Show Data on screen

        // SHOW - financial raport from string
        private void ShowRaportOnScreen(string raport)
        {
            txtBox.Text = "" + raport;
        }


        #endregion

    }
}

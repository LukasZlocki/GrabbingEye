using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using HtmlAgilityPack;

using GrabbingEye.Models;
using GrabbingEye.ModelsSql;

namespace GrabbingEye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        YearlyFinancialRaportFull finansialRaportFull = new YearlyFinancialRaportFull();
        YearlyFinancialRaportStandard finansialRaport = new YearlyFinancialRaportStandard();
        PolishCompany stocksPolishCompany = new PolishCompany();

        List<PolishCompany> ListOfPolishCompanies = new List<PolishCompany>();
        List<YearlyFinancialRaportFull> ListOfYearlyRaports = new List<YearlyFinancialRaportFull>();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons

        // GET financial raport basis on _stockName and _raportYear and www
        private void btnextract_Click(object sender, RoutedEventArgs e)
        {
            string _raportAsString = "";

            string _stockName = txtStockName.Text;
            int _raportYear = Convert.ToInt32(txtRaportYear.Text);

            if (RbBankier.IsChecked == true)
            {
                DataSnifferBankier financialRaportBankier = new DataSnifferBankier(_stockName, _raportYear);
                finansialRaport = financialRaportBankier.GetFinancialRaport();
            }
            else
            {
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
        }

        // GET all companies from Sql and store them in StockPolishcompany list
        private void btGetAllCompaniesFromSql_Click(object sender, RoutedEventArgs e)
        {
            ModelsSql.SqlAdapter SqlAdapt = new ModelsSql.SqlAdapter();
            ShowRaportOnScreen(SqlAdapt.GetRaport());
            ListOfPolishCompanies = SqlAdapt.GetListOfCompanies();
        }

        // GET - data from biznesradar web
        private void btnGrabData_Click(object sender, RoutedEventArgs e)
        {
            int _year = Convert.ToInt32(txtDownloadYear.Text);
            MassiveDataGrabing(ListOfPolishCompanies, ref ListOfYearlyRaports, _year);
        }

        #region Massive Grabbing

        private void MassiveDataGrabing(List<PolishCompany> listOfPolishCompanies, ref List<YearlyFinancialRaportFull> listOfYearlyFinancialRaports, int year)
        {
            int _counterOK = 0;
            int _counterALL = 0;

            // ToDo : code loops to gather data
            for (int i = 0; i < listOfPolishCompanies.Count; i++)
            {
                if (isGrabberReady(listOfPolishCompanies[i].Name)) {
                    DataSnifferBiznesradar sniff = new DataSnifferBiznesradar(listOfPolishCompanies[i].Name, year);
                    listOfYearlyFinancialRaports.Add(sniff.GetFullYearRaportAsClass());
                    _counterOK++;
                } else
                {
                    // Do nothing
                }
                _counterALL++;
            }
            ShowRaportOnScreen("ALL : " + _counterALL + ", OK : " + _counterOK );
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
                case "COMARCH":
                    _isready = false;
                    break;
            }
            return (_isready);
        }

        #endregion

        #region Radio buttons
        private void RbBankier_Checked(object sender, RoutedEventArgs e)
        {
            RbBankier.IsChecked = true;
            RbBiznesradar.IsChecked = false;
        }

        private void RbBiznesradar_Checked(object sender, RoutedEventArgs e)
        {
            RbBankier.IsChecked = false;
            RbBiznesradar.IsChecked = true;
        }
        #endregion

        #endregion

        #region Show Data on screen

        // SHOW - financial raport from string
        private void ShowRaportOnScreen(string raport)
        {
            txtBox.Text = "" + raport;
        }


        // SHOW - financial Raport
        private void ShowFinancialRaportOnScreen(YearlyFinancialRaportStandard raport)
        {

            txtBox.Text =
                "Nazwa spolki : " + finansialRaport.Name + " \n " +
                "Rok Raportu : " + finansialRaport.Year + " \n " +
                "Przychody netto ze sprzedazy : " + finansialRaport.PrzychodyNettoZeSprzedazy + " \n " +
                "Zyski z dzialalnosci operacyjnej : " + finansialRaport.ZyskDzialalnosciOperacyjnej + " \n " +
                "Zysk brutto : " + finansialRaport.ZyskBrutto + " \n " +
                "Zysk netto : " + finansialRaport.ZyskNetto + " \n " +
                "Amortyzacja : " + finansialRaport.Amortyzacja + " \n " +
                "Ebitda : " + finansialRaport.Ebitda + " \n " +
                "Aktywa : " + finansialRaport.Aktywa + " \n " +
                "Kapital wlasny : " + finansialRaport.KapitalWlasny + " \n " +
                "Liczba Akcji : " + finansialRaport.LiczbaAkcji + " \n " +
                "Zysk na akcje : " + finansialRaport.ZyskNaAkcje + " \n " +
                "Wartosc ksiegowa na akcje : " + finansialRaport.WartoscKsiegowaNaAkcje + " \n ";

        }


        #endregion


    }
}

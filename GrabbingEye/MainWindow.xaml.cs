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
        StocksPolishCompany stocksPolishCompany = new StocksPolishCompany();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons

        // GET financial raport basis on _stockName and _raportYear and www
        private void btnextract_Click(object sender, RoutedEventArgs e)
        {
            string _stockName = txtStockName.Text;
            int _raportYear = Convert.ToInt32(txtRaportYear.Text);

            if (RbBankier.IsChecked == true)
            {
                DataSnifferBankier financialRaportBankier = new DataSnifferBankier(_stockName, _raportYear);
                // GET data from web 
                // Todo : get raport as string ! 
                finansialRaport = financialRaportBankier.GetFinancialRaport();
            }
            else
            {
                DataSnifferBiznesradar finansialRaportBiznesradar = new DataSnifferBiznesradar(_stockName, _raportYear);
                // ToDo : Get raport as string !
                // ToDo 

            }

            
            
            // Showing data on screen
            // Todo : show finacial raport as string not class !
            ShowFinancialRaportOnScreen(finansialRaport);
        }

        // GET all stock companies at sql database
        private void btServerOn_Click(object sender, RoutedEventArgs e)
        {
            // Todo : code connection to server
            SqlAdapter SqlAdapt = new SqlAdapter();
        }

        // GET all companies from Sql and store them in StockPolishcompany list
        private void btGetAllCompaniesFromSql_Click(object sender, RoutedEventArgs e)
        {
            SqlAdapter SqlAdapt = new SqlAdapter();
          // ToDo -->>   SqlAdapt.GetPolishCompanies();
        }

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

        private void ShowFinancialRaportOnScreen(string raport)
        {
            txtBox.Text = "" + raport;
        }






        #endregion


    }
}

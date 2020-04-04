﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrabbingEye.Models
{
    class RaportConverter
    {
        FinancialRaport FinancialRaport = new FinancialRaport();

        private string RaportAsString = "";

        public RaportConverter(string StockName, int Year, List<int> RaportList)
        {
            ConvertToClass(StockName, Year, RaportList, ref FinancialRaport);
            ConvertToString(FinancialRaport, ref RaportAsString);
        }


        //   private void ConvertToClass(string stockName, int year,  List<int> dataList, ref YearlyFinancialRaportFull financialRaport)
        private void ConvertToClass(string stockName, int year, List<int> dataList, ref FinancialRaport financialRaport)
        {
            try
            {
                if (dataList.Count > 0)
                {
                    financialRaport.ComapanyName = stockName;
                    financialRaport.RaportYear = year;
                    // Rachunek zyskow i strat
                    financialRaport.ProfitAndLose.PrzychodyZeSprzedazy = dataList[0];
                    financialRaport.ProfitAndLose.ZyskZeSprzedazy = dataList[1];
                    financialRaport.ProfitAndLose.ZyskOperacyjny = dataList[2];
                    financialRaport.ProfitAndLose.ZyskZDzialalnosciGospodarczej = dataList[3];
                    financialRaport.ProfitAndLose.ZyskPrzedOpodatkowaniem = dataList[4];
                    financialRaport.ProfitAndLose.ZyskNetto = dataList[5];
                    financialRaport.ProfitAndLose.ZyskNettoAkcjonariuszyJednostkiDominujacej = dataList[6];
                    financialRaport.ProfitAndLose.EBITDA = dataList[7];
                    // Bilans
                    financialRaport.Balance.AktywaTrwale = dataList[8];
                    financialRaport.Balance.AktywaObrotowe = dataList[9];
                    financialRaport.Balance.AktywaRazem = financialRaport.Balance.AktywaTrwale + financialRaport.Balance.AktywaObrotowe;
                    financialRaport.Balance.KapitalWlasnyAkcjonariuszyJednostkiDominujacej = dataList[10];
                    financialRaport.Balance.UdzialyNiekontrolujace = dataList[11];
                    financialRaport.Balance.ZobowiazaniaDlugoterminowe = dataList[12];
                    financialRaport.Balance.ZobowiazaniaKrotkoterminowe = dataList[13];
                    financialRaport.Balance.PasywaRazem = financialRaport.Balance.KapitalWlasnyAkcjonariuszyJednostkiDominujacej + financialRaport.Balance.UdzialyNiekontrolujace + financialRaport.Balance.ZobowiazaniaDlugoterminowe + financialRaport.Balance.ZobowiazaniaKrotkoterminowe;
                    // Cash Flow
                    financialRaport.CashFlow.PrzeplywyZDzialalnosciOperacyjnej = dataList[14];
                    financialRaport.CashFlow.PrzeplywyZDzialalnosciInvestycyjnej = dataList[15];
                    financialRaport.CashFlow.PrzeplywyZDzialalnosciFinansowej = dataList[16];
                    financialRaport.CashFlow.PrzeplywyRazem = financialRaport.CashFlow.PrzeplywyZDzialalnosciOperacyjnej + financialRaport.CashFlow.PrzeplywyZDzialalnosciInvestycyjnej + financialRaport.CashFlow.PrzeplywyZDzialalnosciFinansowej;
                }
                else
                {
                    MessageBox.Show("Brak danych");
                }
            }
            catch
            {
                MessageBox.Show(" blad : " + stockName);
            }
        }

        private void ConvertToString(FinancialRaport raport, ref string stringRaport)
        {
            stringRaport = "Firma : " + raport.ComapanyName + "\n" +
                "Raport za rok : " + raport.RaportYear + "\n\n" +
                "Zyski i straty : \n" +
                "Przychody ze sprzedazy : " + raport.ProfitAndLose.PrzychodyZeSprzedazy + "\n" +
                "Zysk ze sprzedazy : " + raport.ProfitAndLose.PrzychodyZeSprzedazy + "\n" +
                "Zysk ze sprzedazy : " + raport.ProfitAndLose.ZyskZeSprzedazy + "\n" +
                "Zysk operacyjny EBIT : " + raport.ProfitAndLose.ZyskOperacyjny + "\n" +
                "Zysk z dzialalnosci gospodarczej : " + raport.ProfitAndLose.ZyskZDzialalnosciGospodarczej + "\n" +
                "Zysk przed opodatkowaniem : " + raport.ProfitAndLose.ZyskPrzedOpodatkowaniem + "\n" +
                "Zysk netto : " + raport.ProfitAndLose.ZyskNetto + "\n" +
                "EBITDA : " + raport.ProfitAndLose.EBITDA + "\n" +
                "\nBilans : \n" +
                "Aktywa razem : " + raport.Balance.AktywaRazem + "\n" +
                "Pasywa razem : " + raport.Balance.PasywaRazem + "\n" +
                "\nCash Flow : \n" +
                "Przeplywy z dzialanosci operacyjnej : " + raport.CashFlow.PrzeplywyZDzialalnosciOperacyjnej + "\n" +
                "Przeplywy z dzialanosci investycyjnej : " + raport.CashFlow.PrzeplywyZDzialalnosciInvestycyjnej + "\n" +
                "Przeplywy z dzialanosci finansowej : " + raport.CashFlow.PrzeplywyZDzialalnosciFinansowej + "\n" +
                "Przeplywy razem : " + raport.CashFlow.PrzeplywyRazem + "\n";
        }

        // GET

        // GET - raport as class
        public FinancialRaport GetFinancialRaportAsClass()
        {
            return this.FinancialRaport;
        }

        // GET - raport as string
        public string GetFinancialRaportAsString()
        {
            return this.RaportAsString;
        }

    }
}

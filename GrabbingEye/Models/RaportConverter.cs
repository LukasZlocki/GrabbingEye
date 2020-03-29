using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class RaportConverter
    {
        YearlyFinancialRaportFull FinancialRaport = new YearlyFinancialRaportFull();

        private string RaportAsString = "";

        public RaportConverter(List<int> RaportList)
        {
            ConvertToClass(RaportList, ref FinancialRaport);
            ConvertToString(FinancialRaport, ref RaportAsString);
        }


        private void ConvertToClass(List<int> dataList, ref YearlyFinancialRaportFull financialRaport)
        {
            // Rachunek zyskow i strat
            financialRaport.PrzychodyZeSprzedazy = dataList[0];
            financialRaport.ZyskZeSprzedazy = dataList[1];
            financialRaport.ZyskOperacyjny = dataList[2];
            financialRaport.ZyskZDzialalnosciGospodarczej = dataList[3];
            financialRaport.ZyskPrzedOpodatkowaniem = dataList[4];
            financialRaport.ZyskNetto = dataList[5];
            financialRaport.ZyskNettoAkcjonariuszyJednostkiDominujacej = dataList[6];
            financialRaport.EBITDA = dataList[7];
            // Bilans
            financialRaport.AktywaTrwale = dataList[8];
            financialRaport.AktywaObrotowe = dataList[9];
            financialRaport.AktywaRazem = financialRaport.AktywaTrwale + financialRaport.AktywaObrotowe;
            financialRaport.KapitalWlasnyAkcjonariuszyJednostkiDominujacej = dataList[10];
            financialRaport.UdzialyNiekontrolujace = dataList[11];
            financialRaport.ZobowiazaniaDlugoterminowe = dataList[12];
            financialRaport.ZobowiazaniaKrotkoterminowe = dataList[13];
            financialRaport.PasywaRazem = financialRaport.KapitalWlasnyAkcjonariuszyJednostkiDominujacej + financialRaport.UdzialyNiekontrolujace + financialRaport.ZobowiazaniaDlugoterminowe + financialRaport.ZobowiazaniaKrotkoterminowe;
            // Cash Flow
            financialRaport.PrzeplywyZDzialalnosciOperacyjnej = dataList[14];
            financialRaport.PrzeplywyZDzialalnosciInvestycyjnej = dataList[15];
            financialRaport.PrzeplywyZDzialalnosciFinansowej = dataList[16];
            financialRaport.PrzeplywyRazem = financialRaport.PrzeplywyZDzialalnosciOperacyjnej + financialRaport.PrzeplywyZDzialalnosciInvestycyjnej + financialRaport.PrzeplywyZDzialalnosciFinansowej;
        }

        private void ConvertToString(YearlyFinancialRaportFull raport, ref string stringRaport)
        {
            stringRaport = "Zyski i straty : \n" +
                "Przychody ze sprzedazy : " + raport.PrzychodyZeSprzedazy + "\n" +
                "Zysk ze sprzedazy : " + raport.PrzychodyZeSprzedazy + "\n" +
                "Zysk ze sprzedazy : " + raport.ZyskZeSprzedazy + "\n" +
                "Zysk operacyjny EBIT : " + raport.ZyskOperacyjny + "\n" +
                "Zysk z dzialalnosci gospodarczej : " + raport.ZyskZDzialalnosciGospodarczej + "\n" +
                "Zysk przed opodatkowaniem : " + raport.ZyskPrzedOpodatkowaniem + "\n" +
                "Zysk netto : " + raport.ZyskNetto + "\n" +
                "EBITDA : " + raport.EBITDA + "\n" +
                "\nBilans : \n" +
                "Aktywa razem : " + raport.AktywaRazem + "\n" +
                "Pasywa razem : " + raport.PasywaRazem + "\n" +
                "\nCash Flow : \n" +
                "Przeplywy z dzialanosci operacyjnej : " + raport.PrzeplywyZDzialalnosciOperacyjnej + "\n" +
                "Przeplywy z dzialanosci investycyjnej : " + raport.PrzeplywyZDzialalnosciInvestycyjnej + "\n" +
                "Przeplywy z dzialanosci finansowej : " + raport.PrzeplywyZDzialalnosciFinansowej + "\n" +
                "Przeplywy razem : " + raport.PrzeplywyRazem + "\n";
        }

        // GET

        // GET - raport as class
        public YearlyFinancialRaportFull GetFinancialRaportAsClass()
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

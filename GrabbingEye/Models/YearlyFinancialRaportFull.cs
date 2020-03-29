using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class YearlyFinancialRaportFull
    {


        #region Rachunek zyskow i strat
            public int PrzychodyZeSprzedazy { get; set; }
            public int ZyskZeSprzedazy { get; set; }
            public int ZyskOperacyjny { get; set; }       
            public int ZyskZDzialalnosciGospodarczej { get; set; }
            public int ZyskPrzedOpodatkowaniem { get; set; }
            public int ZyskNetto { get; set; }
            public int ZyskNettoAkcjonariuszyJednostkiDominujacej { get; set; }
            public int EBITDA { get; set; }
        #endregion

        #region Bilans
        public int AktywaTrwale { get; set; }      
            public int AktywaObrotowe { get; set; }
            public int AktywaRazem { get; set; }
            public int KapitalWlasnyAkcjonariuszyJednostkiDominujacej { get; set; }
            public int UdzialyNiekontrolujace { get; set; }
            public int ZobowiazaniaDlugoterminowe { get; set; }
            public int ZobowiazaniaKrotkoterminowe { get; set; }
            public int PasywaRazem { get; set; }
        #endregion

        #region Cash Flow
        public int PrzeplywyZDzialalnosciOperacyjnej { get; set; }
        public int PrzeplywyZDzialalnosciInvestycyjnej { get; set; }
        public int PrzeplywyZDzialalnosciFinansowej { get; set; }
        public int PrzeplywyRazem { get; set; }
        #endregion


    }
}

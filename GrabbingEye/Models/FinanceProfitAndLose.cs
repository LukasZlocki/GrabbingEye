namespace GrabbingEye.Models
{
    class FinanceProfitAndLose
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
    }
}

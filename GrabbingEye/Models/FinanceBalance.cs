namespace GrabbingEye.Models
{
    class FinanceBalance
    {
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
    }
}

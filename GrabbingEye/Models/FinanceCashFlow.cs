namespace GrabbingEye.Models
{
    class FinanceCashFlow
    {
        public string ComapanyName { get; set; }
        public int RaportYear { get; set; }

        #region Cash Flow
        public int PrzeplywyZDzialalnosciOperacyjnej { get; set; }
        public int PrzeplywyZDzialalnosciInvestycyjnej { get; set; }
        public int PrzeplywyZDzialalnosciFinansowej { get; set; }
        public int PrzeplywyRazem { get; set; }
        #endregion
    }
}

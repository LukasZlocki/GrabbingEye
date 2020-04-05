namespace GrabbingEye.Models
{
    class FinancialRaport : IFinancialRaport
    {
        public string ComapanyName { get; set; }
        public int Id { get; set; }
        public int RaportYear { get; set; }

        public ProfitAndLose ProfitAndLose = new ProfitAndLose();
        public Balance Balance = new Balance();
        public CashFlow CashFlow = new CashFlow();


        #region SET - raport
        public void SetProfitAndLoseRaport(ProfitAndLose profitAndLose)
        {
            ProfitAndLose = profitAndLose;
        }

        public void SetBalanceRaport(Balance balance)
        {
            Balance = balance;
        }

        public void SetCashFlowRaport(CashFlow cashFlow)
        {
            CashFlow = cashFlow;
        }

        #endregion

        #region GET - raport
        // GET - raport

        public ProfitAndLose GetProfitAndLoseRaport()
        {
            return (ProfitAndLose);
        }

        public Balance GetBalanceRaport()
        {
            return (Balance);
        }

        public CashFlow GetCashFlowRaport()
        {
            return (CashFlow);
        }
        #endregion
    }
}

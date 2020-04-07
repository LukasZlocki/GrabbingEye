namespace GrabbingEye.Models
{
    class FinancialRaport : IFinancialRaport
    {
        public int Id { get; set; }
        public string ComapanyName { get; set; }
        public int RaportYear { get; set; }

        public FinanceProfitAndLose ProfitAndLose = new FinanceProfitAndLose();
        public FinanceBalance Balance = new FinanceBalance();
        public FinanceCashFlow CashFlow = new FinanceCashFlow();


        #region SET - raport
        public void SetProfitAndLoseRaport(FinanceProfitAndLose profitAndLose)
        {
            ProfitAndLose = profitAndLose;
        }

        public void SetBalanceRaport(FinanceBalance balance)
        {
            Balance = balance;
        }

        public void SetCashFlowRaport(FinanceCashFlow cashFlow)
        {
            CashFlow = cashFlow;
        }

        #endregion

        #region GET - raport
        // GET - raport

        public FinanceProfitAndLose GetProfitAndLoseRaport()
        {
            return (ProfitAndLose);
        }

        public FinanceBalance GetBalanceRaport()
        {
            return (Balance);
        }

        public FinanceCashFlow GetCashFlowRaport()
        {
            return (CashFlow);
        }
        #endregion
    }
}

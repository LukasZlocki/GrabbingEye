namespace GrabbingEye.Models
{
    interface IFinancialRaport
    {
        // SET - raport
        void SetProfitAndLoseRaport(FinanceProfitAndLose ProfitAndLose);
        void SetBalanceRaport(FinanceBalance balance);
        void SetCashFlowRaport(FinanceCashFlow cashFlow);

       // GET - raport
       FinanceProfitAndLose GetProfitAndLoseRaport();
       FinanceBalance GetBalanceRaport();
       FinanceCashFlow GetCashFlowRaport();
    }
}

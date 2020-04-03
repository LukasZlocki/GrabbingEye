using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class FinancialRaport : IFinancialRaport
    {
        public string ComapanyName { get; set; }
        public string RaportYear { get; set; }

        ProfitAndLose ProfitAndLose = new ProfitAndLose();
        Balance Balance = new Balance();
        CashFlow CashFlow = new CashFlow();


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

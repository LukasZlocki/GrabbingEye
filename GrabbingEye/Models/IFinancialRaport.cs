using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    interface IFinancialRaport
    {
        // SET - raport
        void SetProfitAndLoseRaport(ProfitAndLose ProfitAndLose);
        void SetBalanceRaport(Balance balance);
        void SetCashFlowRaport(CashFlow cashFlow);

       // GET - raport
       ProfitAndLose GetProfitAndLoseRaport();
       Balance GetBalanceRaport();
       CashFlow GetCashFlowRaport();
    }
}

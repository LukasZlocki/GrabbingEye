using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class CashFlow
    {
        #region Cash Flow
        public int PrzeplywyZDzialalnosciOperacyjnej { get; set; }
        public int PrzeplywyZDzialalnosciInvestycyjnej { get; set; }
        public int PrzeplywyZDzialalnosciFinansowej { get; set; }
        public int PrzeplywyRazem { get; set; }
        #endregion
    }
}

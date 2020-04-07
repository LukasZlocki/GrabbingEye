using GrabbingEye.Models;
using System.Collections.Generic;

namespace GrabbingEye.ModelsSql
{
    interface ISqlAdapter
    {
        // PUSH - financial data to server
        void SaveFinancialDataOnSqlServer(List<FinancialRaport> FinancialRaportList);
       
        // GET - companies list
        List<PolishCompany> GetCompaniesList();

        // GET - user raport for server activities
        string GetRaport();

    }
}

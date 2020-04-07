using GrabbingEye.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GrabbingEye.ModelsSql
{
    class SqlAdapter : ISqlAdapter
    {
        List<PolishCompany> ListOfPolishCompanies = new List<PolishCompany>();

        // constr
        public SqlAdapter()
        {
            
        }


        // GET - raport
        public string GetRaport()
        {
            string _raport = "";
            int _quantity = 0;

            _quantity = this.ListOfPolishCompanies.Count;
            _raport = "Companies loaded : " + _quantity;

            return (_raport);
        }

        // GET - List of companies
        public List<PolishCompany> GetCompaniesList()
        {
            LoadCompanies(ref ListOfPolishCompanies);
            return (this.ListOfPolishCompanies);
        }

        // load all companies (polish stocks)
        private void LoadCompanies(ref List<PolishCompany> listOfPolishCompanies)
        {
            SqlAdapterCompanies LoadCompanies = new SqlAdapterCompanies();
            ListOfPolishCompanies = LoadCompanies.GetListOfCompanies();
        }


        //SAVE - Financial data to Sql
        public void SaveFinancialDataOnSqlServer(List<FinancialRaport> FinancialRaportsList)
        {
            SqlAdapterFinanceBalance financeBalance = new SqlAdapterFinanceBalance();
            SqlAdapterFinanceCashFlow cashFlow = new SqlAdapterFinanceCashFlow();
            SqlAdapterFinanceProfitAndLose profitAndLose = new SqlAdapterFinanceProfitAndLose();

            financeBalance.PushFinanceBalanceRaport(FinancialRaportsList);
            cashFlow.PushFinanceCashFlowRaport(FinancialRaportsList);
            profitAndLose.PushFinanceProfitAndLoseRaport(FinancialRaportsList);
        }



    }
}

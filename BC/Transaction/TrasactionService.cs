using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Transaction
{
    /// <summary>
    /// trasanction service used to interact with my data source
    /// </summary>
    public class TransactionService
    {

       // Singleton commented , the source list gets overrided every time

        //private TransactionService()

        //{

        //}

        //private static TransactionService instance = null;

        //public static TransactionService Instance

        //{

        //    get

        //    {

        //        if (instance == null)

        //        {

        //            instance = new TransactionService();
        //            //pumping default data set into the source
        //            if (allTransactions == null)
        //            {
        //                allTransactions = new List<TransactionModel>();
        //                for (int i = 0; i < 10; i++)
        //                {
        //                    TransactionModel tranModel = new TransactionModel();
        //                    tranModel.Id = Guid.NewGuid();
        //                    tranModel.ApplicationId = 90001 + i;
        //                    tranModel.Type = "Debit";
        //                    tranModel.Summary = "Payment";
        //                    tranModel.Amount = Convert.ToDecimal("58.26");
        //                    tranModel.PostingDate = DateTime.Today.AddHours(i);
        //                    tranModel.IsCleared = true;
        //                    tranModel.ClearedDate = DateTime.Today.AddHours(i);

        //                    allTransactions.Add(tranModel);
        //                }
        //            }

        //        }

        //        return instance;

        //    }

        //}















        List<TransactionModel> allTransactions = null;
        public TransactionService()
        {
            //pumping default data set into the source
            if (allTransactions == null)
            {
                allTransactions = new List<TransactionModel>();
                for (int i = 0; i < 10; i++)
                {
                    TransactionModel tranModel = new TransactionModel();
                    tranModel.Id = Guid.NewGuid();
                    tranModel.ApplicationId = 90001 + i;
                    tranModel.Type = "Debit";
                    tranModel.Summary = "Payment";
                    tranModel.Amount = Convert.ToDecimal("58.26");
                    tranModel.PostingDate = DateTime.Today.AddHours(i);
                    tranModel.IsCleared = true;
                    tranModel.ClearedDate = DateTime.Today.AddHours(i);

                    allTransactions.Add(tranModel);
                }
            }

        }

        public List<TransactionModel> GetTrasactions()
        {
            return allTransactions;
        }

        /// <summary>
        /// Add the trasaction to the data source
        /// </summary>
        /// <param name="tranModel">transaction details to be added</param>
        /// <returns>throw exepction if application id already exist</returns>
        public List<TransactionModel> PostTransation(TransactionModel tranModel)
        {
         

            try
            {
                var allTransaction = allTransactions?.Find(x => x.ApplicationId == tranModel.ApplicationId);
                if (allTransaction == null)
                {
                    allTransactions.Add(allTransaction);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return allTransactions;
        }

        /// <summary>
        /// Get the transaction for the the given application id
        /// </summary>
        /// <param name="id">application id</param>
        /// <returns></returns>
        public TransactionModel GetTrasactionByID(int id)
        {
            TransactionModel transaction = null;
            try
            {
                transaction = allTransactions?.SingleOrDefault(x => x.ApplicationId == id);
                return transaction;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return transaction;
        }

        public void PutTransaction(TransactionModel tran)
        {
            try
            {
                var Transactions = allTransactions?.Find(x => x.ApplicationId == tran.ApplicationId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}

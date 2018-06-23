using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BC.Transaction;
using MohamedBassam_equiniti_cs_techTest_webAPI.Models;
using Model;

namespace MohamedBassam_equiniti_cs_techTest_webAPI.Controllers
{
    [RoutePrefix("api/transaction")]
    public class TransactionController : ApiController
    {
        TransactionService myService = new TransactionService();
        // GET: api/Transaction
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<TransactionModel> allTransations = myService.GetTrasactions();
            return Content(HttpStatusCode.OK, allTransations);
        }

        [Route("{applicationID}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]int applicationID)
        {
            TransactionModel transaction = myService.GetTrasactionByID(applicationID);
            return Content(HttpStatusCode.OK, transaction);
        }

        // POST: api/Transaction
        [HttpPost]
        public IHttpActionResult Post([FromBody]Transaction transaction)
        {
            if (ModelState.IsValid)
            {                
                TransactionService service = new TransactionService();
                service.PostTransation(mapModel(transaction));
                return Content(HttpStatusCode.Created,service);
            }
            else
            {
                return BadRequest();

            }
        }


        /// <summary>
        /// maps to bc model
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private TransactionModel mapModel(Transaction transaction)
        {
            TransactionModel model = null;
            if (transaction != null)
            {
                model = new TransactionModel();
                model.Id = transaction.Id;
                model.ApplicationId = transaction.ApplicationId;
                model.Amount = transaction.Amount;
                model.IsCleared = transaction.IsCleared;
                model.ClearedDate = transaction.ClearedDate;
                model.Summary = transaction.Summary;
                model.Type = transaction.Type;
                model.PostingDate = transaction.PostingDate; 
                
            }
            return model; 
        }

        // PUT: api/Transaction/5
        [HttpPut]
        public IHttpActionResult Put([FromUri]int applicationID, [FromBody]Transaction trans)
        {
            if (ModelState.IsValid)
            {
                myService.PutTransaction(mapModel(trans));
                return Content(HttpStatusCode.OK, applicationID);
            }
            else
                return BadRequest();
        }

        // DELETE: api/Transaction/5
        public void Delete(int id)
        {
        }
    }
}

using Invest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest1.Controllers
{
    public class TransactionController : ApiController
    {
        // GET: api/Transaction
        public IEnumerable<Transaction> Get()
        {
            return DatabaseMock.getAll();
        }

        // GET: api/Transaction/5
        public Transaction Get(int id)
        {
            return DatabaseMock.getTransactionById(id);
        }

        // POST: api/Transaction
        public void Post([FromBody]Transaction value)
        {
            DatabaseMock.saveTransaction(value);
        }

        // PUT: api/Transaction/5
        public void Put(int id, [FromBody]Transaction value)
        {
            value.setId(id);
            DatabaseMock.saveTransaction(value);

        }

        // DELETE: api/Transaction/5
        public void Delete(int id)
        {
            DatabaseMock.deleteInvestEvent(id);
        }

        // DELETE: api/Transaction
        public void Delete()
        {
            DatabaseMock.deleteAll();
        }
    }
}

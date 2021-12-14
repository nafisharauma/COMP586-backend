using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLayer.Model;
using DataAccessLayer;
using BusinessLayer;

namespace CodeFirst.Controllers
{
    public class UserController : ApiController
    {
       // private ProjectContext db = new ProjectContext();
        private UserBL db = new UserBL();

        // GET api/User
 

        [HttpGet]
        [Route("api/user/accountdetails/{UserID}")]
        public List<NewUser> GetAccountDetails(string UserID)
        {
            //return db.GetUsers(UserID);
            return db.getAccountDetails();
        }



        


       

        //// GET api/User/5
        //[ResponseType(typeof(Transaction))]
        //public IHttpActionResult GetTransaction(string id)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(transaction);
        //}

        //// PUT api/User/5
        //public IHttpActionResult PutTransaction(string id, Transaction transaction)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != transaction.TransactionID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(transaction).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TransactionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/User
        //[ResponseType(typeof(Transaction))]
        //public IHttpActionResult PostTransaction(Transaction transaction)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Transactions.Add(transaction);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (TransactionExists(transaction.TransactionID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = transaction.TransactionID }, transaction);
        //}

        //// DELETE api/User/5
        //[ResponseType(typeof(Transaction))]
        //public IHttpActionResult DeleteTransaction(string id)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Transactions.Remove(transaction);
        //    db.SaveChanges();

        //    return Ok(transaction);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TransactionExists(string id)
        //{
        //    return db.Transactions.Count(e => e.TransactionID == id) > 0;
        //}
    }
}
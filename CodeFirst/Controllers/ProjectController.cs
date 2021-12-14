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
using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Model;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace CodeFirst.Controllers
{
    public class ProjectController : ApiController
    {
        //private ProjectContext db = new ProjectContext();
        private UserBL db = new UserBL();

        // GET api/Default1
        //public List<User> GetUsers()
        //{
        //    return db.GetUsers().ToList();
        //}

        // GET api/Default1/5
        //    [ResponseType(typeof(User))]
        //    public IHttpActionResult GetUser(int id)
        //    {
        //        User user = db.Users.Find(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(user);
        //    }

        //    // PUT api/Default1/5
        //    public IHttpActionResult PutUser(int id, User user)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != user.UserID)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }

        // POST api/Default1
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/project/register")]
        [ResponseType(typeof(NewUser))]
        public IHttpActionResult PostUser(NewUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMsg response = new RespMsg();

                Random r = new Random();
                string AccountNumber = RandomDigits(5);
                user.AccountNumber = AccountNumber;
                user.OpeningDate = DateTime.Now.ToString();

                string result = db.AddUser(user);
                response.message = result;
                
                return Ok(response);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/project/login/{email}/{password}")]
        public IHttpActionResult login(string email, string password)
        {
            RespLogin response = new RespLogin();

            NewUser u = db.login(email, password);
            if (u != null)
            {
                response.UserID = u.UserID.ToString();
                response.AccountNumber = u.AccountNumber;
                response.FullName = u.FullName;
                response.OpeningDate = u.OpeningDate;
                response.Currentbalance = u.Currentbalance;
                response.Message = "Login successful";
                response.Token = generateToken();
            }
            else
            {
                response.UserID = "0";
                response.AccountNumber = "0";
                response.Message = "Invalid email id or password";
            }
            return Ok(response);
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/project/FundDeposit")]
        [ResponseType(typeof(FundDeposit))]
        public IHttpActionResult FundDeposit(FundDeposit fd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMsg response = new RespMsg();
                string result = db.FundDeposit(fd);
                response.message = result;

                return Ok(response);
            }
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/project/FundWithdrawl")]
        [ResponseType(typeof(Fundwithdrawal))]
        public IHttpActionResult FundWithdrawl(Fundwithdrawal fw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMsg response = new RespMsg();
                string result = db.FundWithdrawl(fw);
                response.message = result;

                return Ok(response);
            }
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/project/ChequeBookRequest")]
        [ResponseType(typeof(ChequeBookReq))]
        public IHttpActionResult ChequeBookRequest(ChequeBookReq cr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMsg response = new RespMsg();
                string result = db.ChequeBookRequest(cr);
                response.message = result;

                return Ok(response);
            }
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/project/AccountTransfer")]
        [ResponseType(typeof(Accounttransfer))]
        public IHttpActionResult AccountTransfer(Accounttransfer at)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMsg response = new RespMsg();
                string result = db.AccountTransfer(at);
                response.message = result;

                return Ok(response);
            }
        }

        //[System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/project/GetUsers")]
        public List<NewUser> GetUsers()
        {
           return db.getAccountDetails().ToList();
        }

        //[System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/project/GetChqrequest")]
        public List<chqbook> GetChqrequest()
        {
            return db.getChqrequest().ToList();
        }

        //[System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/project/GetUsers1")]
        public JsonResult viewaccountdetails()
        {
            //return list as Json    
            return new JsonResult()
            {
                Data = db.getAccountDetails().ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        //    // DELETE api/Default1/5
        //    [ResponseType(typeof(User))]
        //    public IHttpActionResult DeleteUser(int id)
        //    {
        //        User user = db.Users.Find(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        db.Users.Remove(user);
        //        db.SaveChanges();

        //        return Ok(user);
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        //    private bool UserExists(int id)
        //    {
        //        return db.Users.Count(e => e.UserID == id) > 0;
        //    }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }


        public string generateToken()
        {
            string securityKey = "abcdefghijklmnop";

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signInCred = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    issuer: "test@domain.in",
                    audience: "Users",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signInCred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
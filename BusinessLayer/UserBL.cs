using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBL
    {
        private BankingDb db = new BankingDb();

        public NewUser GetUsers(string UserID)
        {
            //return db.Users;

            //var query = from users in context.Users
            int user_id = Convert.ToInt32(UserID);

            NewUser user = db.Users.SingleOrDefault(u => u.UserID == user_id);
            return user;
        }

        public string AddUser(NewUser user)
        {
            try
            {
                int rowsAffected = 0;

                if (db.Users.Any(u => u.EmailID == user.EmailID))
                {
                    return "Email ID already exists";
                }
                else
                {
                    db.Users.Add(user);
                    rowsAffected = db.SaveChanges();

                    if (rowsAffected == 0)
                        return "Something went wrong";
                    else
                        return "Registration successful";
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public NewUser login(string email, string password)
        {
            NewUser user =  db.Users.SingleOrDefault(u => u.EmailID == email && u.Password == password);
          // Session["UserName"] = user.Currentbalance;
            return user;
        }

       

        public List<NewUser> getAccountDetails()
        { 
            return db.Database.SqlQuery<NewUser>("SELECT * FROM NewUsers ORDER BY OpeningDate DESC").ToList();
        }

        public List<chqbook> getChqrequest()
        {
            return db.Database.SqlQuery<chqbook>("SELECT * FROM ChequeBookReqs cq inner join NewUsers nu ON cq.AccountNumber=nu.AccountNumber ORDER BY cq.RequestDate DESC").ToList();
        }
        // check if user has already applied

       

        public string FundDeposit(FundDeposit fdt)
        {
            try
            {
                int rowsAffected = 0;
                db.TFundDeposit.Add(fdt);
                rowsAffected = db.SaveChanges();


                var balance = db.Users.Where(x => x.AccountNumber == fdt.AccountNo).FirstOrDefault();
                if (balance != null)
                {

                    var cb = Convert.ToDouble(balance.Currentbalance);
                    var da = Convert.ToDouble(fdt.DepositAmount);

                    if (balance != null)
                    {
                        balance.Currentbalance = Convert.ToDouble(cb + da).ToString();

                        db.SaveChanges();
                    }


                    if (rowsAffected == 0)
                        return "Something went wrong";
                    else
                        return "Fund deposit successfully";
                }
                else
                {
                    return "Please enter valid Account No.";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string FundWithdrawl(Fundwithdrawal wd)
        {
            try
            {
                int rowsAffected = 0;
                NewUser user = db.Users.Where(x => x.AccountNumber == wd.AccountNo).FirstOrDefault();
                if (user != null)
                {
                    var cb = Convert.ToDouble(user.Currentbalance);
                    var wa = Convert.ToDouble(wd.WithdrwalAmount);

                    if (db.Users.Any(f => cb < wa))
                    {
                        return " Your Account Balance is less than entered amount.";
                    }
                    else
                    {
                        db.TFundwithdrawal.Add(wd);
                        rowsAffected = db.SaveChanges();

                        var balance = db.Users.Where(x => x.AccountNumber == wd.AccountNo).FirstOrDefault();
                        if (balance != null)
                        {
                            balance.Currentbalance = (Convert.ToDouble(balance.Currentbalance) - Convert.ToDouble(wd.WithdrwalAmount)).ToString();

                            db.SaveChanges();
                        }

                        return "Fund withdrawl successfully";
                    }

                } 
                else
                {
                    return "Please enter valid Account No.";
                } 
                 
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public string ChequeBookRequest(ChequeBookReq cbr)
        {
            try
            {
                int rowsAffected = 0;
                //Int32 acc_no = Convert.ToInt32(cbr.AccountNumber);

                NewUser user = db.Users.Where(x => x.AccountNumber == cbr.AccountNumber).FirstOrDefault();

                if (user != null)
                {
                    var cb = Convert.ToDouble(user.Currentbalance);

                    if (cb <= 10000)
                    {
                        return " Your Account Balance is less than 10000 Rs , Chequebook cant be issued.";
                    }
                    else
                    {
                        cbr.RequestStatus = "Not Approve";
                        db.TChequeBookReq.Add(cbr);
                        rowsAffected = db.SaveChanges();
                        return "ChequeBook Request sent successfully";
                    }

                }
                else
                {
                    return "Please enter valid Account No.";
                } 

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string AccountTransfer(Accounttransfer ats)
        {
            try
            {
                int rowsAffected = 0;
                double acc_noFrom = Convert.ToDouble(ats.TransFromAccountNumber);
                double acc_noTo = Convert.ToDouble(ats.TransToAccountNumber);
                double TrAmnt = Convert.ToDouble(ats.TransAmount);

                NewUser user = db.Users.Where(x => x.AccountNumber == ats.TransFromAccountNumber).FirstOrDefault();

                if (user != null)
                {
                    var cb = Convert.ToDouble(user.Currentbalance);


                    if (cb < TrAmnt)
                    {
                        return " No Sufficient fund available";
                    }
                    else
                    {
                        db.TAccountTransfer.Add(ats);
                        rowsAffected = db.SaveChanges();

                        var balance = db.Users.Where(x => x.AccountNumber == ats.TransFromAccountNumber).FirstOrDefault();

                        if (balance != null)
                        {
                            balance.Currentbalance = (cb - TrAmnt).ToString();

                            db.SaveChanges();
                        }

                        var balanceTo = db.Users.Where(x => x.AccountNumber == ats.TransToAccountNumber).FirstOrDefault();
                        if (balanceTo != null)
                        {
                            balanceTo.Currentbalance = (cb + TrAmnt).ToString();

                            db.SaveChanges();
                        }

                        return "Money Transfered successfully";
                    }
                }
                else
                {
                    return "Please enter valid Account No.";
                }
            

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


       

    }

    public class chqbook {
        public int ChequeBookRequsetID { get; set; } 
        public string AccountNumber { get; set; } 
        public string RequestDate { get; set; } 
        public string RequestStatus { get; set; } 
        public string FullName { get; set; }
        

    }
}

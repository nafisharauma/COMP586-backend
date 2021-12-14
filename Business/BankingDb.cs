using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BankingDb : DbContext
    {
        public BankingDb()
            : base("name=BankingDb")
        {

        }

        public DbSet<NewUser> Users { get; set; }

     
        public DbSet<FundDeposit> TFundDeposit { get; set; }

        public DbSet<Fundwithdrawal> TFundwithdrawal { get; set; }

        public DbSet<ChequeBookReq> TChequeBookReq { get; set; }

        public DbSet<Accounttransfer> TAccountTransfer { get; set; }

        public object Query<T>(string query)
        {
            throw new NotImplementedException();
        }
    }
}

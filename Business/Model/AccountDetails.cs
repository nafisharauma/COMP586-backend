using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class AccountDetails
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailID { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string AccountNumber { get; set; }

        public string OpeningDate { get; set; }

        public double AccountBalance { get; set; }
    }
}

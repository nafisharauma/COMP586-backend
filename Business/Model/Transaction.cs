using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Transaction
    {
        [Key]
        public string TransactionID { get; set; }

        public string AccountNumber { get; set; }

        public double TransactionAmount { get; set; }

        public string TransactionType { get; set; }

        public double TotalBalance { get; set; }

        public DateTime TransactionDate { get;set;}
    }
}

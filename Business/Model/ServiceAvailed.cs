using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ServiceAvailed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        public int AccountNumber { get; set; }

        public string CustomerName { get; set; }

        public string BranchName { get; set; }

        public string AccountName { get; set; }

        public string DebitCard { get; set; }

        public string TypeOfDebitCard { get; set; }

        public double DebitAnnualCharges { get; set; }

        public string CreditCard { get; set; }

        public string TypeOfCreditCard { get; set; }

        public double CreditAnnualCharges { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class FixedDeposit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FixedDepositID { get;set; }

        public int AccountNumber { get; set; }

        public string CustomerName { get; set; }

        public string BranchName { get; set; }

        public string AccountName { get; set; }

        public string OpeningDate { get; set; }

        public string EndDate { get; set; }

        public double InvestedAmount { get; set; }

        public string PlanChoice { get; set; }

        public double RateApplied { get; set; }
    }
}

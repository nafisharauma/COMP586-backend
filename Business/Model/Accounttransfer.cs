using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Accounttransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int TransId { get; set; }
        public string TransFromAccountNumber { get; set; }

        public string TransToAccountNumber { get; set; }

        public string TransAmount { get; set; } 

        public string TransDate{ get; set; }
    }
}

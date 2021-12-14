using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Fundwithdrawal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WithdrwalID { get; set; }

        public string AccountNo { get; set; }

        public string WithdrwalDate { get; set; }

        public string WithdrwalAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class NewUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string FullName { get; set; } 

        public string EmailID { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string AccountNumber { get; set; }

        public string OpeningDate { get; set; } 

        public string Currentbalance { get; set; }

        public string NomineeName { get; set; }

        public String DOB { get; set; } 

        public string AccountType { get; set; }

    }
}

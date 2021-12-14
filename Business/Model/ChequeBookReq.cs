using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ChequeBookReq
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChequeBookRequsetID { get; set; }

        public string AccountNumber { get; set; }

        public string RequestDate { get; set; }

        public string RequestStatus { get; set; }
    }
}

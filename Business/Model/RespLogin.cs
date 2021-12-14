using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class RespLogin
    {
        public string UserID { get; set; }

        public string AccountNumber { get; set; }

        public string FullName { get; set; }

        public string OpeningDate { get; set; }

        public string Currentbalance { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }
    }
}

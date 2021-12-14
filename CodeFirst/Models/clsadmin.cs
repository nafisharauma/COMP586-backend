using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class clsadmin
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "UserName Required !")] 
        public string username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required !")]
        public string password { get; set; }

    }
}
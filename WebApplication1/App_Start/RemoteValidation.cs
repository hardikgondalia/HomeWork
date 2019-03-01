using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RemoteValidationModel
    {
        [RegularExpression(@"(?=.*[a-zA-Z0-9]).{4,20}$", ErrorMessage = "error msg")]
        [Required(ErrorMessage = "error")]
        [System.Web.Mvc.Remote("UserNameExist", "RemoteValidation", ErrorMessage = "error")]
        public string UserName { get; set; }
    }
}
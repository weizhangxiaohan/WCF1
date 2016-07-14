using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        [Required]
        [Remote("CheckUserNameIsExist","User" ,ErrorMessage = "{0} has been used by other people.")]
        public string UserName { get; set; }
        [Required]
        [StringLength(18,MinimumLength =6,ErrorMessage = "Length of {0} must between 6 and 18.")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(\w)+(\.\w+)*@(\w)+((\.\w+)+)")]
        public string Email { get; set; }
    }
}
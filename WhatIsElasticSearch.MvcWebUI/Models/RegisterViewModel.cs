using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WhatIsElasticSearch.MvcWebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[DisplayName("Confirm Password")]
        //public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}

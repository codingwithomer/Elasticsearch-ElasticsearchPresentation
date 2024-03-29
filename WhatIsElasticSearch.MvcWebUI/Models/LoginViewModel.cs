﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WhatIsElasticSearch.MvcWebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}

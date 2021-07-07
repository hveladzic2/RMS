using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RMSLibrary.Models
{
    public class RegisterCompany
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Naziv { get; set; }
        public string Misija { get; set; }
        public string KontaktEmail { get; set; }
        public string KontaktTelefon { get; set; }
        public string WebSiteURL { get; set; }
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

    }
}

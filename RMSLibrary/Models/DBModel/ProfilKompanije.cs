using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace RMSLibrary.Models.DBModel
{
    public class ProfilKompanije
    {
        [Key]
        public int Id { get; set; }
        public string UserId {get; set;}
        public string Naziv { get; set; }
        public string Misija { get; set; }
        public string Logo { get; set; }
        public string KontaktEmail { get; set; }
        public string KontaktTelefon { get; set; }
        public string WebSiteURL {get; set;}
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public ICollection<Lokacija> Lokacija { get; set; }
        public ICollection<OglasiTable> Oglasi { get; set; }
        public ICollection<Aplikacija> Aplikacija { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}

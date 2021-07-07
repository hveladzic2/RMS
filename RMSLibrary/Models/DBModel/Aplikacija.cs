using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class Aplikacija
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ime { get; set; }
        [StringLength(50)]
        public string Prezime { get; set; }
        [StringLength(255)]
        public string Email{ get; set; }
        [StringLength(50)]
        public string KontaktTelefon { get; set; }
        [StringLength(50)]
        public string SlikaProfila { get; set; }
        [StringLength(50)]
        public string CVdokument { get; set; }
        [StringLength(50)]
        public string Drzava { get; set; }
        [StringLength(50)]
        public string Grad { get; set; }
        [StringLength(50)]
        public string Adresa { get; set; }
        public string Spol { get; set; }
        public string MotivacionoPismo { get; set; }
        public string DatumRodjenja { get; set; }
        public int oglasId { get; set;  }
        [ForeignKey("oglasId")]
        public virtual OglasiTable oglas { get; set; }
        public int ProfilKompanijeId { get; set; }
        [ForeignKey("ProfilKompanijeId")]
        public virtual ProfilKompanije profilKompanije { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        [NotMapped]
        public IFormFile CVFile { get; set; }

        [NotMapped]
        public string CVSrc { get; set; }
    }
}

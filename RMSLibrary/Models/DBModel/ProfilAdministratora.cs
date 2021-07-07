using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class ProfilAdministratora
    {

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [StringLength(50)]
        public string Ime { get; set; }
        [StringLength(50)]
        public string Prezime { get; set; }
        [StringLength(50)]
        public string SlikaProfila { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }
    }
}

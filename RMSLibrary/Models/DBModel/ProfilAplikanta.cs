using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class ProfilAplikanta
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ime { get; set; }
        [StringLength(50)]
        public string Prezime { get; set; }
        [StringLength(50)]
        public string KontaktTelefon { get; set; }
        [StringLength(50)]
        public string SlikaProfila { get; set; }
        [StringLength(50)]
        public string Drzava { get; set; }
        [StringLength(50)]
        public string Grad { get; set; }
        [StringLength(50)]
        public string Adresa { get; set; }
        public string Spol { get; set; }
        public string MotivacionoPismo { get; set; }
        public DataType DatumRodjenja { get; set; }
        public ICollection<Obrazovanje> Obrazovanje { get; set; }
        public ICollection<Vjestine> Vjestine { get; set; }
        public ICollection<RadnoIskustvo> RadnoIskustvo { get; set; }
        public ICollection<OglasiTable> Oglasi { get; set; }
        
    }
}

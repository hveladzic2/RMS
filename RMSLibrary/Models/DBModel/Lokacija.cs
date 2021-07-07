using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class Lokacija
    {
        [Key]
        public int Id { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public string Ulica { get; set; }
        public ProfilKompanije ProfilKompanija { get; set; }
        public ICollection<OglasiTable> Oglas { get; set; }
        public ICollection<Status> Status { get; set; }
    }
}

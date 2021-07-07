using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class Adresa
    {
        [Key]
        public int Id { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public string Ulica { get; set; }
    }
}

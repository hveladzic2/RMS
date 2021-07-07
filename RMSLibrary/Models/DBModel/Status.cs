using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string OpisniAtribut { get; set; }
        public int LokacijaId { get; set; }
        [ForeignKey("LokacijaId")]
        public virtual Lokacija lokacija { get; set; }
        public ICollection<OglasiTable> Oglasi { get; set; }
    }
}

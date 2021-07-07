using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class OglasiTable
    {
        [Key]
        public int Id { get; set; }
        public string Odjel { get; set; }
        public string Pozicija { get; set; }
        public string DodatneInformacije { get; set; }
        public string PocetakPrijave { get; set; }
        public string DatumIsteka { get; set; }
        [NotMapped]
        public string Naziv { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }
        public int ProfilKompanijeId1 { get; set; }
        [ForeignKey("ProfilKompanijeId1")]
        public ProfilKompanije ProfilKompanije { get; set; }
        public Status Status { get; set; }

        public ICollection<ProfilAplikanta> ProfiliAplikanata { get; set; }
        public ICollection<Lokacija> Lokacija { get; set; }
        public ICollection<Aplikacija> Aplikacija { get; set; }
    }
}

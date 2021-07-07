using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class RadnoIskustvo
    {
        [Key]
        public int Id { get; set; }
        public string NazivKompanije { get; set; }
        public string Adresa { get; set; }
        public string RadnaPozicija { get; set; }
        public DataType DatumPocetka { get; set; }
        public DataType DatumZavrsetka { get; set; }
        public ProfilAplikanta ProfilAplikanta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class Obrazovanje
    {
        [Key]
        public int Id { get; set; }
        public string Zvanje { get; set; }
        public string StepenCertifikata { get; set; }
        public string NazivObrazovneInstitucije { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public ProfilAplikanta ProfilAplikanta { get; set; }

    }
}

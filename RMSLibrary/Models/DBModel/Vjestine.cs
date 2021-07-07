using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMSLibrary.Models.DBModel
{
    public class Vjestine
    {
        [Key]
        public int Id { get; set; }
        public string Vjestina { get; set; }
        public string NivoPoznavanja { get; set; }
        public ProfilAplikanta ProfilAplikanta { get; set; }

    }
}

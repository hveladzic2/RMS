using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMSLibrary.Models
{
    public class GetUserById
    {
		public string Id { get; set; }
		public string UserName { get; set; }
		public bool EmailConfirmed { get; set; }
		public string PhoneNumber { get; set; }
		public bool PhoneNumberConfirmed { get; set; }
		public bool TwoFactorEnabled { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Drzava { get; set; }

        public string Grad { get; set; }

        public string Adresa { get; set; }

        public DataType DatumRodjenja { get; set; }

        public string SlikaProfila { get; set; }
        public string KontaktTelefon { get; set; }
    }
}

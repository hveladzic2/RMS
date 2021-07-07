using System;
using System.Collections.Generic;
using System.Text;

namespace RMSLibrary.Models
{
    public class RefreshTokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}

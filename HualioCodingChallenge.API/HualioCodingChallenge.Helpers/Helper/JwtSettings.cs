using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Helpers.Helper
{
    public class JwtSettings
    {
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string JwtSecret { get; set; }
    }
}

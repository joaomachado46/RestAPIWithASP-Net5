using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Configurations
{
    public class TokenConfiguration //É PRECISO DEFINIR ESTE TOKENSERVICE NO APPSETTINGS.
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int Minutes { get; set; }
        public int DaysToExpirity { get; set; }
 
    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper //imzalama
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //hashlerken ve doğrularken kullandığımız "HMACSHA512" Cryptography classını kullandığımızı belirtmek için böyle bir class yazdık
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}

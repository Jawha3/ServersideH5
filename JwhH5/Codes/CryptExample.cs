using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwhH5.Codes
{
    public class CryptExample
    {
        public string Encrypt(string payload, IDataProtector _protector)
        {
            // Hash
            return _protector.Protect(payload);
        }

        
        public string Decrypt(string protectedPayload, IDataProtector _protector)
        {
            // Verify
            return _protector.Unprotect(protectedPayload);
        }
    }
}

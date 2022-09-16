using System;

namespace CertificateGen
{
    public class CertificateGenerationException : Exception
    {
        public CertificateGenerationException(string message) : base(message)
        {
            
        }
    }
}
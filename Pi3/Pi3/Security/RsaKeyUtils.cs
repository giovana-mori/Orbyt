using System.Security.Cryptography;

namespace Pi3.Security
{
    public class RsakeyUtils
    {
        public static RSA GetPrivateKey(string caminho)
        {
            var rsa = RSA.Create();
            var primaryKey = File.ReadAllText(caminho);
            rsa.ImportFromPem(primaryKey);
            return rsa;
        }

        public static RSA GetPublicKey(string caminho) 
        { 
            var rsa = RSA.Create(); 
            var publicKey = File.ReadAllText(caminho); 
            rsa.ImportFromPem(publicKey);
            return rsa;
        }
    }
}

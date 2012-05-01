using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSAClasses;

namespace Web_Security_Backend_Login_Handler.Models
{
    public static class encryption_wrapper
    {
        //TODO: need to impliment with Scotts encrption

        public static string encrypt_message(long public_key, long shared_key, string message)
        {
            RSA rsa = new RSA();
            rsa.setPublicKey((ulong)(public_key), (ulong)shared_key);
            return rsa.encrypt(message);
        }
        public static string decrypt_message(string private_key, long remote_shared_key, string message)
        {
            return decrypt_message(Int64.Parse(private_key), remote_shared_key, message);
        }
        public static string decrypt_message(long private_key, long remote_shared_key, string message)
        {
            RSA rsa = new RSA();
            rsa.setPrivateKey((ulong)private_key, (ulong)remote_shared_key);
            return rsa.decrypt(message);
        }
        public static Server_keys get_keys()
        {
            RSA rsa = new RSA(Primes.getPrime(), Primes.getPrime());
            ulong public_key = 0;
            ulong private_key =0;
            ulong shared_key = 0;
            rsa.getPublicKey(ref public_key, ref shared_key);
            rsa.getPrivateKey(ref private_key, ref shared_key);

            // should be using scotts key generator
            //Random rand = new Random();
            return new Server_keys((long)public_key, (long)private_key, (long)shared_key);
        }
    }
}
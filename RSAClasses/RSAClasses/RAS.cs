using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSAClasses
{
    public class RSA
    {
        private long n;
        private long e;
        private long d;

        public RSA(long p = 2, long q = 3, long firste = 2)
        {
            this.recalculateKeys(p, q, firste);
        }

        protected long gcd(long a, long b)
        {
            while (b != 0)
            {
                long t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        public void recalculateKeys(long p, long q, long firste = 2)
        {
            n = p * q;
            long Euler = (p - 1) * (q - 1);

            e = firste;
            while (gcd(Euler, e) > 1)
            {
                e++;
            }

            if (e > n)
            {
                throw new ArgumentException("No valid e above " + firste.ToString() + " for these primes.");
            }

            d = 1;
            while (((d * e) % Euler) != 1)
            {
                d++;
            }

            if (d > n)
            {
                throw new ArgumentException("No valid d for the first e above " + firste.ToString() + " for these primes.");
            }
        }

        public void setPublicKey(long exponent, long modulus)
        {
            n = modulus;
            e = exponent % n;
        }

        public void getPublicKey(ref long exponent, ref long modulus)
        {
            exponent = e;
            modulus = n;
        }

        public void setPrivateKey(long exponent, long modulus)
        {
            n = modulus;
            d = exponent % n;
        }

        public void getPrivateKey(ref long exponent, ref long modulus)
        {
            exponent = d;
            modulus = n;
        }

        public string encrypt(string plaintext)
        {
            while (plaintext.Length % 8 != 0)
            {
                plaintext += ' ';
            }

            int blocks = plaintext.Length / 8;
            long[] message = new long[blocks];

            for (int i = 0; i < blocks; i++)
            {
                string block = plaintext.Substring(i, 8);

                message[i] = stringToLong(block);
            }

            return plaintext;
        }

        protected long stringToLong(string input)
        {
            long output = 0;

            for (int i = 0; i < 8; i++)
            {

            }

            return 0;
        }
    }
}

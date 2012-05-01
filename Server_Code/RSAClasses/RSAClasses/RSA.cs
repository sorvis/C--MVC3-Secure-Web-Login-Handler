using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSAClasses
{
    public static class Primes
    {
        private static ulong[] primes = {509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761,
                                 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039,
                                 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291,
                                 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553,
                                 1559, 1567, 1571, 1579, 1583, 1597};

        private static Random random = new Random();

        public static ulong getPrime()
        {
            return primes[random.Next(0, primes.Length-1)];
        }
    }

    public class RSA
    {
        private ulong n;
        private ulong e;
        private ulong d;

        protected const int blockSize = 2;

        public RSA(ulong p = 2, ulong q = 3, ulong firste = 2)
        {
            this.recalculateKeys(p, q, firste);
        }

        protected ulong gcd(ulong a, ulong b)
        {
            while (b != 0)
            {
                ulong t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        protected ulong extendedGcd(ulong a, ulong b)
        {
            if (a > b)
            {
                ulong temp = b;
                b = a;
                a = temp;
            }

            //algorithm from http://www.di-mgt.com.au/euclidean.html#code-modinv
            //actually works
            ulong u = a, v = b;
            ulong inv, u1, u3, v1, v3, t1, t3, q;
            long iter;
            /* Step X1. Initialise */
            u1 = 1;
            u3 = u;
            v1 = 0;
            v3 = v;
            /* Remember odd/even iterations */
            iter = 1;
            /* Step X2. Loop while v3 != 0 */
            while (v3 != 0)
            {
                /* Step X3. Divide and "Subtract" */
                q = u3 / v3;
                t3 = u3 % v3;
                t1 = u1 + q * v1;
                /* Swap */
                u1 = v1; v1 = t1; u3 = v3; v3 = t3;
                iter = -iter;
            }
            /* Make sure u3 = gcd(u,v) == 1 */
            if (u3 != 1)
                return 0;   /* Error: No inverse exists */
            /* Ensure a positive result */
            if (iter < 0)
                inv = v - u1;
            else
                inv = u1;
            return inv;

            //algorithm from http://en.wikipedia.org/wiki/Extended_Euclidean_algorithm#Iterative_method_2
            //does not seem to work, don't know why.
            //ulong x = 0;
            //ulong currentx = 0;
            //ulong lastx = 1;

            //ulong y = 1;
            //ulong currenty = 0;
            //ulong lasty = 0;

            //ulong quotient = 0;
            //ulong modulus = 0;

            //while (b != 0)
            //{
            //    quotient = a / b;
            //    modulus = a % b;

            //    a = b;
            //    b = modulus;

            //    currentx = x;
            //    x = lastx - quotient * x;
            //    lastx = currentx;

            //    currenty = y;
            //    y = lasty - quotient * y;
            //    lasty = y;
            //}

            //return lastx;
        }

        protected ulong blockToUlong(string input)
        {
            ulong output = 0;

            for (int i = 0; i < blockSize; i++)
            {
                output = (output * 1000) + Convert.ToUInt64(input[i]);
            }

            return output;
        }

        protected string ulongToBlock(ulong input)
        {
            string output = "";

            for (int i = 0; i < blockSize; i++)
            {
                output = Convert.ToChar((input % 1000)) + output;
                input = input / 1000;
            }

            return output;
        }

        protected ulong cBlockToUlong(string input)
        {
            return Convert.ToUInt64(input);
        }

        protected string cUlongToBlock(ulong input)
        {
            if (n > 1000000)
            {
                string output = input.ToString();
                while (output.Length < 7)
                {
                    output = "0" + output;
                }

                return output;
            }
            else
            {
                string output = input.ToString();
                while (output.Length < 6)
                {
                    output = "0" + output;
                }

                return output;
            }
        }

        public ulong encryptUlong(ulong M)
        {
            ulong part = M;

            for (ulong i = 1; i < e; i++)
            {
                part *= M;
                part = part % n;
            }

            return part;
        }

        public ulong decryptUlong(ulong C)
        {
            ulong part = C;

            for (ulong i = 1; i < d; i++)
            {
                part *= C;
                part = part % n;
            }

            return part;
        }

        public void recalculateKeys(ulong p, ulong q, ulong firste = 2)
        {
            n = p * q;
            ulong Euler = (p - 1) * (q - 1);

            e = firste;
            while (gcd(Euler, e) > 1)
            {
                e++;
            }

            if (e > n)
            {
                throw new ArgumentException("No valid e above " + firste.ToString() + " for these primes.");
            }

            d = extendedGcd(e, Euler);

            if (d > n)
            {
                //d = d % n;
            }
        }

        public void setPublicKey(ulong exponent, ulong modulus)
        {
            n = modulus;
            e = exponent % n;
        }

        public void getPublicKey(ref ulong exponent, ref ulong modulus)
        {
            exponent = e;
            modulus = n;
        }

        public void setPrivateKey(ulong exponent, ulong modulus)
        {
            n = modulus;
            d = exponent % n;
        }

        public void getPrivateKey(ref ulong exponent, ref ulong modulus)
        {
            exponent = d;
            modulus = n;
        }

        public string encrypt(string plaintext)
        {
            while (plaintext.Length % blockSize != 0)
            {
                plaintext += ' ';
            }

            int blocks = plaintext.Length / blockSize;
            string ciphertext = "";

            for (int i = 0; i < blocks; i++)
            {
                string block = plaintext.Substring(i*blockSize, blockSize);

                ulong M = blockToUlong(block);

                ulong C = encryptUlong(M);

                ciphertext += cUlongToBlock(C);
            }

            return ciphertext;
        }

        public string decrypt(string ciphertext)
        {
            int cblockSize = blockSize*3;

            if (n > 1000000)
            {
                cblockSize++;
            }

            int blocks = ciphertext.Length / cblockSize;
            string plaintext = "";

            for (int i = 0; i < blocks; i++)
            {
                string block = ciphertext.Substring(i*cblockSize, cblockSize);

                ulong C = cBlockToUlong(block);

                ulong M = decryptUlong(C);

                plaintext += ulongToBlock(M);
            }

            return plaintext.Trim();
        }
    }
}

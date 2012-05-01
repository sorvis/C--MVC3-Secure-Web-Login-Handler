package com.example.rsa
{
	
	/**
	 * ...
	 * @author Scott
	 */
	 
	public class RSA 
	{
		private var n:uint;
		private var e:uint;
		private var d:uint;
		
		private const blockSize:uint = 2;
		
		public function RSA(p:uint = 2, q:uint = 3, firste:uint = 2) 
		{
			this.recalculateKeys(p, q, firste);
		}
		
		protected function gcd(a:uint, b:uint):uint
		{
			while (b != 0)
			{
				var t:uint = b;
				b = a % b;
				a = t;
			}
			return a;
		}
		
		protected function extendedGcd(a:uint, b:uint):uint
		{
			if (a > b)
			{
				var temp:uint = b;
				b = a;
				a = temp;
			}
			
			var x:uint = 0;
			while ((a * x) % b != 1)
			{
				x++;
			}
			
			return x;
			
            ////algorithm from http://www.di-mgt.com.au/euclidean.html#code-modinv
			//var u:uint = a;
			//var v:uint = b;
			//var inv:uint;
			//var u1:uint;
			//var u3:uint;
			//var v1:uint;
			//var v3:uint;
			//var t1:uint;
			//var t3:uint;
			//var q:uint;
			//var iter:uint;
            ///* Step X1. Initialise */
            //u1 = 1;
            //u3 = u;
            //v1 = 0;
            //v3 = v;
            ///* Remember odd/even iterations */
            //iter = 1;
            ///* Step X2. Loop while v3 != 0 */
            //while (v3 != 0)
            //{
                ///* Step X3. Divide and "Subtract" */
                //q = u3 / v3;
                //t3 = u3 % v3;
                //t1 = u1 + q * v1;
                ///* Swap */
                //u1 = v1; v1 = t1; u3 = v3; v3 = t3;
                //iter = -iter;
            //}
            ///* Make sure u3 = gcd(u,v) == 1 */
            //if (u3 != 1)
                //return 0;   /* Error: No inverse exists */
            ///* Ensure a positive result */
            //if (iter < 0)
                //inv = v - u1;
            //else
                //inv = u1;
            //return inv;
		}
		
		protected function blockToUint(input:String):uint
		{
			var output:uint = 0;
			
			for (var i:int = 0; i < this.blockSize; i++)
			{
				output = (output * 1000) + input.charCodeAt(i);
			}
			
			return output;
		}
		
		protected function uintToBlock(input:uint):String
		{
			var output:String = "";
			
			for (var i:int = 0; i < this.blockSize; i++)
			{
				output = String.fromCharCode(input % 1000) + output;
				input = input / 1000;
			}
			
			return output;
		}

		protected function cBlockToUint(input:String):uint
		{
			return uint(input);
		}
		
		protected function cUintToBlock(input:uint):String
		{
			if (n > 1000000)
			{
				var output:String = input.toString();
				while (output.length < 7)
				{
					output = "0" + output;
				}
				
				return output;
			}
			else
			{
				var output:String = input.toString();
				while (output.length < 6)
				{
					output = "0" + output;
				}
				
				return output;
			}
		}
		
		public function encryptUint(M:uint):uint
		{
			//var part:uint = M;
			//
			//for (var i:uint = 1; i < e; i++)
			//{
				//part *= M;
				//part = part % n;
			//}
			//
			//return part;
			
			return BigInt.modInt(BigInt.powMod(BigInt.int2bigInt(M, 128, 0), BigInt.int2bigInt(e, 128, 0), BigInt.int2bigInt(n, 128, 0)), n);
			
			//return BigInt.modInt(BigInt.int2bigInt(M, 64, 0), n);
		}
		
		public function decryptUint(C:uint):uint
		{
			//var part:uint = C;
			//
			//for (var i:uint = 1; i < d; i++)
			//{
				//part *= C;
				//part = part % n;
			//}
			//
			//return part;
			
			return BigInt.modInt(BigInt.powMod(BigInt.int2bigInt(C, 128, 0), BigInt.int2bigInt(d, 128, 0), BigInt.int2bigInt(n, 128, 0)), n);
			
			//return BigInt.modInt(BigInt.int2bigInt(C, 64, 0), n);
		}
		
		public function recalculateKeys(p:uint = 2, q:uint = 3, firste:uint = 2):void
		{
			n = p * q;
			var Euler:uint = (p - 1) * (q - 1);
			
			e = firste;
			while (gcd(Euler, e) > 1)
			{
				e++;
			}
			
			d = extendedGcd(e, Euler);
		}
		
		public function setPublicKey(exponent:uint, modulus:uint):void
		{
			n = modulus;
			e = exponent % n;
		}
		
		public function setPrivateKey(exponent:uint, modulus:uint):void
		{
			n = modulus;
			d = exponent % n;
		}
		
		public function getPublicKey():uint
		{
			return e;
		}
		
		public function getPrivateKey():uint
		{
			return d;
		}
		
		public function getModulus():uint
		{
			return n;
		}
		
		public function encrypt(plaintext:String):String
		{
			while (plaintext.length % blockSize != 0)
			{
				plaintext += " ";
			}
			
			var blocks:int = plaintext.length / blockSize;
			var ciphertext:String = "";
			
			for (var i:int = 0; i < blocks; i++)
			{
				var block:String = plaintext.substr(i * blockSize, blockSize);
				
				var M:uint = blockToUint(block);
				
				var C:uint = encryptUint(M);
				
				ciphertext += cUintToBlock(C);
			}
			
			return ciphertext;
		}
		
		public function decrypt(ciphertext:String):String
		{
			var cblockSize:int = blockSize * 3;
			
			if (n > 1000000)
			{
				cblockSize++;
			}
			
			var blocks:int = ciphertext.length / blockSize;
			var plaintext:String = "";
			
			for (var i:int = 0; i < blocks; i++)
			{
				var block:String = ciphertext.substr(i * cblockSize, cblockSize);
				
				var C:uint = cBlockToUint(block);
				
				var M:uint = decryptUint(C);
				
				plaintext += uintToBlock(M);
			}
			
			return plaintext;
		}
	}
}

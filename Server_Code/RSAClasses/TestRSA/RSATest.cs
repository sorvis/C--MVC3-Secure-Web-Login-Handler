using RSAClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestRSA
{
    [TestClass()]
    public class RSATest : RSA
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void RSAConstructorTest()
        {
            RSA target = new RSA(5, 7);
            ulong expected = 2;
            Assert.AreEqual(expected, target.decryptUlong(target.encryptUlong(2)));
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void gcdTest()
        {
            ulong expected = 1;
            Assert.AreEqual(expected, gcd(4576, 17));
            Assert.AreEqual(expected, gcd(17, 4576));
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void extendedGcdTest()
        {
            ulong expected = 2961;
            Assert.AreEqual(expected, extendedGcd(17, 4576));
            Assert.AreEqual(expected, extendedGcd(4576, 17));
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void encryptUlongTest()
        {
            this.setPublicKey(17, 4717);
            ulong expected = 2983;
            ulong actual = this.encryptUlong(28);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void decryptUlongTest()
        {
            this.setPrivateKey(2961, 4717);
            ulong expected = 28;
            ulong actual = this.decryptUlong(2983);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void ulongEncryptionConsistencyTest()
        {
            this.recalculateKeys(Primes.getPrime(), Primes.getPrime());
            ulong message = 123456;
            ulong actual = this.decryptUlong(this.encryptUlong(message));
            Assert.AreEqual(message, actual);
        }

        [TestMethod()]
        public void recalculateKeysTest()
        {
            RSA target = new RSA();
            target.recalculateKeys(2146861501, 2146861517);
        }

        [TestMethod()]
        public void getPublicKeyTest()
        {
            RSA target = new RSA(53, 89, 16);

            ulong exponent = 0;
            ulong modulus = 0;
            target.getPublicKey(ref exponent, ref modulus);

            ulong exponentExpected = 17;
            ulong modulusExpected = 4717;
            Assert.AreEqual(exponentExpected, exponent);
            Assert.AreEqual(modulusExpected, modulus);
        }

        [TestMethod()]
        public void getPrivateKeyTest()
        {
            RSA target = new RSA(53, 89, 16);

            ulong exponent = 0;
            ulong modulus = 0;
            target.getPrivateKey(ref exponent, ref modulus);

            ulong exponentExpected = 2961;
            ulong modulusExpected = 4717;
            Assert.AreEqual(exponentExpected, exponent);
            Assert.AreEqual(modulusExpected, modulus);
            
            //Assert.AreEqual(2961, exponent);
            //Assert.AreEqual(4717, modulus);
        }

        [TestMethod()]
        public void setPublicKeyTest()
        {
            RSA target = new RSA();
            target.setPublicKey(13, 10);

            ulong exponentActual = 0;
            ulong modulusActual = 0;
            target.getPublicKey(ref exponentActual, ref modulusActual);

            ulong exponentExpected = 3;
            ulong modulusExpected = 10;
            Assert.AreEqual(exponentExpected, exponentActual);
            Assert.AreEqual(modulusExpected, modulusActual);
        }

        [TestMethod()]
        public void setPrivateKeyTest()
        {
            RSA target = new RSA();
            target.setPrivateKey(13, 10);
            
            ulong exponentActual = 0;
            ulong modulusActual = 0;
            target.getPrivateKey(ref exponentActual, ref modulusActual);

            ulong exponentExpected = 3;
            ulong modulusExpected = 10;
            Assert.AreEqual(exponentExpected, exponentActual);
            Assert.AreEqual(modulusExpected, modulusActual);
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void blockToUlongTest()
        {
            ulong expected = 102117;
            Assert.AreEqual(expected, blockToUlong("fu"));
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void ulongToBlockTest()
        {
            Assert.AreEqual("fu", ulongToBlock(102117));
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void ulongToBlockConsistencyTest()
        {
            string testmessage = ";";
            Random random = new Random();

            for (int i = 0; i < blockSize-1; i++)
            {
                testmessage += Convert.ToChar(random.Next(0, 255));
            }

            Assert.AreEqual(testmessage, ulongToBlock(blockToUlong(testmessage)));
            //Assert.AreEqual("  ", testmessage);
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void cBlockToUlongTest()
        {
            this.recalculateKeys(997, 1009);
            string ciphertext = "12345";
            ulong expected = 12345;
            ulong actual = this.cBlockToUlong(ciphertext);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("RSAClasses.dll")]
        public void cUlongToBlockTest()
        {
            this.recalculateKeys(997, 1009);
            ulong ciphertext = 12345;
            string expected = "0012345";
            string actual = this.cUlongToBlock(ciphertext);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void encryptTest()
        {
            RSA target = new RSA(997, 1009);
            string plaintext = "I had a fun time today.";
            string expected = "020574605831590890042003081208907080676758075536003944600637156066894402548070478377";
            string actual = target.encrypt(plaintext);
            Assert.AreEqual(expected, actual);
            //string fun = target.encrypt("1 He, that being often reproved hardeneth his neck, shall suddenly be destroyed, and that without remedy. 2 When the righteous are in authority, the people rejoice: but when the wicked beareth rule, the people mourn. 3 Whoso loveth wisdom rejoiceth his father: but he that keepeth company with harlots spendeth his substance. 4 The king by judgment establisheth the land: but he that receiveth gifts overthroweth it. 5 A man that flattereth his neighbour spreadeth a net for his feet. 6 In the transgression of an evil man there is a snare: but the righteous doth sing and rejoice.");
        }

        [TestMethod()]
        public void decryptTest()
        {
            RSA target = new RSA(997, 1009);
            string ciphertext = "020574605831590890042003081208907080676758075536003944600637156066894402548070478377";
            string expected = "I had a fun time today.";
            string actual = target.decrypt(ciphertext);
            Assert.AreEqual(expected, actual);
            //string fun = target.decrypt("1 He, that being often reproved hardeneth his neck, shall suddenly be destroyed, and that without remedy. 2 When the righteous are in authority, the people rejoice: but when the wicked beareth rule, the people mourn. 3 Whoso loveth wisdom rejoiceth his father: but he that keepeth company with harlots spendeth his substance. 4 The king by judgment establisheth the land: but he that receiveth gifts overthroweth it. 5 A man that flattereth his neighbour spreadeth a net for his feet. 6 In the transgression of an evil man there is a snare: but the righteous doth sing and rejoice.");
        }

        [TestMethod()]
        public void encryptionConsistencyTest()
        {
            RSA target = new RSA(Primes.getPrime(), Primes.getPrime());
            string message = "asd, goga;=_hh1 He, that being often reproved hardeneth his neck, shall suddenly be destroyed, and that without remedy. 2 When the righteous are in authority, the people rejoice: but when the wicked beareth rule, the people mourn. 3 Whoso loveth wisdom rejoiceth his father: but he that keepeth company with harlots spendeth his substance. 4 The king by judgment establisheth the land: but he that receiveth gifts overthroweth it. 5 A man that flattereth his neighbour spreadeth a net for his feet. 6 In the transgression of an evil man there is a snare: but the righteous doth sing and rejoice.";// 7 The righteous considereth the cause of the poor: but the wicked regardeth not to know it. 8 Scornful men bring a city into a snare: but wise men turn away wrath. 9 If a wise man contendeth with a foolish man, whether he rage or laugh, there is no rest. 10 The bloodthirsty hate the upright: but the just seek his soul. 11 A fool uttereth all his mind: but a wise man keepeth it in till afterwards. 12 If a ruler hearken to lies, all his servants are wicked. 13 The poor and the deceitful man meet together: the LORD lighteneth both their eyes. 14 The king that faithfully judgeth the poor, his throne shall be established for ever. 15 The rod and reproof give wisdom: but a child left to himself bringeth his mother to shame. 16 When the wicked are multiplied, transgression increaseth: but the righteous shall see their fall. 17 Correct thy son, and he shall give thee rest; yea, he shall give delight unto thy soul. 18 Where there is no vision, the people perish: but he that keepeth the law, happy is he. 19 A servant will not be corrected by words: for though he understand he will not answer. 20 Seest thou a man that is hasty in his words? there is more hope of a fool than of him. 21 He that delicately bringeth up his servant from a child shall have him become his son at the length. 22 An angry man stirreth up strife, and a furious man aboundeth in transgression. 23 A man's pride shall bring him low: but honour shall uphold the humble in spirit. 24 Whoso is partner with a thief hateth his own soul: he heareth cursing, and bewrayeth it not. 25 The fear of man bringeth a snare: but whoso putteth his trust in the LORD shall be safe. 26 Many seek the ruler's favour; but every man's judgment cometh from the LORD. 27 An unjust man is an abomination to the just: and he that is upright in the way is abomination to the wicked.";
            string actual = target.decrypt(target.encrypt(message));
            Assert.AreEqual(message.Length, actual.Length);
            Assert.AreEqual(message, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void randomInfoTest()
        {
            //string output = "";

            //for (int i = 0; i < 4; i++)
            //{
            //    output += "fun "[i] + ":" + Convert.ToInt64("fun "[i]) + "\n";
            //}

            //output = "1 He, that being often reproved hardeneth his neck, shall suddenly be destroyed, and that without remedy. 2 When the righteous are in authority, the people rejoice: but when the wicked beareth rule, the people mourn. 3 Whoso loveth wisdom rejoiceth his father: but he that keepeth company with harlots spendeth his substance. 4 The king by judgment establisheth the land: but he that receiveth gifts overthroweth it. 5 A man that flattereth his neighbour spreadeth a net for his feet. 6 In the transgression of an evil man there is a snare: but the righteous doth sing and rejoice.".Length.ToString();// 7 The righteous considereth the cause of the poor: but the wicked regardeth not to know it. 8 Scornful men bring a city into a snare: but wise men turn away wrath. 9 If a wise man contendeth with a foolish man, whether he rage or laugh, there is no rest. 10 The bloodthirsty hate the upright: but the just seek his soul. 11 A fool uttereth all his mind: but a wise man keepeth it in till afterwards. 12 If a ruler hearken to lies, all his servants are wicked. 13 The poor and the deceitful man meet together: the LORD lighteneth both their eyes. 14 The king that faithfully judgeth the poor, his throne shall be established for ever. 15 The rod and reproof give wisdom: but a child left to himself bringeth his mother to shame. 16 When the wicked are multiplied, transgression increaseth: but the righteous shall see their fall. 17 Correct thy son, and he shall give thee rest; yea, he shall give delight unto thy soul. 18 Where there is no vision, the people perish: but he that keepeth the law, happy is he. 19 A servant will not be corrected by words: for though he understand he will not answer. 20 Seest thou a man that is hasty in his words? there is more hope of a fool than of him. 21 He that delicately bringeth up his servant from a child shall have him become his son at the length. 22 An angry man stirreth up strife, and a furious man aboundeth in transgression. 23 A man's pride shall bring him low: but honour shall uphold the humble in spirit. 24 Whoso is partner with a thief hateth his own soul: he heareth cursing, and bewrayeth it not. 25 The fear of man bringeth a snare: but whoso putteth his trust in the LORD shall be safe. 26 Many seek the ruler's favour; but every man's judgment cometh from the LORD. 27 An unjust man is an abomination to the just: and he that is upright in the way is abomination to the wicked.".Length.ToString();

            //System.Windows.Forms.MessageBox.Show(output);

            RSA fun = new RSA(1301, 1061);

            ulong a = 0;
            ulong b = 0;
            ulong c = 0;

            fun.getPublicKey(ref a, ref c);
            fun.getPrivateKey(ref b, ref c);

            //System.Windows.Forms.MessageBox.Show("Pub:"+a.ToString()+"\nPriv:"+b.ToString()+"\nMod:"+c.ToString());
        }
    }
}

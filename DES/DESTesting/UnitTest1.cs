﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DES.Model;

namespace DESTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CipherHexTest()
        {
            string M = "0123456789ABCDEF";
            string key = "133457799BBCDFF1";
            var test = new DESClass();
            test.Plaintext = M;
            test.Key = key;
            test.CipherHex(16);

            Assert.AreEqual("85E813540F0AB405", test.Ciphertext, true);
        }

        [TestMethod]
        public void DecipherHexTest()
        {
            string M = "85E813540F0AB405";
            string key = "133457799BBCDFF1";
            var test = new DESClass();
            test.Ciphertext = M;
            test.Key = key;
            test.DecipherHex(16);

            Assert.AreEqual("0123456789ABCDEF", test.Plaintext, true);
        }

        [TestMethod]
        public void AllAroundHexTest()
        {
            string M = "";
            string key = "";
            char[] possible = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            Random random = new Random();

            int posicion;
            for (var j = 0; j < 16; j++)
            {
                posicion = random.Next(16);
                M += possible[posicion];
                posicion = random.Next(16);
                key += possible[posicion];
            }
            var cipher = new DESClass();
            cipher.Plaintext = M;
            cipher.Key = key;
            cipher.CipherHex(16);

            var decipher = new DESClass();
            decipher.Ciphertext = cipher.Ciphertext;
            decipher.Key = key;
            decipher.DecipherHex(16);

            Assert.AreEqual(M, decipher.Plaintext, true);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DES.Model;

namespace DESTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string M = "0123456789ABCDEF";
            string key = "133457799BBCDFF1";
            var test = new DESClass();
            test.Plaintext = M;
            test.Key = key;
            test.CipherHex(16);

            Assert.AreEqual("85E813540F0AB405", test.Ciphertext, true);
            int a = 0;
        }
    }
}

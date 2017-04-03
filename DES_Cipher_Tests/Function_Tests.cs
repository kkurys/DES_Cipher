using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DES_Cipher_Logic;

namespace DES_Cipher_Tests
{
    [TestClass]
    public class Function_Tests
    {
        [TestMethod]
        public void Function_EBitSelection_Works()
        {
            Function f = new Function();

            string result = f.ExtendBits("11110000101010101111000010101010");

            Assert.AreEqual("011110100001010101010101011110100001010101010101", result);
        }

        [TestMethod]
        public void Function_Xor_Works()
        {
            Function f = new Function();

            string result = f.Xor("011110100001010101010101011110100001010101010101", "000110110000001011101111111111000111000001110010");

            Assert.AreEqual("011000010001011110111010100001100110010100100111", result);
        }

        [TestMethod]
        public void Function_ParseFor6bit_Works()
        {
            Function f = new Function();
            string[] result = f.ParseFor6bit("011000010001011110111010100001100110010100100111");
            string[] expected = new string[8]
            {
                "011000",
                "010001",
                "011110",
                "111010",
                "100001",
                "100110",
                "010100",
                "100111"
            };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}

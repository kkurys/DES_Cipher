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

        [TestMethod]
        public void Function_MergeStrings_Works()
        {
            Function f = new Function();
            string[] toMerge = new string[8]
            {
                "0101",
                "1100",
                "1000",
                "0010",
                "1011",
                "0101",
                "1001",
                "0111",
            };
            string result = f.MergeStrings(toMerge);

            Assert.AreEqual("01011100100000101011010110010111", result);
        }

        [TestMethod]
        public void Function_BinToDec_Works()
        {
            Function f = new Function();
            int result = f.BinToDec("0000");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Function_BinToDec1_Works()
        {
            Function f = new Function();
            int result = f.BinToDec("1100");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Function_DecToBin_Works()
        {
            Function f = new Function();
            string result = f.DecToBin(5);

            Assert.AreEqual("0101", result);
        }
        [TestMethod]
        public void Function_DecToBin1_Works()
        {
            Function f = new Function();
            string result = f.DecToBin(2);

            Assert.AreEqual("0010", result);
        }
        [TestMethod]
        public void Function_DecToBin2_Works()
        {
            Function f = new Function();
            string result = f.DecToBin(1);

            Assert.AreEqual("0001", result);
        }

        [TestMethod]
        public void Function_GetRow_Works()
        {
            Function f = new Function();
            int result = f.GetRow("011000");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Function_GetCol_Works()
        {
            Function f = new Function();
            int result = f.GetCol("011000");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Function_GetSNumber_Works()
        {
            Function f = new Function();
            int result = f.GetSNumber(0, 0, 12);

            Assert.AreEqual(5, result); 
        }


        [TestMethod]
        public void Function_PrimitiveFunctions_Works()
        {
            Function f = new Function();
            string result = f.PrimitiveFunctions("011000010001011110111010100001100110010100100111");

            Assert.AreEqual("01011100100000101011010110010111", result);
        }

        [TestMethod]
        public void Function_PFunction_Works()
        {
            Function f = new Function();
            string result = f.PFunction("01011100100000101011010110010111");

            Assert.AreEqual("00100011010010101010100110111011", result);
        }
    }
}

﻿using DES_Cipher_Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DES_Cipher_Tests
{
    [TestClass]
    public class KeyGeneratorTests
    {
        [TestMethod]
        public void LeftShiftWorks()
        {
            KeyGenerator _keyGen = new KeyGenerator();
            var result = _keyGen.LeftShift("ABCD", 1);
            Assert.AreEqual("BCDA", result);
            result = _keyGen.LeftShift("BBBDDD", 4);
            Assert.AreEqual("DDBBBD", result);
        }
        [TestMethod]
        public void StringIsEquallySplit()
        {
            KeyGenerator _keyGen = new KeyGenerator();
            string C = "", D = "";
            _keyGen.SplitString("11111111000000000111100001010101000000000000000010000000", ref C, ref D);
            Assert.AreEqual(28, C.Length);
            Assert.AreEqual(28, D.Length);
            Assert.AreEqual("1111111100000000011110000101", C);
            Assert.AreEqual("0101000000000000000010000000", D);
        }
        [TestMethod]
        public void KeyGeneratorWorks()
        {
            KeyGenerator _keyGen = new KeyGenerator();
            var result = _keyGen.GenerateKeys("0001001100110100010101110111100110011011101111001101111111110001");
            var keys = new string[16]
            {
                "000110110000001011101111111111000111000001110010",
                "011110011010111011011001110110111100100111100101",
                "010101011111110010001010010000101100111110011001",
                "011100101010110111010110110110110011010100011101",
                "011111001110110000000111111010110101001110101000",
                "011000111010010100111110010100000111101100101111",
                "111011001000010010110111111101100001100010111100",
                "111101111000101000111010110000010011101111111011",
                "111000001101101111101011111011011110011110000001",
                "101100011111001101000111101110100100011001001111",
                "001000010101111111010011110111101101001110000110",
                "011101010111000111110101100101000110011111101001",
                "100101111100010111010001111110101011101001000001",
                "010111110100001110110111111100101110011100111010",
                "101111111001000110001101001111010011111100001010",
                "110010110011110110001011000011100001011111110101"
            };
            CollectionAssert.AreEqual(keys, result);
        }
    }
}

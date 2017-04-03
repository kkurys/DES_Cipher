using DES_Cipher_Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DES_Cipher_Tests
{
    [TestClass]
    public class InitialPermutationTests
    {
        [TestMethod]
        public void InitialPermutationWorks()
        {
            InitialPermutation _IP = new InitialPermutation();

            var result = _IP.Permutate("ABCDEFGH");
            Assert.AreEqual(64, result.Length);
            Assert.AreEqual("1111111100000000011110000101010100000000000000001000000001100110", result);
        }
        [TestMethod]
        public void WordToBytesWorks()
        {
            InitialPermutation _IP = new InitialPermutation();

            var result = _IP.WordToBytes("AB");

            Assert.AreEqual("0100000101000010", result);

            result = _IP.WordToBytes("ABCDEFGH");
            Assert.AreEqual("0100000101000010010000110100010001000101010001100100011101001000", result);
        }
    }
}

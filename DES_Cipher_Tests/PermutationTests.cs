using DES_Cipher_Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DES_Cipher_Tests
{
    [TestClass]
    public class PermutationTests
    {
        [TestMethod]
        public void InitialPermutationWorks()
        {
            Permutations _p = new Permutations();

            var result = _p.InitialPermutation(_p.WordToBytes("ABCDEFGH"));
            Assert.AreEqual(64, result.Length);
            Assert.AreEqual("1111111100000000011110000101010100000000000000001000000001100110", result);
        }
        [TestMethod]
        public void FinalPermutationWorks()
        {
            Permutations _p = new Permutations();

            var result = _p.FinalPermutation("1111111100000000011110000101010100000000000000001000000001100110");

            Assert.AreEqual("0100000101000010010000110100010001000101010001100100011101001000", result);

        }
        [TestMethod]
        public void WordToBytesWorks()
        {
            Permutations _p = new Permutations();

            var result = _p.WordToBytes("AB");

            Assert.AreEqual("0100000101000010", result);

            result = _p.WordToBytes("ABCDEFGH");
            Assert.AreEqual("0100000101000010010000110100010001000101010001100100011101001000", result);
        }
    }
}

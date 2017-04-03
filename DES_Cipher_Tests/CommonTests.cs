using DES_Cipher_Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DES_Cipher_Tests
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        public void StringIsEquallySplit()
        {
            string C = "", D = "";
            Common.SplitString("11111111000000000111100001010101000000000000000010000000", ref C, ref D);
            Assert.AreEqual(28, C.Length);
            Assert.AreEqual(28, D.Length);
            Assert.AreEqual("1111111100000000011110000101", C);
            Assert.AreEqual("0101000000000000000010000000", D);
        }
        [TestMethod]
        public void WordToBytesFromASCIIWorks()
        {
            var result = Common.WordToBytesFromASCII("AB");

            Assert.AreEqual("0100000101000010", result);

            result = Common.WordToBytesFromASCII("ABCDEFGH");
            Assert.AreEqual("0100000101000010010000110100010001000101010001100100011101001000", result);
        }
        [TestMethod]
        public void WordToBytesFromHEXWorks()
        {
            var result = Common.WordToBytesFromHEX("AB");

            Assert.AreEqual("0000000000000000000000000000000000000000000000000000000010101011", result);

            result = Common.WordToBytesFromHEX("1F");
            Assert.AreEqual("0000000000000000000000000000000000000000000000000000000000011111", result);
        }
        [TestMethod]
        public void BytesToHEXWorks()
        {
            var result = Common.BytesToHEX("1010");
            Assert.AreEqual("A", result);

            result = Common.BytesToHEX("000110100001");
            Assert.AreEqual("1A1", result);
        }
    }
}

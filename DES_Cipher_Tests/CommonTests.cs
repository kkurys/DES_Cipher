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
        public void WordToBytesWorks()
        {
            var result = Common.WordToBytes("AB");

            Assert.AreEqual("0100000101000010", result);

            result = Common.WordToBytes("ABCDEFGH");
            Assert.AreEqual("0100000101000010010000110100010001000101010001100100011101001000", result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace DES_Cipher_Logic
{
    public static class Common
    {
        public static void SplitString(string _key, ref string L, ref string R)
        {
            L = _key.Substring(0, _key.Length / 2);
            R = _key.Substring(_key.Length / 2);
        }
        public static string WordToBytesFromASCII(string _word)
        {
            string _bytes = "";
            for (int i = 0; i < _word.Length; i++)
            {
                _bytes += Convert.ToString(_word[i], 2).PadLeft(8, '0');
            }
            return _bytes;
        }
        public static string WordToBytesFromHEX(string _word)
        {
            string _bytes = "";

            _bytes += Convert.ToString(Convert.ToInt64(_word, 16), 2).PadLeft(64, '0');

            return _bytes;
        }
        public static string BytesToHEX(string _wordInBytes)
        {
            string _word = "";

            for (int i = 0; i < _wordInBytes.Length; i += 4)
            {
                _word += Convert.ToString(Convert.ToInt32(_wordInBytes.Substring(i, 4), 2), 16);
            }

            return _word.ToUpper();
        }
        public static string ExtendBlockTo64bit(string _toExtend)
        {
            while (_toExtend.Length < 64)
            {
                _toExtend += '0';
            }
            return _toExtend;
        }

        public static string[] ReadBlocksFromFile(string _fileName)
        {
            byte[] fileBytes = File.ReadAllBytes(_fileName);
            List<string> blocks = new List<string>();
            int count = 0, extendNumber = 0;
            string block64bit = "";

            foreach (byte b in fileBytes)
            {
                block64bit += Convert.ToString(b, 2).PadLeft(8, '0');
                count++;
                if (count == 8)
                {
                    if (block64bit.Length < 64)
                    {
                        extendNumber = 64 - block64bit.Length;
                        block64bit = ExtendBlockTo64bit(block64bit);
                    }
                    blocks.Add(block64bit);
                    block64bit = "";
                    count = 0;
                }
            }

            blocks.Add(DecToBin(extendNumber, 64));

            return blocks.ToArray();
        }

        public static void WriteBlocksToFile(string _fileName, string[] _blocks)
        {
            List<byte> byteList = new List<byte>();

            int extendNumber = BinToDec(_blocks[_blocks.Length - 1]);

            for (int i = 0; i < _blocks.Length - 1; i++)
            {
                string block64bit = _blocks[i];
                string byteStr = "";
                int count = 0;
                if (i == _blocks.Length - 2)
                {
                    for (int j = 0; j < block64bit.Length - extendNumber; j++)
                    {
                        byteStr += block64bit[j];
                        count++;
                        if (count == 8)
                        {
                            byteList.Add(Convert.ToByte(byteStr, 2));
                            byteStr = "";
                            count = 0;
                        }
                    }
                }
                else
                {
                    foreach (char c in block64bit)
                    {
                        byteStr += c;
                        count++;
                        if (count == 8)
                        {
                            byteList.Add(Convert.ToByte(byteStr, 2));
                            byteStr = "";
                            count = 0;
                        }
                    }
                }
            }

            File.WriteAllBytes(_fileName, byteList.ToArray());
        }

        public static string DecToBin(int dec, int numberOfBits)
        {
            string bin = Convert.ToString(dec, 2);
            while (bin.Length < numberOfBits)
            {
                bin = "0" + bin;
            }
            return bin;
        }

        public static int BinToDec(string bin)
        {
            int dec = Convert.ToInt32(bin, 2);
            return dec;
        }
    }
}

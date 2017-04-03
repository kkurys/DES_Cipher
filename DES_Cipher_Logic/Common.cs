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
        public static string WordToBytes(string _word)
        {
            string _bytes = "";
            for (int i = 0; i < _word.Length; i++)
            {
                _bytes += Convert.ToString(_word[i], 2).PadLeft(8, '0');
            }
            return _bytes;

        }

        public static string[] ReadBlocksFromFile(string _fileName)
        {
            byte[] fileBytes = File.ReadAllBytes(_fileName);
            List<string> blocks = new List<string>();
            int count = 0;
            string block64bit = "";

            foreach (byte b in fileBytes)
            {
                block64bit += Convert.ToString(b, 2).PadLeft(8, '0');
                count++;
                if (count == 8)
                {
                    blocks.Add(block64bit);
                    block64bit = "";
                    count = 0;
                }
            }

            return blocks.ToArray();
        }
    }
}

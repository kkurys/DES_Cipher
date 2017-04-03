using System;

namespace DES_Cipher_Logic
{
    public class InitialPermutation
    {
        private int[] _initialKeyPermutaion =
                               {57, 49, 41, 33, 25, 17, 9, 1,
                                59, 51, 43, 35, 27, 19, 11, 3,
                                61, 53, 45, 37, 29, 21, 13, 5,
                                63, 55, 47, 39, 31, 23, 15, 7,
                                56, 48, 40, 32, 24, 16, 8, 0,
                                58, 50, 42, 34, 26, 18, 10, 2,
                                60, 52, 44, 36, 28, 20, 12, 4,
                                62, 54, 46, 38, 30, 22, 14, 6};
        public string Permutate(string _word)
        {
            string _wordInBytes = WordToBytes(_word);
            string _result = "";
            for (int i = 0; i < 64; i++)
            {
                _result += _wordInBytes[_initialKeyPermutaion[i]];
            }

            return _result;
        }
        public string WordToBytes(string _word)
        {
            string _bytes = "";
            for (int i = 0; i < _word.Length; i++)
            {
                _bytes += Convert.ToString(_word[i], 2).PadLeft(8, '0');
            }
            return _bytes;

        }
    }
}

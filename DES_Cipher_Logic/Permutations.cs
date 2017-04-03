using System;

namespace DES_Cipher_Logic
{
    public class Permutations
    {
        private int[] _initialKeyPermutation =
                               {57, 49, 41, 33, 25, 17, 9, 1,
                                59, 51, 43, 35, 27, 19, 11, 3,
                                61, 53, 45, 37, 29, 21, 13, 5,
                                63, 55, 47, 39, 31, 23, 15, 7,
                                56, 48, 40, 32, 24, 16, 8, 0,
                                58, 50, 42, 34, 26, 18, 10, 2,
                                60, 52, 44, 36, 28, 20, 12, 4,
                                62, 54, 46, 38, 30, 22, 14, 6};
        private int[] _finalKeyPermutation =
                                {39, 7, 47, 15, 55, 23, 63, 31,
                                 38, 6, 46, 14, 54, 22, 62, 30,
                                 37, 5, 45, 13, 53, 21, 61, 29,
                                 36, 4, 44, 12, 52, 20, 60, 28,
                                 35, 3, 43, 11, 51, 19, 59, 27,
                                 34, 2, 42, 10, 50, 18, 58, 26,
                                 33, 1, 41, 9, 49, 17, 57, 25,
                                 32, 0, 40, 8, 48, 16, 56, 24};
        private int[] _permutedChoice1 =
                                {56, 48, 40, 32, 24, 16, 8,
                                 0, 57, 49, 41, 33, 25, 17,
                                 9, 1, 58, 50, 42, 34, 26,
                                 18, 10, 2, 59, 51, 43, 35,
                                 62, 54, 46, 38, 30, 22, 14,
                                 6, 61, 53, 45, 37, 29, 21,
                                 13, 5, 60, 52, 44, 36, 28,
                                 20, 12, 4, 27, 19, 11, 3};
        private int[] _permutedChoice2 =
                                {13, 16, 10, 23, 0, 4,
                                 2, 27, 14, 5, 20, 9,
                                 22, 18, 11, 3, 25, 7,
                                 15, 6, 26, 19, 12, 1,
                                 40, 51, 30, 36, 46, 54,
                                 29, 39, 50, 44, 32, 47,
                                 43, 48, 38, 55, 33, 52,
                                 45, 41, 49, 35, 28, 31};


        public string InitialPermutation(string _wordInBytes)
        {
            string _result = "";
            for (int i = 0; i < 64; i++)
            {
                _result += _wordInBytes[_initialKeyPermutation[i]];
            }

            return _result;
        }
        public string FinalPermutation(string _wordInBytes)
        {
            string _result = "";
            for (int i = 0; i < 64; i++)
            {
                _result += _wordInBytes[_finalKeyPermutation[i]];
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
        public string FirstChoicePermutation(string _key)
        {
            string _result = "";
            for (int i = 0; i < 56; i++)
            {
                _result += _key[_permutedChoice1[i]];
            }
            return _result;
        }
        public string SecondChoicePermutation(string _key)
        {
            string _result = "";
            for (int i = 0; i < 48; i++)
            {
                _result += _key[_permutedChoice2[i]];
            }
            return _result;
        }
    }
}

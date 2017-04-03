namespace DES_Cipher_Logic
{
    public class Permutations
    {
        public string InitialPermutation(string _wordInBytes)
        {
            string _result = "";
            for (int i = 0; i < 64; i++)
            {
                _result += _wordInBytes[Tables.InitialKeyPermutation[i]];
            }

            return _result;
        }
        public string FinalPermutation(string _wordInBytes)
        {
            string _result = "";
            for (int i = 0; i < 64; i++)
            {
                _result += _wordInBytes[Tables.FinalKeyPermutation[i]];
            }

            return _result;
        }
        public string FirstChoicePermutation(string _key)
        {
            string _result = "";
            for (int i = 0; i < 56; i++)
            {
                _result += _key[Tables.PermutedChoice1[i]];
            }
            return _result;
        }
        public string SecondChoicePermutation(string _key)
        {
            string _result = "";
            for (int i = 0; i < 48; i++)
            {
                _result += _key[Tables.PermutedChoice2[i]];
            }
            return _result;
        }
    }
}

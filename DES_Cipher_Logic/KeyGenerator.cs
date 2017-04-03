namespace DES_Cipher_Logic
{
    public class KeyGenerator
    {
        Permutations _p;
        public KeyGenerator()
        {
            _p = new Permutations();
        }
        public string[] GenerateKeys(string _key)
        {
            string[] _keys = new string[16];

            _key = _p.FirstChoicePermutation(_key);

            string C = "", D = "";
            Common.SplitString(_key, ref C, ref D);
            for (int i = 0; i < 16; i++)
            {
                if (i == 0 || i == 1 || i == 8 || i == 15)
                {
                    C = LeftShift(C, 1);
                    D = LeftShift(D, 1);
                }
                else
                {
                    C = LeftShift(C, 2);
                    D = LeftShift(D, 2);
                }
                _keys[i] = _p.SecondChoicePermutation(C + D);
            }

            return _keys;
        }
        public string LeftShift(string _word, int N)
        {
            string _result = "";

            _result += _word.Substring(N) + _word.Substring(0, N);

            return _result;
        }

    }
}

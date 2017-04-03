namespace DES_Cipher_Logic
{
    public class DES_Cipher
    {
        private Function _functions;
        private KeyGenerator _keyGen;
        private Permutations _permutations;
        public DES_Cipher()
        {
            _functions = new Function();
            _keyGen = new KeyGenerator();
            _permutations = new Permutations();
        }
        public string Encrypt(string _input, string _key)
        {
            var _keys = _keyGen.GenerateKeys(_key);
            var _result = _permutations.InitialPermutation(_input);

            string PrevLeft = "", PrevRight = "";
            Common.SplitString(_result, ref PrevLeft, ref PrevRight);
            string L, R;
            for (int i = 0; i < 15; i++)
            {
                L = PrevRight;
                R = _functions.Xor(PrevLeft, _functions.GetFunctionResult(PrevRight, _keys[i]));

                PrevLeft = L;
                PrevRight = R;
            }

            R = _functions.Xor(PrevLeft, _functions.GetFunctionResult(PrevRight, _keys[15]));
            L = PrevRight;

            _result = _permutations.FinalPermutation(R + L);
            return _result;
        }
        public string Decrypt(string _input, string _key)
        {
            var _keys = _keyGen.GenerateKeys(_key);
            var _result = _permutations.InitialPermutation(_input);

            string PrevLeft = "", PrevRight = "";
            Common.SplitString(_result, ref PrevLeft, ref PrevRight);
            string L, R;
            for (int i = 15; i > 0; i--)
            {
                L = PrevRight;
                R = _functions.Xor(PrevLeft, _functions.GetFunctionResult(PrevRight, _keys[i]));

                PrevLeft = L;
                PrevRight = R;
            }

            R = _functions.Xor(PrevLeft, _functions.GetFunctionResult(PrevRight, _keys[0]));
            L = PrevRight;

            _result = _permutations.FinalPermutation(R + L);
            return _result;
        }
    }
}

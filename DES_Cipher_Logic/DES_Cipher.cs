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
        public string Compute(string _input, string _key)
        {
            var _keys = _keyGen.GenerateKeys(_key);
            var _result = _permutations.InitialPermutation(_input);

            string Left = "", Right = "";

            Common.SplitString(_result, ref Left, ref Right);


            return _result;
        }
    }
}

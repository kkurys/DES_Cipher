using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES_Cipher_Logic
{
    public class Function : Constans
    {

        public string ExtendBits(string inBits)
        {
            string outBits = "";
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    outBits += inBits[EBitSelection[i, j] - 1];
                }
            }

            return outBits;
        }

        public string Xor(string input, string key)
        {
            string result = "";

            if (input.Length != key.Length)
            {
                return null;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] == '0' && key[i] == '0') || (input[i] == '1' && key[i] == '1'))
                {
                    result += '0';
                }
                else
                {
                    result += '1';
                }
            }

            return result;
        }

        public string[] ParseFor6bit(string input)
        {
            string[] output = new string[8];
            int byteNumber = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 6 == 0)
                {
                    byteNumber++;
                }

                output[byteNumber] += input[i];
            }

            return output;
        }
    }
}

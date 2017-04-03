using System;

namespace DES_Cipher_Logic
{
    public class Function
    {

        public string ExtendBits(string inBits)
        {
            string outBits = "";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    outBits += inBits[Tables.EBitSelection[i, j] - 1];
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

            if (input.Length != 48)
            {
                return null;
            }

            for (int i = 0; i < 48; i++)
            {
                if (i != 0 && i % 6 == 0)
                {
                    byteNumber++;
                }
                output[byteNumber] += input[i];
            }

            return output;
        }

        public string MergeStrings(string[] input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += input[i];
            }

            return result;
        }

        public int BinToDec(string bin)
        {
            int dec = Convert.ToInt32(bin, 2);
            return dec;
        }

        public string DecToBin(int dec)
        {
            string bin = Convert.ToString(dec, 2);
            while (bin.Length < 4)
            {
                bin = "0" + bin;
            }
            return bin;
        }

        public int GetRow(string byteStr)
        {
            string result = "";
            result += byteStr[0];
            result += byteStr[5];

            return BinToDec(result);
        }
        public int GetCol(string byteStr)
        {
            string result = "";
            result += byteStr[1];
            result += byteStr[2];
            result += byteStr[3];
            result += byteStr[4];

            return BinToDec(result);
        }

        public int GetSNumber(int sBlock, int row, int col)
        {
            int[,] currS;

            if (sBlock == 0) currS = Tables.S1;
            else if (sBlock == 1) currS = Tables.S2;
            else if (sBlock == 2) currS = Tables.S3;
            else if (sBlock == 3) currS = Tables.S4;
            else if (sBlock == 4) currS = Tables.S5;
            else if (sBlock == 5) currS = Tables.S6;
            else if (sBlock == 6) currS = Tables.S7;
            else currS = Tables.S8;

            return currS[row, col];
        }

        public string PrimitiveFunctions(string input)
        {
            string[] inputBytes = ParseFor6bit(input);
            string[] result = new string[8];

            for (int i = 0; i < 8; i++)
            {
                string byteStr = inputBytes[i];

                int row = GetRow(byteStr);
                int col = GetCol(byteStr);

                result[i] = DecToBin(GetSNumber(i, row, col));
            }

            return MergeStrings(result);
        }

        public string PFunction(string input)
        {
            string result = "";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result += input[Tables.PTable[i, j] - 1];
                }
            }

            return result;
        }
    }
}

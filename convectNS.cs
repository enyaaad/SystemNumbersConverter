using System;
using System.Linq;
using System.Collections.Generic;

namespace ConvertSN
{
    public static class ConvertNS
    {
        public static Exception OutOfSystem = new Exception("out of system exception");
        public static Exception EmptyString = new Exception("empty string");
        private static string _str;
        private static string _temps;

        private static char IntToChar(int a)
        {
            //numbers - целочисленное значение числа
            if (a <= 9) return (char)(a + '0');
            else return (char)(a + 55);
        }
        private static int CharToInt(char a)
        {
            if (a >= '0' && a <= '9') return a - '0';
            else
            {
                if (a >= 'A' && a <= 'Z') return a - 'A' + 10;
                else return 100000;
            }
        }
            
        private static char TranslateToMoreSystems(char number)
        {
            //Словарь латинского алфавита
            Dictionary<char, int> dictionaryOfNumbers = new Dictionary<char, int>(26) {
                {'A', 10}, {'B', 11}, {'C', 12}, {'D', 13}, {'E', 14}, {'F', 15}, {'G', 16}, {'H', 17}, {'I', 18},
                {'J', 19}, {'K', 20}, {'L', 21}, {'M', 22}, {'N', 23}, {'O', 24}, {'P', 25}, {'Q', 26}, {'R', 27},
                {'S', 28}, {'T', 29}, {'U', 30}, {'V', 31}, {'W', 32}, {'X', 33}, {'Y', 34}, {'Z', 35}
            };
            //Словарь чисел
            Dictionary<int, char> dictionaryOfSymbols = new Dictionary<int, char>(26) {
                {10, 'A'}, {11, 'B'}, {12, 'C'}, {13, 'D'}, {14, 'E'}, {15, 'F'}, {16, 'G'}, {17, 'H'}, {18, 'I'},
                {19, 'J'}, {20, 'K'}, {21, 'L'}, {22, 'M'}, {23, 'N'}, {24, 'O'}, {25, 'P'}, {26, 'Q'}, {27, 'R'},
                {28, 'S'}, {29, 'T'}, {30, 'U'}, {31, 'V'}, {32, 'W'}, {33, 'X'}, {34, 'Y'}, {35, 'Z'}
            };

            bool isCheckSymbol = false; //Проверяет, является ли введённое значение буквой
            if (number >= 'A' && number <= 'Z' )
            {
                isCheckSymbol = true;
            }
            else
            {              
                isCheckSymbol = false;
            }
            if(number < '9')
			{
                number = IntToChar(Convert.ToInt32(number));
                return number;
			}
            if (isCheckSymbol == false) return dictionaryOfSymbols[CharToInt(number)];
            else return IntToChar(dictionaryOfNumbers[number]);
        }

        private static string Whole_number(int currentns, int futurens)
        {
            string ex = "";
			int tempi = 0;

			for (int i = 0; i < _str.Length && _str[i] != '.'; ++i) _temps += _str[i]; 
            for (int i = 0; i < _str.Length && _str[i] != '.'; ++i)
			{
                if (_str[i] > 9) _temps = TranslateToMoreSystems(_str[i]).ToString();
			} 

            
        tempi = _temps.Aggregate(tempi, (current, t) => current * currentns + CharToInt(t));

            if (tempi == 0) Console.WriteLine("0");
            else
                while (tempi != 0)
                {
                    ex = Convert.ToString(tempi % futurens) + ex;
                    tempi /= futurens;
                }

            return ex;
        }

        private static string D_number(int currentns, int futurens)
        {
            string ex;
            double tempd = 0;
            ex = _temps;
            _temps = "";
            for (int i = ex.Length + 1; i < _str.Length; ++i) _temps += _str[i]; 
            if (_temps.Length > 0)
            {
                ex = "";
                for (int i = _temps.Length - 1; i >= 0; --i) tempd = (CharToInt(_temps[i]) + tempd) / currentns;
                while (tempd > 0)
                {
                    tempd *= futurens;
                    ex += Convert.ToString(Math.Round(tempd, MidpointRounding.AwayFromZero));
                    tempd -= Math.Round(tempd, MidpointRounding.AwayFromZero);
                }
            }

            return ex;
        }

        public static string Converting(int fromNs, int toNs, string numberS)
        {
            _str = numberS;
            if (numberS == "" || numberS == " ") throw EmptyString;                               
            if (fromNs < 2 || fromNs > 36 || toNs < 2 || toNs > 36) throw OutOfSystem;
            

            int a = 0;

            foreach (char t in _str)
                if (t == '.')
                    a = 1;
            if (a == 1)

                return Whole_number(fromNs, toNs) + "." + D_number(fromNs, toNs);
            return Whole_number(fromNs, toNs);
        }
    }
}
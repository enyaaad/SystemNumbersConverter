using System;
using System.Linq;


namespace ConvertSN
{
    public static class ConvertNS
    {
        public static Exception OutOfSystem = new Exception("out of system exception");
        public static Exception EmptyString = new Exception("empty string");
		public static Exception wrongSymbolException = new Exception("Wrong symbol exception!");
		public delegate void ShowMessage(string msg);
        public static event ShowMessage Notify;
        private static string _str;
        private static string _temps;

        public static int CharToInt(char a)
        {
            if ((a >= '0') && (a <= '9')) return a - '0';   //Цифры
            if ((a >= 'A') && (a <= 'Z')) return a - 'A' + 10;  //Англ ^
            if ((a >= 'a') && (a <= 'z')) return a - 'a' + 10;  //Англ
            if (a == '.' || a == ',') return 0;
            return 33;
        }
        public static char IntToChar(int a)
        {
            if ((a >= 0) && (a < 10)) return (char)(a + '0');
            return (char)(a + 'A' - 10);
        }

        public static string Converting(int fromNs, int toNs, string numberS)
        {
			_str = numberS;
            string ans = "";
            string temps = "", exstr = "", rrr;
            int tempi = 0;
			double tempd = 0.0;
            int xd;
			if (numberS == "" || numberS == " ") throw EmptyString;
            if (fromNs < 2 || fromNs > 36 || toNs < 2 || toNs > 36) throw OutOfSystem;
            else
            {
                for (int i = 0; i < numberS.Length && _str[i] != '.' && _str[i] != ','; i++)
                {
                        temps = temps + _str[i];
                        tempi = tempi * fromNs + CharToInt(temps[i]);
                                   
				}
				if (tempi == 0) rrr = "0";
                else
                {
                    while (tempi != 0)
                    {
                        exstr = IntToChar(tempi % toNs) + exstr;
                        tempi = tempi / toNs;
                    }
                    rrr = exstr;
                }

                exstr = temps;
                temps = "";
                for (int i = exstr.Length + 1; i < numberS.Length; ++i)
				{
					temps = temps + _str[i];
					if (CharToInt(numberS[i]) >= fromNs) throw wrongSymbolException;
				}
				if (temps.Length > 0)
				{
					exstr = "";
					for (int i = temps.Length - 1; i >= 0; --i) tempd = (CharToInt(temps[i]) + tempd) / fromNs;
					while (Math.Truncate(tempd) > 0) tempd = tempd * 0.1;
					while (tempd > 0)
					{
						tempd = tempd * toNs;
						exstr = exstr + IntToChar((int)Math.Truncate(tempd));
						tempd = tempd - Math.Truncate(tempd);
					}
					ans = rrr + "." + exstr;
				}
                else
					ans = rrr;
                    
            }
            return ans;
        }
    }
}
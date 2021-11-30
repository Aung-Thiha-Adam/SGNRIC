using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SGNRIC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(true));
            Console.WriteLine(generateNRIC(false));
            Console.WriteLine(generateNRIC(false));
            Console.WriteLine(generateNRIC(false));
            Console.WriteLine(generateNRIC(false));
            Console.WriteLine(generateNRIC(false));
            Console.WriteLine(generateNRIC(false));
            Console.WriteLine(generateNRIC(false));
            Console.ReadLine();


        }

        private static  Random rnd = new Random();

        private static string generateNRIC(bool isNRIC)
        {

            string nric = "";
            
            char[] prefixST = { 'S', 'T' };
            char[] prefixFG = { 'F', 'G' };
            char[] checkprefixS = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'Z', 'J' };
            char[] checkprefixT = { 'H', 'I', 'Z', 'J', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            char[] checkprefixF = { 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'T', 'U', 'W', 'X' };
            char[] checkprefixG = { 'T', 'U', 'W', 'X', 'K', 'L', 'M', 'N', 'P', 'Q', 'R' };
         

            char prefix = isNRIC ? prefixST[rnd.Next(0, 2)] : prefixFG[rnd.Next(0, 2)];
            string digits = rnd.Next(1000000, 9999999).ToString();//getRandomInt(1000000, 9999999).ToString();
            var digitsArr = digits.ToCharArray();
            int sum = 0;
            int[] weights = { 2, 7, 6, 5, 4, 3, 2 };
            for (var i = 0; i < 7; i++)
            {
                sum = sum+ (int.Parse(digitsArr[i].ToString()) * weights[i]);
            }
            int offset = prefix == 'T' || prefix == 'G' ? 4 : 0;
            int checkdigit = 11- ((sum+offset) % 11)-1;
            char suffix =  '\0';
            if (prefix == 'S')
                suffix = checkprefixS[checkdigit];
            else if (prefix == 'T')
                suffix=checkprefixT[ checkdigit];
            else if  (prefix== 'F')
                suffix = checkprefixF[checkdigit];
            else if (prefix=='G')
                suffix = checkprefixG[checkdigit];
            nric = prefix + digits + suffix;
            return nric;

        }


        private static int getRandomInt(decimal min, decimal max)
        {
            min = Math.Ceiling(min);
            max = Math.Floor(max);
            var random = Math.Floor((decimal)(new Random(DateTime.Now.Millisecond)).Next());
            return decimal.ToInt32((random * (max - min)) + min);
        }
    }
}

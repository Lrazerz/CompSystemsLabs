using System;

namespace Lab2
{
    class Task2
    {
        public static void Division(int num1, int num2)
        {
            Int64 divisor, remainderAndQuotient;
            divisor = num1;
            remainderAndQuotient = num2;
            divisor <<= 32;
            bool setRemLSBToOne = false;
            for (int i = 0; i <= 32; ++i)
            {
                if (divisor <= remainderAndQuotient)
                {
                    remainderAndQuotient -= divisor;
                    setRemLSBToOne = true;
                }
                remainderAndQuotient <<= 1;
                if (setRemLSBToOne)
                {
                    setRemLSBToOne = false;
                    remainderAndQuotient |= 1;
                }

                Console.WriteLine("Divisor:\n" + finisherOfString(Convert.ToString(divisor, 2)) +
                "\nRemainder and Quotient:\n" + finisherOfString(Convert.ToString(remainderAndQuotient, 2)));
            }
            long quotient = remainderAndQuotient & ((long)Math.Pow(2, 33) - 1);
            long remainder = remainderAndQuotient >> 33;
            Console.WriteLine("Quotient: " + finisherOfString(Convert.ToString(quotient, 2)) +
            "[" + quotient + "]");

            Console.WriteLine("Remainder: " + finisherOfString(Convert.ToString(remainder, 2)) +
            "[" + remainder + "]");
            }
        static string finisherOfString(string value)
        {
            int count = 64 - value.Length;
            string header = "";
            for (int i = 0; i < count; ++i)
                header += "0";
            return header + value;
        }
    }
}

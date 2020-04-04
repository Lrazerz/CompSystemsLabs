using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Task1
    {
        public static void Multiply(int multiplicand, int multiplier)
        {
            Int64 Product = 0;
            multiplicand <<= 16;
            string binaryMultiplicand = ConvertNumberToBinary(multiplicand);
            string binaryMultiplier = ConvertNumberToBinary(multiplier);

            Console.WriteLine("Multiplicand: " + binaryMultiplicand);
            Console.WriteLine("Multiplier: " + binaryMultiplier);

            for (int i = 0; i < 16; ++i)
            {
                if ((multiplier & 1) == 1)
                {
                    Console.WriteLine("Sum of Multiplicand:  {0}\nand Product:  {1}", binaryMultiplicand, ConvertNumberToBinary(Product));
                    Product += multiplicand;
                    Console.WriteLine("is :  {0}", ConvertNumberToBinary(Product));
                }

                Product >>= 1;
                Console.WriteLine("Product with carry:  {0}", ConvertNumberToBinary(Product));

                Console.WriteLine("Multipler:  {0}",ConvertNumberToBinary(multiplier));
                multiplier >>= 1;
                Console.WriteLine("Multiplier with carry  {0}",ConvertNumberToBinary(multiplier));
            }

            Console.WriteLine("Finally Product is  {0}\n(decimal  {1})", ConvertNumberToBinary(Product), Product);

        }
        private static string ConvertNumberToBinary(Int64 number)
        {
            string bits = "";
            for (int i = 0; i < 32; i++)
            {
                bits = ((i + 1) % 4 == 0 ? " " : "") + (number & 1) + bits;
                number >>= 1;
            }
            return bits;
        }
    }
}

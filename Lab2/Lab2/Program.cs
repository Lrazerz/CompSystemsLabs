using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Console.WriteLine("Enter the multiplicand");
            int multiplicand = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the multiplier");
            int multiplier = int.Parse(Console.ReadLine());
            Task1.Multiply(multiplicand, multiplier);

            //Task 2
            //Console.WriteLine("Enter first number");
            //int number1 = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Enter second number");
            //int number2 = Int32.Parse(Console.ReadLine());
            //Task2.Division(number1, number2);

            //Task3
            //Console.WriteLine("Enter first number:");
            //float number1 = float.Parse(Console.ReadLine());
            //Console.WriteLine("Enter second number:");
            //float number2 = float.Parse(Console.ReadLine());
            //Task3.Evaluate(number1, number2);

            Console.ReadKey();
        }

    }
}

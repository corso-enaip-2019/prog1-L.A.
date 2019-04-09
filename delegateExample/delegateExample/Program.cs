using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateExample
{
    class Program
    {
        public delegate void Operation(int operatorValue1, int operatorValue2);

        static void Main(string[] args)
        {
            Operation operation = new Operation(Operations.Division);

            operation += Operations.Sum;

            operation += Operations.Diff;

            operation += Operations.Multiplication;

            operation += Operations.Division;
            operation(5, 3);
            Console.ReadLine();

        }
    }

    public class Operations
    {
        public static void Sum (int a, int b)
        {
            Console.WriteLine($"Sum is: {a+b}");
        }

        public static void Diff (int num1, int num2)
        {
            Console.WriteLine($"Difference is: {num1-num2}");
        }

        public static void Multiplication (int factor1, int factor2)
        {
            Console.WriteLine($"Multiplication is: {factor1*factor2}");
        }

        public static void Division (int divisor1, int divisor2)
        {
            Console.WriteLine($"Division is: {divisor1/divisor2}");
        }
    }
}

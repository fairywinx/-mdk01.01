using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekursia
{
     class Program
    {

        public static void naturalnumbers(int N, int i)//все возможные варианты сложения                  
        {
            if (natural(N))
            {
                int k = N - i;

                if (i <= k)
                {
                    Console.WriteLine(N + " = " + i + " + " + k);
                    naturalnumbers(N, i + 1);
                }
            }
            else
                Console.WriteLine("Число не является натуральным");
        }

        static bool natural(int N)
        {
            if (N >= 1 && N % 1 == 0)
                return true;
            else
                return false;
        }

        static bool primenumbers(int n, int k = 2)//простые числа
        {
            if (k * k > n)
                return true;
            if (n % k == 0)
                return false;
            return primenumbers(n, k + 1);
        }

        static bool Palindrom(string str, int i)//палиндром
        {
            if (str[i] != str[str.Length - i - 1])
                return false;

            if (i <= str.Length / 2 - 1)
                Palindrom(str, i + 1);

            return true;
        }



        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int N = Convert.ToInt32(Console.ReadLine());

            naturalnumbers(N, 1);

            if (primenumbers(N))
                Console.WriteLine("Число является простым");
            else
                Console.WriteLine("Число не является простым");


            Console.Write("Введите строку: ");
            string str = Console.ReadLine().ToLower();

            if (Palindrom(str, 0))
                Console.WriteLine("Строка является палиндромом");
            else
                Console.WriteLine("Строка не является палиндромом");
            Console.ReadLine();



        }
    }
}
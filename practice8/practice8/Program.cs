using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            counter.GetNumber200 += Wait.Wait200;
            counter.GetNumber800 += Wait.Wait800;
            counter.to_generate();

            Console.ReadLine();
        }

        public class Counter
        {
            public int numbers { get; set; } = 0;

            public void to_generate()
            {
                while (numbers < 1000)
                {
                    numbers++;
                    Console.WriteLine("Число: " + numbers);
                    if (numbers == 200) GetNumber200();
                    if (numbers == 800) GetNumber800();
                }
            }

            public event Action GetNumber200;
            public event Action GetNumber800;

        }

        public static class Wait
        {
            public static void Wait200()
            {
                Console.WriteLine("Число 200");
            }
            public static void Wait800()
            {
                Console.WriteLine("Число 800");
            }
        }

    }
}
    


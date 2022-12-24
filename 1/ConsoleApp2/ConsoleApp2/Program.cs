using System;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10000];
            Timing t = new Timing();
            Stopwatch sw = new Stopwatch();
            TimeSpan TimeTaken;
            //Сортировка
            ExchangeSorting exchangeSorting = new ExchangeSorting();
            //Сортировка простым обменом
            sw.Start();
            exchangeSorting.BubleSort(a);
            sw.Stop();
            TimeTaken = sw.Elapsed;
            Console.WriteLine("Время выполнения сортировки простым обменом (StopWatch): " + TimeTaken.ToString(@"m\:ss\.fff"));

            t = new Timing();
            t.StartTime();
            exchangeSorting.BubleSort(a);
            t.StopTime();
            Console.WriteLine($"Время выполнения сортировки простым обменом (Timing): {t.Result().ToString()}");

            //простой поиск
            SimpleSearch simpleSearch = new SimpleSearch();
            sw.Start();
            simpleSearch.Search(a, 100);
            sw.Stop();
            TimeTaken = sw.Elapsed;
            Console.WriteLine("Время выполнения простого поиска(StopWatch): " + TimeTaken.ToString(@"m\:ss\.fff"));

            t = new Timing();
            t.StartTime();
            simpleSearch.Search(a, 100);
            t.StopTime();
            Console.WriteLine($"Время выполнения простого поиска(Timing): {t.Result().ToString()}");

            //Бинарный поиск
            SearchBinary searchBinary = new SearchBinary();
            
            sw.Start();
            searchBinary.Search(a, 100);
            sw.Stop();
            TimeTaken = sw.Elapsed;
            Console.WriteLine("Время выполнения бинарного поиска(StopWatch): " + TimeTaken.ToString(@"m\:ss\.fff"));

            t = new Timing();
            t.StartTime();
            searchBinary.Search(a, 100);
            t.StopTime();
            Console.WriteLine($"Время выполнения бинарного поиска(Timing): {t.Result().ToString()}");
        }

        internal class ExchangeSorting
        {
            public void BubleSort(int[] a)
            {
                int N = a.Length;
                for (int i = 1; i < N; i++)
                {
                    for (int j = N - 1; j >= i; j--)
                    {
                        if (a[j - 1] > a[j])
                        {
                            int t = a[j - 1];
                            a[j - 1] = a[j];
                            a[j] = t;
                        }
                    }
                }
            }
        }
        internal class SearchBinary
        {
            public int Search(int[] a, int x)
            {
                int middle, left = 0, right = a.Length - 1;
                do
                {
                    middle = (left + right) / 2;
                    if (x > a[middle])
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
                while ((a[middle] != x) && (left <= right));
                if (a[middle] == x)
                    return middle;
                else return -1;
            }
        }
        internal class SimpleSearch
        {
            public int Search(int[] a, int x)
            {
                int i = 0;
                while (i < a.Length && a[i] != x) i++;
                if (i < a.Length)
                    return i;
                else return -1;
            }
        }

    }

    internal class Timing

    {

        TimeSpan duration; //хранение результата измерения

        TimeSpan[] threads; // значения времени для всех потоков процесса

        public Timing()

        {

            duration = new TimeSpan(0);

            threads = new TimeSpan[Process.GetCurrentProcess().

            Threads.Count];

        }

        public void StartTime() //инициализация массива threads после вызова сборщика мусора

        {

            GC.Collect();

            GC.WaitForPendingFinalizers();

            for (int i
            = 0; i < threads.Length; i++)

                threads[i] = Process.GetCurrentProcess().Threads[i].

                UserProcessorTime;

        }

        public void StopTime() //повторный запрос текущего времени и выбирается тот, у которого результат отличается от

        {
            //предыдущего

            TimeSpan tmp;

            for (int i = 0; i < threads.Length; i++)

            {

                tmp = Process.GetCurrentProcess().Threads[i].

                UserProcessorTime.Subtract(threads[i]);

                if (tmp > TimeSpan.Zero)

                    duration = tmp;

            }

        }

        public TimeSpan Result()

        {

            return duration;
        }

    }
}

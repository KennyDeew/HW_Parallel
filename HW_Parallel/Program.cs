using System.Diagnostics;

namespace HW_Parallel
{
    internal class Program
    {
        /// <summary>
        /// Делегат на расчет суммы элементов массива
        /// </summary>
        

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            long[] array = GenerateArray(1000000000);


            SimpleCalculator calculator1 = new SimpleCalculator();
            ParallelCalculator calculator2 = new ParallelCalculator(2);
            PlinqCalculator calculator3 = new PlinqCalculator(2);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            long SumOfArray = calculator1.GetSum(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum - {SumOfArray} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            long ThreadResult = calculator2.GetSum(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum - {ThreadResult} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            var PlinqResult = calculator3.GetSum(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum - {PlinqResult} Time - {stopwatch.ElapsedMilliseconds}");
        }

        private static long[] GenerateArray(int ArrayLength)
        {
            long[] array = new long[ArrayLength];
            Random random = new Random();
            for (int i = 0; i < ArrayLength; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }
    }
}

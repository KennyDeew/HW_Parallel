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
            long[] array = GenerateArray(100000000);


            Calculator calculator = new Calculator();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long SumOfArray = calculator.GetSumAsSequential(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum - {SumOfArray} Time - {stopwatch.ElapsedMilliseconds}");


            stopwatch.Restart();
            var AsyncResult = calculator.GetSumAsync(array, 10);
            stopwatch.Stop();
            long result = AsyncResult.Result;
            Console.WriteLine($"Sum - {result} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            var ParallelResult = calculator.GetSumAsParallel(array, 5);
            stopwatch.Stop();
            Console.WriteLine($"Sum - {ParallelResult} Time - {stopwatch.ElapsedMilliseconds}");
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

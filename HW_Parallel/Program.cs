using System.Diagnostics;
using System.Management;
using System;

namespace HW_Parallel
{
    internal class Program
    {
        /// <summary>
        /// Делегат на расчет суммы элементов массива
        /// </summary>
        

        static void Main(string[] args)
        {
            GetEnvironmentInfo();

            long[] array = Generator.GenerateLongArray(100000000);

            SimpleCalculator calculator1 = new SimpleCalculator();
            ParallelCalculator calculator2 = new ParallelCalculator(2);
            PlinqCalculator calculator3 = new PlinqCalculator(2);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            long SumOfArray = calculator1.GetSum(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum (Simple) - {SumOfArray} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            long ThreadResult = calculator2.GetSum(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum (Parallel) - {ThreadResult} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            var PlinqResult = calculator3.GetSum(array);
            stopwatch.Stop();
            Console.WriteLine($"Sum (PLINQ) - {PlinqResult} Time - {stopwatch.ElapsedMilliseconds}");
        }

        private static void GetEnvironmentInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine("Processor Name: " + obj["Name"]);
            }
            Console.WriteLine("ОС: " + Environment.OSVersion);
        }
    }
}

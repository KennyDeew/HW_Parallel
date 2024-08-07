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

            var longAarray = Generator.GenerateLongArray(100000000);

            var simpleCalculator = new SimpleCalculator();
            var parallelCalculator = new ParallelCalculator(2);
            var plinqCalculator = new PlinqCalculator(2);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var sumOfLongArray = simpleCalculator.GetSum(longAarray);
            stopwatch.Stop();
            Console.WriteLine($"Sum (Simple) - {sumOfLongArray} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            sumOfLongArray = parallelCalculator.GetSum(longAarray);
            stopwatch.Stop();
            Console.WriteLine($"Sum (Parallel) - {sumOfLongArray} Time - {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            sumOfLongArray = plinqCalculator.GetSum(longAarray);
            stopwatch.Stop();
            Console.WriteLine($"Sum (PLINQ) - {sumOfLongArray} Time - {stopwatch.ElapsedMilliseconds}");
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

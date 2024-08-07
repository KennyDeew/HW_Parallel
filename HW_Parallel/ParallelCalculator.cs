using System.Diagnostics;

namespace HW_Parallel
{
    public class ParallelCalculator : ICalculator
    {
        /// <summary>
        /// Макс кол-во паралелльных потоков
        /// </summary>
        private int _threadCount { get; }

        public ParallelCalculator(int threadNumber) 
        {
            _threadCount = threadNumber; 
        }

        public long GetSum(long[] longArray)
        {
            var asyncResult = GetSumAsync(longArray);
            return asyncResult.Result;
        }

        private async Task<long> GetSumInPartArray(long[] longArray, int startIndex, int finishIndex)
        {
            var sumOfPartArray = 0l;
            for (int i = startIndex; i < finishIndex; i++)
            {
                sumOfPartArray += longArray[i];
            }
            return sumOfPartArray;
        }

        /// <summary>
        /// Параллельное вычисление суммы элементов
        /// </summary>
        /// <param name="longArray"></param>
        /// <returns></returns>
        private async Task<long> GetSumAsync(long[] longArray)
        {
            var parallelTasks = new List<Task<long>>();
            for (int i = 0; i < _threadCount; i++)
            {
                var startIndex = i * longArray.Length / _threadCount;
                var finishIndex = startIndex + longArray.Length / _threadCount;
                parallelTasks.Add(GetSumInPartArray(longArray, startIndex, finishIndex));
            }
            var partsArr = await Task.WhenAll(parallelTasks);
            return partsArr.Sum();
        }
    }
}

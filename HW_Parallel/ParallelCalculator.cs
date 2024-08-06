using System.Diagnostics;

namespace HW_Parallel
{
    public class ParallelCalculator : ICalculator
    {
        /// <summary>
        /// Макс кол-во паралелльных потоков
        /// </summary>
        private int ThreadNumber { get; }

        public ParallelCalculator(int threadNumber) 
        {  
            ThreadNumber = threadNumber; 
        }

        public long GetSum(long[] longArray)
        {
            var AsyncResult = GetSumAsync(longArray);
            return AsyncResult.Result;
        }

        private async Task<long> GetSumInPartArray(long[] longArray, int startIndex, int finishIndex)
        {
            long Sum = 0;
            for (int i = startIndex; i < finishIndex; i++)
            {
                Sum += longArray[i];
            }
            return Sum;
        }

        /// <summary>
        /// Параллельное вычисление суммы элементов
        /// </summary>
        /// <param name="longArray"></param>
        /// <returns></returns>
        private async Task<long> GetSumAsync(long[] longArray)
        {
            List<Task<long>> paralleltasks = new List<Task<long>>();
            for (int i = 0; i < ThreadNumber; i++)
            {
                int startIndex = i * longArray.Length / ThreadNumber;
                int finishIndex = startIndex + longArray.Length / ThreadNumber;
                paralleltasks.Add(GetSumInPartArray(longArray, startIndex, finishIndex));
            }
            long[] SpacesCountArr = await Task.WhenAll(paralleltasks);
            return SpacesCountArr.Sum();
        }
    }
}

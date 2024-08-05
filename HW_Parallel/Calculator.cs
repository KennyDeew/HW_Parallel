using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW_Parallel
{
    public class Calculator
    {
        
        /// <summary>
        /// Обычное вычисление суммы элементов
        /// </summary>
        /// <param name="longArray"></param>
        /// <returns></returns>
        public long GetSumAsSequential(long[] longArray)
        {
            long Sum = 0;
            foreach (long intValue in longArray)
            {
                Sum += intValue;
            }
            return Sum;
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
        /// <param name="threadNumber">Кол-во параллельных потоков</param>
        /// <returns></returns>
        public async Task<long> GetSumAsync(long[] longArray, int threadNumber)
        {
            List<Task<long>> paralleltasks = new List<Task<long>>();
            for (int i = 0; i < threadNumber; i++)
            {
                int startIndex = i * longArray.Length / threadNumber;
                int finishIndex = startIndex + longArray.Length / threadNumber;
                paralleltasks.Add(GetSumInPartArray(longArray, startIndex, finishIndex));
            }
            long[] SpacesCountArr = await Task.WhenAll(paralleltasks);
            return SpacesCountArr.Sum();
        }
        
        /// <summary>
        /// Вычисление суммы элементов с помощью PLINQ
        /// </summary>
        /// <param name="longArray"></param>
        /// <param name="threadNumber">Макс кол-во паралелльных потоков</param>
        /// <returns></returns>
        public long GetSumAsParallel(long[] longArray, int threadNumber)
        {
            long result = longArray.AsParallel().WithMergeOptions(ParallelMergeOptions.AutoBuffered).WithDegreeOfParallelism(threadNumber).Sum();
            return result;
        }
    }
}

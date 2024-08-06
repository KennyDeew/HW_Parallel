
namespace HW_Parallel
{
    public class PlinqCalculator : ICalculator
    {
        /// <summary>
        /// Макс кол-во паралелльных потоков
        /// </summary>
        private int ThreadNumber { get; }

        public PlinqCalculator(int threadNumber)
        {
            ThreadNumber = threadNumber;
        }

        /// <summary>
        /// Вычисление суммы элементов с помощью PLINQ
        /// </summary>
        /// <param name="longArray"></param>
        /// <returns></returns>
        public long GetSum(long[] longArray)
        {
            long result = longArray.AsParallel().WithMergeOptions(ParallelMergeOptions.AutoBuffered).WithDegreeOfParallelism(ThreadNumber).Sum();
            return result;
        }
    }
}

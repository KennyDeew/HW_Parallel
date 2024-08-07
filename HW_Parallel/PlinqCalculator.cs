
namespace HW_Parallel
{
    public class PlinqCalculator : ICalculator
    {
        /// <summary>
        /// Макс кол-во паралелльных потоков
        /// </summary>
        private int _threadCount { get; }

        public PlinqCalculator(int threadCount)
        {
            _threadCount = threadCount;
        }

        /// <summary>
        /// Вычисление суммы элементов с помощью PLINQ
        /// </summary>
        /// <param name="longArray"></param>
        /// <returns></returns>
        public long GetSum(long[] longArray)
        {
            return longArray.AsParallel().WithMergeOptions(ParallelMergeOptions.AutoBuffered).WithDegreeOfParallelism(_threadCount).Sum();
        }
    }
}

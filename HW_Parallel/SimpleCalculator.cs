namespace HW_Parallel
{
    /// <summary>
    /// Класс реализующий простое вычисление суммы
    /// </summary>
    public class SimpleCalculator : ICalculator
    {
        /// <summary>
        /// Обычное вычисление суммы элементов
        /// </summary>
        /// <param name="longArray"></param>
        /// <returns></returns>
        public long GetSum(long[] longArray)
        {
            long Sum = 0;
            foreach (long intValue in longArray)
            {
                Sum += intValue;
            }
            return Sum;
        }
    }
}

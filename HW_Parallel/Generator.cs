namespace HW_Parallel
{
    public class Generator
    {
        public static long[] GenerateLongArray(int arrayCount)
        {
            long[] array = new long[arrayCount];
            Random random = new Random();
            for (int i = 0; i < arrayCount; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }
    }
}

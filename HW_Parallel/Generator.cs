namespace HW_Parallel
{
    public class Generator
    {
        public static long[] GenerateLongArray(int arrayCount)
        {
            var longArray = new long[arrayCount];
            var random = new Random();
            for (int i = 0; i < arrayCount; i++)
            {
                longArray[i] = random.Next();
            }
            return longArray;
        }
    }
}

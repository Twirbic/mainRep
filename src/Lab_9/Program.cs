namespace Lab_9
{
    internal class Program
    {
        static void BubbleSortWithSwapCount(int[] arr, out int swapCount)
        {
            swapCount = 0;
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {

                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {

                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapCount++; 
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        static void Main()
        {
            int[] numbers = { 8, 5, 2, 9, 1, 5, 6 };
            int swapCount;
            Console.WriteLine($"початкові числа: [{string.Join(", ", numbers)}]");

            BubbleSortWithSwapCount(numbers, out swapCount);

            Console.WriteLine($"swap сount: {swapCount}");
            Console.WriteLine($"після сорту: [{string.Join(", ", numbers)}]");
        }
    }
}

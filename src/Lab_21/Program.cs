namespace Lab_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Узагальнений контейнер");
            Console.WriteLine("2) Узагальнений метод пошуку");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1.Run();
                    break;
                case "2":
                    Task2.Run();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.ReadKey(); // exit
        }
    }

    public static class Task1
    {
        public static void Run()
        {
            // int
            Container<int> intContainer = new Container<int> { Value = 42 };
            Console.WriteLine("\nints:");
            intContainer.ShowInfo();

            // string
            Container<string> strContainer = new Container<string> { Value = "Hello" };
            Console.WriteLine("\nstrings:");
            strContainer.ShowInfo();
        }
    }

    public static class Task2
    {
        public static void Run()
        {

            // int
            int[] intArray = { 10, 5, 20, 15, 30, 25 };
            Console.WriteLine($"Масив цілих чисел: {string.Join(", ", intArray)}");
            Console.WriteLine($"Макс елемент: {FindMax(intArray)}");

            // double
            double[] doubleArray = { 3.14, 2.71, 1.618, 0.577 };
            Console.WriteLine($"Масив дійсних чисел: {string.Join(", ", doubleArray)}");
            Console.WriteLine($"Макс елемент: {FindMax(doubleArray)}");

            // string
            string[] strArray = { "apple", "pineapple", "cucumber", "dirt" };
            Console.WriteLine($"Масив рядків: {string.Join(", ", strArray)}");
            Console.WriteLine($"Макс елемент: {FindMax(strArray)}");


        }

        static T FindMax<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("array is empty");

            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {

                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }

            }
            return max;
        }
    }

    public class Container<T>
    {
        public T Value { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Значення: {Value}, Тип: {typeof(T).Name}");
        }
    }
}
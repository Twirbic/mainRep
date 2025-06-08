namespace Lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }

        static void Task1()
        {
            int[] nums = { 12, 15, 7, 20, 33, 50, 8, 11, 90, 45 };

            var processedNums = nums.Where(n => n % 3 == 0 || n % 5 == 0);
            int sum = processedNums.Sum();

            Console.WriteLine("Числа, що діляться на 3 або 5: " + string.Join(", ", processedNums));
            Console.WriteLine("Сума: " + sum);
        }
        static void Task2()
        {
            string[] towarNames = { "Хліб", "Молоко", "Яблука", "Сир", "Шоколад", "Кава", "Чай" };
            double[] towarPrices = { 25.5, 32.0, 45.3, 120.0, 80.0, 150.0, 75.5 };

            // average 
            double averagePrice = towarPrices.Average();
            Console.WriteLine($"average: {averagePrice:F2} грн");



            // > average
            var aboveAverage = towarNames
                .Select((name, index) => new { Name = name, Price = towarPrices[index] })
                .Where(p => p.Price > averagePrice);

            Console.WriteLine("> average: ");
            foreach (var product in aboveAverage)

                Console.WriteLine($"{product.Name}: {product.Price:F2} грн");



            // cheap anf expencive
            int minIndex = Array.IndexOf(towarPrices, towarPrices.Min());
            int maxIndex = Array.IndexOf(towarPrices, towarPrices.Max());

            Console.WriteLine($"cheap: {towarNames[minIndex]} ({towarPrices[minIndex]:F2} грн)");
            Console.WriteLine($"expencive: {towarNames[maxIndex]} ({towarPrices[maxIndex]:F2} грн)");
        }
    }
}

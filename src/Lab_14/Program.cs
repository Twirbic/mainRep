namespace Lab_14
{
    class Program
    {
        static async Task Main()
        {
            string[] fileNames = { "log1.txt", "log2.txt", "log3.txt"};

            await GenerateTestLogFiles(fileNames);

            Task<int>[] processingTasks = fileNames
                .Select(fileName => ProcessFileAsync(fileName))
                .ToArray();

            // waiting
            int[] results = await Task.WhenAll(processingTasks);


            for (int i = 0; i < fileNames.Length; i++)
            {
                Console.WriteLine($"Файл {fileNames[i]}: знайдено {results[i]} помилок.");
            }


        }

        static async Task<int> ProcessFileAsync(string fileName)
        {
            int errorCount = 0;

            try
            {
                string[] lines = await File.ReadAllLinesAsync(fileName);

                errorCount = lines.Count(line => line.Contains("ERROR", StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"Оброблено файл {fileName} (помилок: {errorCount})");
            }



            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error {fileName} does not exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обробці файлу {fileName}: {ex.Message}");
            }

            return errorCount;
        }


        static async Task GenerateTestLogFiles(string[] fileNames)
        {
            // if Exists
            if (fileNames.All(File.Exists))
                return;

            Console.WriteLine("Генерація тестових лог-файлів...");

            var random = new Random();
            var logLevels = new[] { "INFO", "WARNING", "ERROR", "DEBUG" };



            foreach (var fileName in fileNames) // генерує лог файли, їх формат та записує данні
            {
                var lines = Enumerable.Range(1, 10000)
                    .Select(i => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevels[random.Next(logLevels.Length)]}] Повідомлення {i}") //
                    .ToArray();

                await File.WriteAllLinesAsync(fileName, lines); // записує данні
            }


        }
    }
}

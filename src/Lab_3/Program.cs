namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            UserInfo();
            Task3();
        }

        static void Task1()
        {
            int userAge = 20;
            string UserName = "Андрій";

            Console.WriteLine("Привіт, " + UserName + "! Твій вік: " + userAge);
        }

        static void UserInfo()
        {
            int userAge = 20;
            string UserName = "Андрій";

            Console.WriteLine("Привіт, " + UserName + "! Твій вік: " + userAge);
        }

        private static void Task3() // метод в main під назвою "Task3"
        {
            string name = "Анна"; // string з ім'ям name значенням "Анна"
            int age = 25; // int з ім'ям "age" отримує значенням "25"
            Console.WriteLine("Привіт, " + name + "! Твій вік: " + age); // в консоль виводиться команда яка поєднує в собі певний текст та змінні
        }

    }
}

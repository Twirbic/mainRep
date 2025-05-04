namespace NewLab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
        static void Task1()
        {
            int age = 17;
            double weight = 5;
            char grade = 'A';
            bool student = true;
            string name = "Vasiluev";

            Console.WriteLine("Вік: " + age + " Вага: " + weight + " Оцінка: " + grade + " Студент: " + student + " Ім'я: " + name);

        }
        static void Task2()
        {
            double doubleValue = Convert.ToDouble(42);
            Console.WriteLine("double " + doubleValue);

            int intValue = (int)doubleValue;
            Console.WriteLine("int " + intValue);

            string stringValue = intValue.ToString();
            Console.WriteLine("string " + stringValue);
        }
        static void Task3()
        {
            Console.Write("Your name: ");
            string name = Console.ReadLine();

            Console.Write("Your age: ");
            string age = Console.ReadLine();

            Console.WriteLine("Hello, " + name + "! " + "You are: " + age + " years old");
        }
        static void Task4()
        {
            Console.Write("S: ");
            double S = Convert.ToDouble(Console.ReadLine());

            Console.Write("t: ");
            double t = Convert.ToDouble(Console.ReadLine());

            double V = S / t;

            Console.WriteLine("The answer is: " + V + "км/год");
        }
        static void Task5()
        {
            Console.Write("Введіть речення: ");
            string sentence = Console.ReadLine();

            Console.WriteLine("Довжина: " + sentence.Length + " символів");

            string upperCase = sentence.ToUpper();
            Console.WriteLine("Верхній регістр: " + upperCase);

            string replacedSpacebars = sentence.Replace(' ', '_');
            Console.WriteLine("Замінені пробіли: " + replacedSpacebars);

            string firstFive = sentence.Length > 4 ? sentence.Substring(0, 5) : sentence;
            Console.WriteLine("Перші 5 символів: " + firstFive);
        }
    }
}

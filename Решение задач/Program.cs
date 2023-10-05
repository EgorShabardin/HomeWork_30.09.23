using System;
using System.Threading;

namespace Решение_задач
{
    class Program
    {
        static void ChangesValue(int firstNumber, int secondNumber, int[] randomNumbers)
        {
            int firstIndex = Array.IndexOf(randomNumbers, firstNumber);
            int secondIndex = Array.IndexOf(randomNumbers, secondNumber);

            randomNumbers[firstIndex] = secondNumber;
            randomNumbers[secondIndex] = firstNumber;
        }
        static int CalculationsArrayNumbers(ref int product, out double averageValue, params int[] randomValues)
        {
            int summ = 0;
            
            foreach (int number in randomValues)
            {
                summ += number;
                product *= number;
            }

            averageValue = (double) summ / randomValues.Length;

            return summ;
        }
        static void DrawingNumbers(string[] numberPictures)
        {
            try
            {
                string enteredValue;
                int enteredNumber;
                bool parseResult;

                do
                {
                    Console.WriteLine("Чтобы закончить выполнение задания, введите exit или закрыть\n");
                    Console.Write("Введите целое число от 0 до 9: ");
                    enteredValue = Console.ReadLine();
                    parseResult = int.TryParse(enteredValue, out enteredNumber);

                    if (parseResult)
                    {
                        if (enteredNumber >= 0 && enteredNumber <= 9)
                        {
                            Console.WriteLine(numberPictures[enteredNumber]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nВы ввели число меньше 0 или больше 9!\n");
                            Thread.Sleep(3000);
                            Console.ResetColor();
                        }
                    }
                    else if (enteredValue.ToLower() == "exit" || enteredValue.ToLower() == "закрыть")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        throw new Exception("\nВы ввели не число или оно является дробным!");
                    }
                } while (!(enteredValue.ToLower() == "exit" || enteredValue.ToLower() == "закрыть"));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                Console.ReadKey();
                Console.Clear();
            }
        }
        enum GrouchinessLevel
        {
            Сильно_ворчливый,
            Умеренно_ворчливый,
            Немного_ворчливый,
            Вообще_неворчливый
        }
        struct Grandfather
        {
            public string name;
            public GrouchinessLevel grouchinessLevel;
            public string[] grumblingPhrases;
            public int bruisesNumber;
            public void CountsBruises(params string[] listSwearWords)
            {
                foreach (string word in grumblingPhrases)
                {
                    if (Array.IndexOf(listSwearWords, word.ToLower()) != -1)
                    {
                        bruisesNumber++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 71}", "РЕШЕНИЕ ЗАДАЧ. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Задание №1. Программа генерирует 20 чисел и меняет местами два введенных числа                    -   цифра 1\n" +
                                  "Задание №2. Программа получает числа и выводит их сумму, произведение и среднее арифметическое    -   цифра 2\n" +
                                  "Задание №3. Программа получает число и выводит на экран его рисунок                               -   цифра 3\n" +
                                  "Задание №4. Программа создает 5 дедов и подсчитывает количество фингалов                          -   цифра 4\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                 -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Задание №1. Программа генерирует 20 чисел и меняет местами два введенных числа.
                        Console.Clear();
                        Console.WriteLine("{0, 100}", "ЗАДАНИЕ №1. ПРОГРАММА ГЕНЕРИРУЕТ 20 ЧИСЕЛ И МЕНЯЕТ МЕСТАМИ ДВА ВВЕДЕННЫХ ЧИСЛА\n");

                        int[] randomNumbers = new int[20];
                        int firstNumber, secondNumber;
                        bool firstResult, secondResult;
                        Random randomNumber = new Random();

                        Console.Write("Получился массив: ");

                        for (int i = 0; i < randomNumbers.Length; i++)
                        {
                            int number = randomNumber.Next(50);
                            Console.Write(number + " ");
                            randomNumbers[i] = number;
                        }

                        Console.WriteLine("\nДва числа из массива меняются местами\n");

                        do
                        {
                            Console.Write("Введите первое число из массива: ");
                            firstResult = int.TryParse(Console.ReadLine(), out firstNumber);
                            Console.Write("Введите второе число из массива: ");
                            secondResult = int.TryParse(Console.ReadLine(), out secondNumber);

                            if (firstResult && secondResult && (Array.IndexOf(randomNumbers, firstNumber) != -1) && (Array.IndexOf(randomNumbers, secondNumber) != -1))
                            {
                                ChangesValue(firstNumber, secondNumber, randomNumbers);

                                Console.Write("\nМассив изменился: ");

                                foreach (int number in randomNumbers)
                                {
                                    Console.Write(number + " ");
                                }

                                Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является целым, или его нет в массиве. Повторите попытку");
                            }
                        } while (!(firstResult && secondResult && (Array.IndexOf(randomNumbers, firstNumber) != -1) && (Array.IndexOf(randomNumbers, secondNumber) != -1)));
                        break;

                    case "2":
                        // Задание №2. Программа получает числа и выводит их сумму, произведение и среднее арифметическое.
                        Console.Clear();
                        Console.WriteLine("{0, 107}", "ЗАДАНИЕ №2. ПРОГРАММА ПОЛУЧАЕТ ЧИСЛА И ВЫВОДИТ ИХ СУММУ, ПРОИЗВЕДЕНИЕ И СРЕДНЕЕ АРИФМЕТИЧЕСКОЕ\n");

                        Random randomValue = new Random();
                        int[] randomValues = new int[randomValue.Next(1, 15)];
                        int summ;
                        double averageValue;
                        int product = 1;

                        Console.Write("Получился массив: ");

                        for (int i = 0; i < randomValues.Length; i++)
                        {
                            int number = randomValue.Next(20);
                            Console.Write(number + " ");
                            randomValues[i] = number;
                        }

                        summ = CalculationsArrayNumbers(ref product, out averageValue, randomValues);

                        Console.WriteLine($"\nСумма чисел массива равна {summ}, произведение - {product}, среднее арифметическое - {averageValue:F}");
                        Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Задание №3. Программа получает число и выводит на экран его рисунок
                        Console.Clear();
                        Console.WriteLine("{0, 95}", "ЗАДАНИЕ №3. ПРОГРАММА ПОЛУЧАЕТ ЧИСЛО И ВЫВОДИТ НА ЭКРАН ЕГО РИСУНОК\n");

                        string[] numbersPictures = { "\t#####\n\t#   #\n\t#   #\n\t#   #\n\t#   #\n\t#   #\n\t#####\n",
                                                     "\t    #\n\t  # #\n\t #  #\n\t    #\n\t    #\n\t    #\n\t    #\n",
                                                     "\t#####\n\t    #\n\t    #\n\t#####\n\t#    \n\t#    \n\t#####\n",
                                                     "\t#####\n\t    #\n\t    #\n\t#####\n\t    #\n\t    #\n\t#####\n",
                                                     "\t#   #\n\t#   #\n\t#   #\n\t#####\n\t    #\n\t    #\n\t    #\n",
                                                     "\t#####\n\t#    \n\t#    \n\t#####\n\t    #\n\t    #\n\t#####\n",
                                                     "\t#####\n\t#    \n\t#    \n\t#####\n\t#   #\n\t#   #\n\t#####\n",
                                                     "\t######\n\t#    #\n\t    #\n\t  #####\n\t    #\n\t    #\n\t    #\n",
                                                     "\t#####\n\t#   #\n\t#   #\n\t#####\n\t#   #\n\t#   #\n\t#####\n",
                                                     "\t#####\n\t#   #\n\t#   #\n\t#####\n\t    #\n\t    #\n\t#####\n" };
                        DrawingNumbers(numbersPictures);    
                        break;

                    case "4":
                        // Задание №4. Программа создает 5 дедов и подсчитывает количество фингалов.
                        Console.Clear();
                        Console.WriteLine("{0, 96}", "ЗАДАНИЕ №4. ПРОГРАММА СОЗДАЕТ 5 ДЕДОВ И ПОДСЧИТЫВАЕТ КОЛИЧЕСТВО ФИНГАЛОВ\n");

                        string[] listSwearWords = { "заебали", "сука", "блять", "ебланы", "пидоры", "ебанутые", "пидорасы", "нахуй" };
                        string[] VityaGrumblingPhrases = { "проститутки", "гады", "твари", "заебали", "сука", "наркоманы", "блять" };
                        string[] VasyaGrumblingPhrases = { "уроды", "ебланы", "твари", "пидоры" };
                        string[] DimaGrumblingPhrases = { "проститутки", "ебанутые", "выродки" };
                        string[] KolyaGrumblingPhrases = { "гады", "тварь" };
                        string[] PeterGrumblingPhrases = { "блять", "тварь", "сука", "заебали", "наркоманы", "пидорасы", "нахуй", "гады" };

                        Grandfather Vitya = new Grandfather();
                        Vitya.name = "Витя";
                        GrouchinessLevel VityagrouchinessLevel = GrouchinessLevel.Сильно_ворчливый;
                        Vitya.grouchinessLevel = VityagrouchinessLevel;
                        Vitya.grumblingPhrases = VityaGrumblingPhrases;
                        Vitya.bruisesNumber = 0;
                        Vitya.CountsBruises(listSwearWords);

                        Grandfather Vasya = new Grandfather();
                        Vasya.name = "Вася";
                        GrouchinessLevel VasyagrouchinessLevel = GrouchinessLevel.Умеренно_ворчливый;
                        Vasya.grouchinessLevel = VasyagrouchinessLevel;
                        Vasya.grumblingPhrases = VasyaGrumblingPhrases;
                        Vasya.bruisesNumber = 0;
                        Vasya.CountsBruises(listSwearWords);

                        Grandfather Dima = new Grandfather();
                        Dima.name = "Дима";
                        GrouchinessLevel DimagrouchinessLevel = GrouchinessLevel.Немного_ворчливый;
                        Dima.grouchinessLevel = DimagrouchinessLevel;
                        Dima.grumblingPhrases = DimaGrumblingPhrases;
                        Dima.bruisesNumber = 0;
                        Dima.CountsBruises(listSwearWords);

                        Grandfather Kolya = new Grandfather();
                        Kolya.name = "Коля";
                        GrouchinessLevel KolyagrouchinessLevel = GrouchinessLevel.Вообще_неворчливый;
                        Kolya.grouchinessLevel = KolyagrouchinessLevel;
                        Kolya.grumblingPhrases = KolyaGrumblingPhrases;
                        Kolya.bruisesNumber = 0;
                        Kolya.CountsBruises(listSwearWords);

                        Grandfather Peter = new Grandfather();
                        Peter.name = "Петя";
                        GrouchinessLevel PetergrouchinessLevel = GrouchinessLevel.Сильно_ворчливый;
                        Peter.grouchinessLevel = PetergrouchinessLevel;
                        Peter.grumblingPhrases = PeterGrumblingPhrases;
                        Peter.bruisesNumber = 0;
                        Peter.CountsBruises(listSwearWords);

                        Console.WriteLine($"Дед {Vitya.name} имеет {Vitya.bruisesNumber} синяка, дед {Vasya.name} - {Vasya.bruisesNumber}, " +
                                          $"дед {Dima.name} - {Dima.bruisesNumber}, дед {Kolya.name} - {Kolya.bruisesNumber}, " +
                                          $"дед {Peter.name} - {Peter.bruisesNumber}");
                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("{0, 69}", "ВЫ ВЫШЛИ ИЗ ПРОГРАММЫ");
                        tasksEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("{0, 98}", "ТАКОГО ЗАДАНИЯ НЕТ! ДОСТУПНЫЕ ЗАДАНИЯ УКАЗАНЫ В ПОДСКАЗКЕ. ПОВТОРИТЕ ПОПЫТКУ\n");
                        break;
                }
            } while (!tasksEnd);
        }
    }
}

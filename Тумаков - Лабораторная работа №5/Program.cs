using System;

namespace Тумаков___Лабораторная_работа__5
{
    class Program
    {
        static int CalculatesMaxValue(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }
        static void ChangesValue(ref string firstValue, ref string secondValue)
        {
            string thirdValue = firstValue;
            firstValue = secondValue;
            secondValue = thirdValue;
        }
        static bool CalculateFactorialCycle(out int factorial, int enteredNumber)
        {
            try
            {
                factorial = 1;

                for (int i = 1; i <= enteredNumber; i++)
                {
                    factorial = checked(factorial * i);
                }
                return true;
            }
            catch (OverflowException)
            {
                factorial = -1;
                return false;
            }
        }
        static int CalculateFactorialRecursion(int enteredNumber)
        {
            if (enteredNumber == 1)
            {
                return 1;
            }
            return enteredNumber * CalculateFactorialRecursion(enteredNumber - 1);
        }
        static int CalculateGCD(int firstNumber, int secondNumber)
        {
            int remainder, result;

            do
            {
                remainder = firstNumber % secondNumber;
                firstNumber = secondNumber;
                result = secondNumber;
                secondNumber = remainder;
            } while (remainder != 0);

            return result;
        }
        static int CalculateGCD(int firstNumber, int secondNumber, int thirdNumber)
        {
            int divider = CalculateGCD(firstNumber, secondNumber);
            int result = CalculateGCD(divider, thirdNumber);

            return result;
        }
        static int CalculateFibonacciNumbers(int numberValue)
        {
            if (numberValue == 1 || numberValue == 2)
            {
                return 1;
            }

            return CalculateFibonacciNumbers(numberValue - 1) + CalculateFibonacciNumbers(numberValue - 2);
        }
        static void Main(string[] args)
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 81}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №5. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 5.1. Программа возвращает максимальное из двух введенных целых чисел   -   цифра 1\n" +
                                  "Упражнение 5.2. Программа меняет местами два передаваемых значения                -   цифра 2\n" +
                                  "Упражнение 5.3. Программа вычисляет факториал числа с помощью цикла               -   цифра 3\n" +
                                  "Упражнение 5.4. Программа вычисляет факториал числа с помощью рекурсии            -   цифра 4\n" +
                                  "Домашнее задание 5.1. Программа вычисляет НОД двух и трех чисел                   -   цифра 5\n" +
                                  "Домашнее задание 5.2. Программа вычисляет значение n-го числа ряда Фибоначчи      -   цифра 6\n" +
                                  "Закончить выполнение заданий и выйти из программы                                 -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 5.1. Программа возвращает максимальное из двух введенных целых чисел.
                        Console.Clear();
                        Console.WriteLine("{0, 100}", "УПРАЖНЕНИЕ 5.1. ПРОГРАММА ВОЗВРАЩАЕТ МАКСИМАЛЬНОЕ ИЗ ДВУХ ВВЕДЕННЫХ ЦЕЛЫХ ЧИСЕЛ\n");

                        int firstNumber, secondNumber, maxNumber;
                        bool firstResult, secondResult;

                        do
                        {
                            Console.Write("Введите первое целое число: ");
                            firstResult = int.TryParse(Console.ReadLine(), out firstNumber);
                            Console.Write("Введите второе целое число: ");
                            secondResult = int.TryParse(Console.ReadLine(), out secondNumber);

                            if (firstResult && secondResult)
                            {
                                maxNumber = CalculatesMaxValue(firstNumber, secondNumber);

                                Console.WriteLine($"\nmax({firstNumber}, {secondNumber}) = {maxNumber}");
                                Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является целым! Повторите попытку\n");
                            }
                        } while (!(firstResult && secondResult));
                        break;

                    case "2":
                        // Упражнение 5.2. Программа меняет местами два передаваемых значения.
                        Console.Clear();
                        Console.WriteLine("{0, 93}", "УПРАЖНЕНИЕ 5.2. ПРОГРАММА МЕНЯЕТ МЕСТАМИ ДВА ПЕРЕДАВАЕМЫХ ЗНАЧЕНИЯ\n");

                        string firstValue, secondValue;

                        Console.Write("Введите первое значение: ");
                        firstValue = Console.ReadLine();
                        Console.Write("Введите второе значение: ");
                        secondValue = Console.ReadLine();

                        ChangesValue(ref firstValue, ref secondValue);

                        Console.WriteLine($"\nЗначения поменялись местами. Первое значение - {firstValue}, второе значение - {secondValue}");
                        Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Упражнение 5.3. Программа вычисляет факториал числа с помощью цикла.
                        Console.Clear();
                        Console.WriteLine("{0, 93}", "УПРАЖНЕНИЕ 5.3. ПРОГРАММА ВЫЧИСЛЯЕТ ФАКТОРИАЛ ЧИСЛА С ПОМОЩЬЮ ЦИКЛА\n");

                        int factorial, enteredNumber;
                        bool factorialResult = true;
                        bool parseResult;

                        do
                        {
                            Console.Write("Введите натуральное число, большее нуля: ");
                            parseResult = int.TryParse(Console.ReadLine(), out enteredNumber);

                            if (parseResult && enteredNumber > 0)
                            {
                                factorialResult = CalculateFactorialCycle(out factorial, enteredNumber);

                                if (factorialResult)
                                {
                                    Console.WriteLine($"\n{enteredNumber}! = {factorial}");
                                    Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine($"\nПри вычислении {enteredNumber}! получилось слишком большое число. Введите число меньше!\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является натуральным (натуральные числа - это числа, большие нуля). Повторите попытку\n");
                            }
                        } while (!(parseResult && enteredNumber > 0 && factorialResult));
                        break;

                    case "4":
                        // Упражнение 5.4. Программа вычисляет факториал числа с помощью рекурсии.
                        Console.Clear();
                        Console.WriteLine("{0, 96}", "УПРАЖНЕНИЕ 5.4. ПРОГРАММА ВЫЧИСЛЯЕТ ФАКТОРИАЛ ЧИСЛА С ПОМОЩЬЮ РЕКУРСИИ\n");

                        do
                        {
                            Console.Write("Введите натуральное число, большее нуля: ");
                            parseResult = int.TryParse(Console.ReadLine(), out enteredNumber);

                            if (parseResult && enteredNumber > 0)
                            {
                                factorial = CalculateFactorialRecursion(enteredNumber);

                                Console.WriteLine($"\n{enteredNumber}! = {factorial}\n");
                                Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
                            }   
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является натуральным (натуральные числа - это числа, большие нуля). Повторите попытку\n");
                            }
                        } while (!(parseResult && enteredNumber > 0));
                        break;

                    case "5":
                        // Домашнее задание 5.1. Программа вычисляет наибольший общий делитель двух и трех чисел.
                        Console.Clear();
                        Console.WriteLine("{0, 100}", "ДОМАШНЕЕ ЗАДАНИЕ 5.1. ПРОГРАММА ВЫЧИСЛЯЕТ НАИБОЛЬШИЙ ОБЩИЙ ДЕЛИТЕЛЬ ДВУХ И ТРЕХ ЧИСЕЛ\n");

                        int thirdNumber, gsd;
                        bool thirdResult;

                        do
                        {
                            Console.Write("Введите первое натуральное число: ");
                            firstResult = int.TryParse(Console.ReadLine(), out firstNumber);
                            Console.Write("Введите второе натуральное число: ");
                            secondResult = int.TryParse(Console.ReadLine(), out secondNumber);

                            if ((firstResult && secondResult) && (firstNumber > 0 && secondNumber > 0))
                            {
                                gsd = CalculateGCD(firstNumber, secondNumber);

                                Console.WriteLine($"\nНОД({firstNumber}, {secondNumber}) = {gsd}\n");           
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является натуральным (натуральные числа - это числа, большие нуля). Повторите попытку\n");
                            }
                        } while (!((firstResult && secondResult) && (firstNumber > 0 && secondNumber > 0)));

                        do
                        {
                            Console.Write("Введите первое натуральное число: ");
                            firstResult = int.TryParse(Console.ReadLine(), out firstNumber);
                            Console.Write("Введите второе натуральное число: ");
                            secondResult = int.TryParse(Console.ReadLine(), out secondNumber);
                            Console.Write("Введите третье натуральное число: ");
                            thirdResult = int.TryParse(Console.ReadLine(), out thirdNumber);

                            if ((firstResult && secondResult && thirdResult) && (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0))
                            {
                                gsd = CalculateGCD(firstNumber, secondNumber, thirdNumber);

                                Console.WriteLine($"\nНОД({firstNumber}, {secondNumber}, {thirdNumber}) = {gsd}");
                                Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является натуральным (натуральные числа - это числа, большие нуля). Повторите попытку!\n");
                            }
                        } while (!((firstResult && secondResult && thirdResult) && (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0)));
                        break;

                    case "6":
                        // Домашнее задание 5.2. Программа вычисляет значение n-го числа ряда Фибоначчи.
                        Console.Clear();
                        Console.WriteLine("{0, 100}", "ДОМАШНЕЕ ЗАДАНИЕ 5.2. ПРОГРАММА ВЫЧИСЛЯЕТ ЗНАЧЕНИЕ N-ГО ЧИСЛА РЯДА ФИБОНАЧЧИ\n");

                        int numberValue, fibonacciNumber;

                        do
                        {
                            Console.Write("Введите номер числа в ряду Фибоначчи: ");
                            parseResult = int.TryParse(Console.ReadLine(), out numberValue);

                            if (parseResult && numberValue > 0)
                            {
                                fibonacciNumber = CalculateFibonacciNumbers(numberValue);

                                Console.WriteLine($"\n{numberValue} число из ряда Фибоначчи равно {fibonacciNumber}");
                                Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели не число или оно не является натуральным (натуральные числа - это числа, большие нуля). Повторите попытку");
                            }
                        } while (!(parseResult && numberValue > 0));
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

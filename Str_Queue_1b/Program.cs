using System;
using System.Collections.Generic;

namespace Str_Queue_1b
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Введите длину массива:");
            int userMasN;
            while (!int.TryParse(Console.ReadLine(), out userMasN))
            {
                Console.WriteLine("Неверный Ввод числа N! Попробуйте снова:");
            }
            Console.WriteLine("С номера какого элемента начать ввод?");
            int firstIndexOfQ;
            while (!(int.TryParse(Console.ReadLine(), out firstIndexOfQ)) || !(firstIndexOfQ <= userMasN))
            {
                Console.WriteLine("Неверный Ввод индекса первого элемента! Попробуйте снова:");
            }
            Console.WriteLine("Сколько элементов ввести?");
            int amountOfQueueElements;
            while (!(int.TryParse(Console.ReadLine(), out amountOfQueueElements)) || !(amountOfQueueElements <= userMasN - firstIndexOfQ))
            {
                Console.WriteLine("Неверный Ввод количества элементов очереди! Попробуйте снова:");
            }
            string[] massive = new string[userMasN];
            for (int i = firstIndexOfQ; i < amountOfQueueElements + firstIndexOfQ; i++)
            {
                Console.Write($"Введите элемент номер {i}:");
                massive[i] = Console.ReadLine();
            }
            for (int i = firstIndexOfQ; i < amountOfQueueElements + firstIndexOfQ; i++)
            {
                Console.WriteLine($"Элемент №{i} равен {massive[i]}");
            }

            while (true)
            {
                bool isProgrammEnd = false;
                Console.WriteLine("1.Очистить очередь\n2.Проверить, пуста ли очередь\n3.Распечатать очередь\n4.Добавить в конец очереди элемент\n5.Удалить первый элемент из очереди\n6-9 Завершить работу?");
                int userInput = -1;
                while (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Неверный Ввод числа! Попробуйте снова:");
                }
                switch (userInput)
                {
                    case 1:
                        ClearQueue(massive);
                        break;
                    case 2:
                        if (CheckIfQueueIsEmpty(massive))
                        {
                            Console.WriteLine("Очередь пуста!");
                            break;
                        }
                        Console.WriteLine("Очередь не пуста!");
                        break;
                    case 3:
                        PrintQueue(massive);
                        break;
                    case 4:
                        Console.WriteLine("Какой элемент добавить в очередь?");
                        AddToQueue(massive, Console.ReadLine());
                        break;
                    case 5:
                        string str;
                        RemoveFromQueue(massive, out str);
                        if (str != null)
                        {
                            Console.WriteLine($"Был удален элемент:{str}");
                            break;
                        }
                        Console.WriteLine("ИСЧЕРПАНИЕ ОЧЕРЕДИ!");
                        break;
                    default:
                        isProgrammEnd = true;
                        break;
                }
                if (isProgrammEnd)
                {
                    Console.WriteLine("Программа завершила своё выполнение.");
                    break;
                }
            }

            void ClearQueue(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    mass[i] = null;
                }
            }

            bool CheckIfQueueIsEmpty(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        return false;
                }
                return true;
            }

            void PrintQueue(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        Console.WriteLine($"Элемент №{i} очереди:{mass[i]}");
                    }
                }
            }

            void AddToQueue(string[] mass, string str)
            {
                try
                {
                    if (!CheckIfQueueIsEmpty(mass))
                    {
                        for (int i = mass.Length - 1; i > 0; i--)
                        {
                            if (mass[i] != null)
                            {
                                mass[i + 1] = str;
                                break;
                            }
                        }
                    }
                    if (CheckIfQueueIsEmpty(mass))
                    {
                        Console.WriteLine("Очередь пуста! На какое место добавить элемент?");
                        int firstIndexOfQueue;
                        while (!(int.TryParse(Console.ReadLine(), out firstIndexOfQueue)) && !(firstIndexOfQueue <= userMasN))
                        {
                            Console.WriteLine("Неверный Ввод индекса элемента! Попробуйте снова:");
                        }
                        mass[firstIndexOfQueue] = str;
                    }
                }
                catch
                {
                    try
                    {
                        bool isNewElemWasAdded = false;
                        for (int i = 0; i < mass.Length; i++)
                        {
                            if (mass[i] == null)
                            {
                                mass[i] = str;
                                isNewElemWasAdded = true;
                                break;
                            }
                        }
                        if(isNewElemWasAdded)
                        {
                            Console.WriteLine("Очередь достигла правого края!\nНовый элемент был добавлен в начало очереди!");
                        }
                        if (!isNewElemWasAdded)
                        {
                            Console.WriteLine("Очередь заполнена!\nНовый элемент не был добавлен!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ОШИБКА ПЕРЕПОЛНЕНИЯ!");
                    }
                }
            }

            void RemoveFromQueue(string[] mass, out string str)
            {
                str = null;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        str = mass[i];
                        mass[i] = null;
                        break;
                    }
                }
            }
        }
    }
}

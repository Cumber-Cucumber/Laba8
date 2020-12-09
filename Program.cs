using System;
using System.Collections.Generic;
using static Laba8.Class1;
using static Laba8.Laba5;

namespace Laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    Console.WriteLine();

                    MyList<int> list1 = new MyList<int>();
                    list1.Add(1);
                    list1.Add(2);
                    list1.Add(3);

                    MyList<int> list2 = new MyList<int>();
                    list2.Add(4);
                    list2.Add(5);
                    list2.Add(6);

                    CollectionType<MyList<int>> collection1 = new CollectionType<MyList<int>>(); // Коллекция из списков
                    collection1.AddObj(list1);
                    collection1.AddObj(list2);

                    foreach (MyList<int> el in collection1.View()) // Вывод 
                        Print(el); // Ввод списков из коллекции
                    collection1.Delete(list1);
                    collection1.Delete(list2);
                    foreach (MyList<int> el in collection1.View()) // Проверка удаления
                        Print(el); // Ввод списков из коллекции

                    Console.WriteLine("\n-------------------------------------------------------------------------\n");

                    CollectionType<Button> collection2 = new CollectionType<Button>(); // Использование пользовательского типа
                    Button ball1 = new Button("checkbox", 20, true);
                    Button ball2 = new Button("radiobutton", 30, true);
                    collection2.AddObj(ball1);
                    collection2.AddObj(ball2);

                    foreach (Button el in collection2.View()) // Вывод 
                    {
                        Console.Write(el.ToString());
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("-------------------------------------------------------------------------\n");

                    MyList<int> list3 = new MyList<int>();
                    list3.Add(10);
                    list3.Add(11);
                    list3.Add(12);

                    MyList<int> list4 = new MyList<int>();
                    list3.Add(13);
                    list3.Add(14);
                    list3.Add(15);

                    CollectionType<MyList<int>> collection3 = new CollectionType<MyList<int>>();
                    collection3.AddObj(list3);
                    collection3.AddObj(list4);

                    CollectionType<MyList<int>>.Writer(list3);
                    CollectionType<MyList<int>>.Writer(list4);
                    CollectionType<MyList<int>>.Reader();
                }
            }
            static void Print(MyList<int> list)
            {
                var el = list.First;
                while (el != null)
                {
                    Console.Write(el.Value + "->");
                    el = el.Next;
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using static Laba8.Laba5;

namespace Laba8
{
    class Class1
    {
        public interface IGeneric<T> // Обобщённый интерфейс
        {
            void AddObj(T obj);
            void Delete(T obj);
            List<T> View();
        }

        public class CollectionType<T> : IGeneric<T> where T : class // Обобщённый класс, реализующий обощённый интерфейс, с ограничением того, что T может быть только классом
        {
            private List<T> collection;
            public CollectionType()
            {
                collection = new List<T>();
            }
            public void AddObj(T obj)
            {
                collection.Add(obj);
            }

            public void Delete(T obj)
            {
                collection.Remove(obj);
            }

            public List<T> View() { return collection; }




            private static string path = @"E:\Учёба\2_курс\1_семестр\ООП\Laba8\Laba8\text.txt";
            public static void Reader() // Чтение
            {
                StreamReader reader = new StreamReader(path);
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();
            }
            public static void Writer(T element) // Запись
            {
                StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.Default);
                object obj = element as MyList<int>;
                if (obj != null)
                {
                    MyList<int> list = (MyList<int>)obj;
                    var node = list.First;
                    while (node != null)
                    {
                        writer.Write(node.Value.ToString() + "->");
                        node = node.Next;
                    };
                    writer.WriteLine();
                }
                else
                    writer.WriteLine(element);
                writer.Close();
            }
            public void EmptyOrVoid7()
            {
                if (collection.Count == 0)
                    throw new Exception("Нет элементов!");
                foreach (T elem in collection)
                    Console.WriteLine(elem);
            }
        }
    }
}

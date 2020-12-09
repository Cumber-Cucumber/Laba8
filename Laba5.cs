using System;
using System.Collections.Generic;
using System.Text;

namespace Laba8
{
    class Laba5
    {
        public class Button
        {
            internal string type;
            internal int square;
            internal bool clickable;
            public bool Сlickable { get { return clickable; } }
            public int Square { get { return square; } }
            public string Type { get { return type; } }

            public Button()
            {

                type = "";
                square = 0;
                clickable = false;
            }


            public Button(string _type, int _square, bool _clickable)
            {

                type = _type;
                square = _square;
                clickable = _clickable;

            }


            public override string ToString() // Переопределение tostring
            {
                return "Кнопки:\n-Тип:" + type.ToString() + "\n -Площадь:" + clickable.ToString() + "\n-Кликабельность:" + square.ToString() +"\n\n";
            }
            public override int GetHashCode() // Переопределение gethashcode
            {
                return type.GetHashCode() + clickable.GetHashCode() + square.GetHashCode();
            }
            public virtual void Virtual_For_Ball()
            {
                Console.WriteLine("Виртуальный метод кнопки");
            }
            public override bool Equals(object obj) // Переопределение equals
            {
                if (obj.GetType() != GetType())
                    return false;
                if (obj.GetHashCode() != GetHashCode())
                    return false;
                return true;
            }
        }
        public class Item<T>
        {
            public T Value; // Значение элемента
            public Item<T> Next; // Указатель на след. элемент
            public Item(T value, Item<T> next = null)
            {
                Value = value;
                Next = next;
            }
        }

        public class MyList<T> where T : IComparable
        {
            private Item<T> head;
            private Item<T> tail;
            private int count;
            public class Owner
            {
                public int ID;
                public string name;
                public string organisation;
                public Owner()
                {
                    ID = 0;
                    name = null;
                    organisation = null;
                }
            }
            public class Date
            {
                public DateTime date = DateTime.Now;
                public Date()
                {

                }
            }
            public int Count
            {
                get
                {
                    return count;
                }
            }
            public Item<T> First
            {
                get
                {
                    return head;
                }
            }
            public MyList()
            {
            }
            public void AddAfter(Item<T> node, T value)
            {
                Item<T> newNode = new Item<T>(value, node.Next);
                node.Next = newNode;
                count++;
            }
            public void Add(T value)
            {
                if (head == null)
                {
                    head = tail = new Item<T>(value, null);
                    count++;
                }
                else
                {
                    AddAfter(tail, value);
                    tail = tail.Next;
                }
            }
            public void Delete(T value)
            {
                if (head != null)
                {
                    if (head.Value.Equals(value))
                    {
                        head = head.Next;
                        count--;
                        return;
                    }
                }
                var current = head.Next;
                var previous = head;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        previous.Next = current.Next;
                        count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            public Item<T> Find(T value)
            {
                Item<T> ptr = head;
                while (ptr != null)
                {
                    if (ptr.Value.CompareTo(value) == 0)
                        return ptr;
                    ptr = ptr.Next;
                }
                return null;
            }
        }
    }
}

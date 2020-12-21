using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Laba_7.Book
{
    public interface IBook
    {
        bool electronic_analogue();
    }

    public class Book<T>
    {
        public Book(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Book<T> Next { get; set; }
    }

    public class List<T> : IEnumerable<T>  // односвязный список
    {
        public Book<T> head; // головной/первый элемент
        public Book<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Book<T> Book = new Book<T>(data);

            if (head == null)
                head = Book;
            else
                tail.Next = Book;
            tail = Book;

            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Book<T> current = head;
            Book<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Book<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Book<T> Book = new Book<T>(data);
            Book.Next = head;
            head = Book;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Book<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public void info()
        {
            Book<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

    }
}


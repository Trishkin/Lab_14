using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab_14
{
    [Serializable]
    public class Library
    {
        public string NameOfLibrary { get; set; }
        public List<PrintEdition> listOfBooks = new List<PrintEdition>();
        public void PrintInfo()
        {
            foreach (PrintEdition item in listOfBooks)
            {
                
                Console.WriteLine(item.ToString());
              
            }
        }

        public void AfterAge(int age)
        {
            Console.WriteLine($"Books after age");
            foreach (PrintEdition item in listOfBooks)
            {
                if (item.Age < age)
                {
                    Console.WriteLine(item.ToString());
                }             
            }
        }

        public int CountOfTextBooks()
        {
            int count = 0;
            foreach (PrintEdition item in listOfBooks)
            {
                if (item is Textbook)
                   count++;
            }

            Console.WriteLine($"Count of textbooks: {count}");

            return count;
           
        }
        public double PriceOfBooks()
        {
            double price = 0;
            foreach (PrintEdition item in listOfBooks)
            {
                price = price + item.Price;
            }

            Console.WriteLine($"Price of all books: {price}");
            return price;

            
        }

        public void Add(PrintEdition data)
        {
            listOfBooks.Add(data);
            Console.WriteLine(data.NameOfBook + " добавлено успешно");

        }
        public void Remove(PrintEdition data)
        {
            listOfBooks.Remove(data);
            Console.WriteLine(data.NameOfBook + " удалено успешно");
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_14
{
    [Serializable]
    public abstract class PrintEdition
    {
        public string Author, Publisher;
        private string _nameOfBook;
        public string NameOfBook 
        {
            get
            { 
                return _nameOfBook;
            }
            set
            {
                
                
                    _nameOfBook = value;
                
            }
        }

        public int Age { get; set; }
        private double _price;
        public double Price 
        {
            get
            {
                return _price;
            }

            set
            {
                
                    _price = value;
                
            }
        }
        //public virtual void info()
        //{
        //    Console.WriteLine($"Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}");
        //}
        public override string ToString()
        {
            return $"Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}";
        }
    }
}

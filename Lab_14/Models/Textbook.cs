using System;

namespace Lab_14
{
    [Serializable]
    public class Textbook : PrintEdition
    {
        public string Subject { get; set; }

        public override string ToString()
        {
            return ($"Type = {GetType().Name}, Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}, Subject = {Subject}");

        }
        public Textbook()
        {
            Author = "Me";
            Publisher = "You";
            NameOfBook = "PolniiDen";
            Age = 2012;
            Price = 12.18;
            Subject = "Math";
        }
    }
}

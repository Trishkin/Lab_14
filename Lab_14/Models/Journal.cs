using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_14.Models
{
    [Serializable]
    public class Journal : PrintEdition
    {
      
        public string Period { get; set; }

        public override string ToString()
        {

            return ($"Type = {GetType().Name}, Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}, Period = {Period}");

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
       
    }
}

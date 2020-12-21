using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_14.Models
{
    [Serializable]
    public sealed class Magazine : PrintEdition//, IPerson
    {
        public string Theme { get; set; }
      
        public override string ToString()
        {

           return($"Type = {GetType().Name}, Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}, Theme = {Theme}");

        }
    }
}

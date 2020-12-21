using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace Lab_14
{
public class Serializer
{
        Textbook Book = new Textbook();

        public void BinSerialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("bin.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, Book);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект сериализован");
                Console.ResetColor();
            }
        }
        public void BinDeserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("bin.dat", FileMode.OpenOrCreate))
{
                 Textbook Book = (Textbook)formatter.Deserialize(file);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект десериализован");
                Console.ResetColor();
                Console.WriteLine(Book.ToString());
            }
        }
        public void SoapSerialize()
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream file = new FileStream("soap.soap", FileMode.OpenOrCreate))
            {
                List<Textbook> list = new List<Textbook>();
                list.Add(new Textbook());
                list.Add(new Textbook());
                for (int i = 0; i < list.Count; i++)
                {
                    formatter.Serialize(file, list[i]);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект сериализован");
                Console.ResetColor();
            }
        }
        public void SoapDeserialize()
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream file = new FileStream("soap.soap", FileMode.OpenOrCreate))
            {
                List<Textbook> list = new List<Textbook>();
                Textbook Book = new Textbook();
                for (int i = 0; i < 4; i++)
                {
                    list.Add((Textbook)formatter.Deserialize(file));
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект десериализован");
                Console.ResetColor();
                Console.WriteLine(Book.ToString());
            }
        }
        public void JsonSerialize()
        {
            //for(int i=0;i<this.prese)
            string json = JsonConvert.SerializeObject(Book, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("D:\\OOP\\Lab_14\\Lab_14\\bin\\Debug\\json.json", json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Объект сериализован");
            Console.ResetColor();
        }
        public void JsonDeserialize()
        {
            string json = File.ReadAllText("D:\\OOP\\Lab_14\\Lab_14\\bin\\Debug\\json.json");
             Textbook book = JsonConvert.DeserializeObject< Textbook>(json);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Объект десериализован");
        Console.ResetColor();
        Console.WriteLine(book.ToString());
        }
        public void XmlSerialize()
        {
             Textbook book1 = new  Textbook();
            book1.NameOfBook = "LiveForEver";
             Textbook book2 = new  Textbook();
             Textbook book3 = new  Textbook();
             Textbook book4 = new  Textbook();
             Textbook[] books = new  Textbook[] { book1, book2, book3, book4};
            XmlSerializer x = new XmlSerializer(typeof( Textbook[]));
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                x.Serialize(fs, books);
            }
        }
        public void XmlDeserialize()
        {
            XmlSerializer x = new XmlSerializer(typeof( Textbook[]));
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                 Textbook[] newbooks = ( Textbook[])x.Deserialize(fs);

                foreach ( Textbook p in newbooks)
                {
                    Console.WriteLine($"Название книги: {p.NameOfBook} " + 
                        $"Год выпуска: {p.Age}");
                }
            }
        }
        public void XPath()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("books.xml");
            XmlElement RootElement = xml.DocumentElement;
            XmlNode childnode = RootElement.SelectSingleNode(" Textbook[NameOfBook='LiveForEver']");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);
            XmlNodeList childnodes = RootElement.SelectNodes("// Textbook/NameOfBook");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.InnerText);
        }
        public void LINQ_XML()
        {

            XDocument xdoc = new XDocument();
            XElement student = new XElement("Student");
            XAttribute name = new XAttribute("name", "Dima");
            XElement id = new XElement("ID", "1238467");
            XElement age = new XElement("Age", "18");
            // добавляем атрибут и элементы в первый элемент
            student.Add(name);
            student.Add(id);
            student.Add(age);

            // создаем второй элемент
            XElement student2 = new XElement("Student");
            XAttribute name2 = new XAttribute("name", "Kostya");
            XElement id2 = new XElement("ID", "123443");
            XElement age2 = new XElement("Age", "19");
            student2.Add(name);
            student2.Add(id2);
            student2.Add(age2);
            // создаем корневой элемент
            XElement students = new XElement("Students");
            // добавляем в корневой элемент
            students.Add(student);
            students.Add(student2);
            // добавляем корневой элемент в документ
            xdoc.Add(students);
            //сохраняем документ
            xdoc.Save("students.xml");
            XDocument xdocument = XDocument.Load("students.xml");
            var items = from xe in xdocument.Element("Students").Elements("Student")
                        where xe.Element("ID").Value == "1238467"
                        select new Student(xe.Attribute("name").Value, xe.Element("Age").Value);


            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Age}");
        }
    }
    class Student
    {
        public string Name;
        public string Age;
        public Student(string name, string age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}

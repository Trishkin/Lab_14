using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Serializer serializer = new Serializer();
            serializer.BinSerialize();
            serializer.BinDeserialize();
            serializer.SoapSerialize();
            serializer.SoapDeserialize();
            serializer.JsonSerialize();
            serializer.JsonDeserialize();
            serializer.XmlSerialize();
            serializer.XmlDeserialize();
            serializer.XPath();
            serializer.LINQ_XML();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyHomeWork2._0.ReadFromFile
{
    internal class Program
    {
        //траблы: 1 - нужно убрать со словаря как-то Enter,
        //2 - с  каждым запуском прог словарь  в текст.файл добавляет новый , а не заменяет существующий ( возможно, из-за File.AppendAllText)
        static void Main(string[] args)
        {
            string thisLinkFrrom = "E:\\C#\\C# with Timur\\HM10\\text-HM10.txt";


            char n = '"';
            string thisTextAdd = $"{n}Sherlock Holmes{n}, Sir Arthur Conan Doyle.";


            string thisLinkAddDoctionaryTo = "E:\\C#\\C# with Timur\\HM10\\text-HM10 Dictionary.txt";


            WriteLinesToFile writeNewLines = new WriteLinesToFile(thisLinkFrrom, thisTextAdd);



            ReadAllFromFile read = new ReadAllFromFile(thisLinkFrrom);

            read.PrintText();

            read.AddToDictionary();

            read.AddDictionaryToNewFile(thisLinkAddDoctionaryTo);








            //read.AddToHashSet();
        }
    }
}

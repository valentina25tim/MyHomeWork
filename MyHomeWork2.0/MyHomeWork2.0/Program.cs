using System;
using System.IO;

namespace MyHomeWork2._0.ReadFromFile._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string thisLinkFrrom = "C:\\C#project\\MyHomeWork\\MyHomeWork\\MyHomeWork2.0\\MyHomeWork2.0\\ReadFromFile.2\\ReadFrom.txt";

            string thisLinkAddDoctionaryTo = "C:\\C#project\\MyHomeWork\\MyHomeWork\\MyHomeWork2.0\\MyHomeWork2.0\\ReadFromFile.2\\WriteTo.txt";


            ReadAllFromFile read = new ReadAllFromFile(thisLinkFrrom);


            read.DoAction(thisLinkAddDoctionaryTo);


        }
    }
}

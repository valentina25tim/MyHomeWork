using System;
using System.Text;
using System.IO;
using System.Linq;

namespace MyHomeWork2._0.ReadFromFile._2
{
    public class ReadFromFile
    {
        public string ReadText { get; set; }

        public const string SearchPattern = "*_.tst";
        public const string InputFileDefault = "ReadFrom.txt";
        public const string OutputFileDefault = "WriteTo.txt";
        public ReadFromFile(string LinkToFile)
        {
           ReadText = System.IO.File.ReadAllText(LinkToFile);

           //ReadText = System.IO.File.ReadAllText(@GetSystemPath());//*******  
        }
        private static string GetSystemPath()
        {
            var LinkToFile =
                Directory.GetFiles(Directory.GetCurrentDirectory(), SearchPattern).FirstOrDefault();

            if (LinkToFile == null)
            {
                File.Create(InputFileDefault, default, FileOptions.RandomAccess);//*******  ArgumentOutOfRangeException: ?
                LinkToFile = InputFileDefault;
            }
            return LinkToFile;
        }
    }























    //public class WriteToFile
    //{
    //    public string AddText { get; set; }

    //    public WriteToFile(string LinkToFile, string AddText)
    //    {
    //        string addText = AddText + Environment.NewLine;
    //        File.AppendAllText(@LinkToFile, addText, Encoding.UTF8);
    //    }
    //}
}

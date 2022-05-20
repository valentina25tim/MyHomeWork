using System;
using System.Text;
using MyHomeWork2._0.WineHomeWork;

namespace MyHomeWork2._0
{

    internal class Program
    {
        static void Main(string[] args)
        {
            WineHwInit.InFo();

            var wineList = new WineStorage(WineHwInit.Init());

            var resultYear = wineList.GetByYear(new DateTime(2019, 1, 1));
            var resultColor = wineList.GetByColor(WineColor.Red);
            var resultType = wineList.GetByWineType(WineType.Cuvee);
            var resultOlder = wineList.GetTheOldersHarvestYearBottle();







            StringBuilder sb = new StringBuilder();
            //var a1 = "1";
            //var a2 = a1 +"2";

            for (int i = 0; i < 9999; i++)
            {
                sb.Append(i);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

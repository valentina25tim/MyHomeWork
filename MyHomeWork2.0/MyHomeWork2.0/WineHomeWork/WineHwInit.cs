using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork2._0.WineHomeWork
{
    public static class WineHwInit
    {
        public static Wine[] Init()
        {
            var years = new DateTime[]
            {
                new (1985,1,1),
                new (2019,1,1),
                new (2008,1,1),
                new (1997,1,1),
                new (1989,1,1),
                new (2019,1,1),
                new (2001,1,1)
            };

            var wineArray = new Wine[] //  1 - данные для массива
            {
                new Wine(WineColor.White, WineType.Dry,  years[0]),
                new Wine(WineColor.Rose,WineType.Sparkling, years[1]),
                new Wine(WineColor.Red, WineType.Semisweet, years[2]),
                new Wine(WineColor.Rose, WineType.Cuvee, years[3]),
                new Wine(WineColor.Red,WineType.Brut, years[4]),
                new Wine(WineColor.White, WineType.Dry, years[5]),
                new Wine(WineColor.White, WineType.Dry, years[6]),
            };
            return wineArray;
        }
        public static void InFo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Это второй вариант - те же функции, что и в первом.\nСпасибо за ссылку) повзаимствовала весь IEnumerator IEnumerable - это, конечно, очень запутанно. \nНа дэбаге их постаралась разобрать)\n" +
                "Сегодня переписала под DateTime, но ! появиласть проблемка при сорте даты (2019 х 2 вайн),\n поэтому сортировка в трёх циклах. Пока только дата сортится, всё ок и без повтора. \nА вывод массива с сортДатой не правильный - они дублируются ((Наверное, потому что в цикле два таких значения");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

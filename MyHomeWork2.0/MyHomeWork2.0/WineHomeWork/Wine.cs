using System;
using System.Collections;

namespace MyHomeWork2._0.WineHomeWork
{
    public class Wine
    {
        public WineColor Color;
        public WineType Type;
        public DateTime HarvestYear;
        public Wine(WineColor color, WineType wineType, DateTime year)
        {
            Color = color;
            Type = wineType;
            HarvestYear = year;

        }

    }
}

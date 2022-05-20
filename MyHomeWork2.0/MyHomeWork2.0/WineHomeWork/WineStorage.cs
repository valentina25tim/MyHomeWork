using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace MyHomeWork2._0.WineHomeWork
{

    public class WineStorage : IEnumerable, IEnumerator
    {
        private readonly Wine[] _bottle;
        private int _position = -1;

        public WineStorage(Wine[] wineArray)
        {
            _bottle = new Wine[wineArray.Length];

            for (int i = 0; i < wineArray.Length; i++)
            {
                _bottle[i] = wineArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public WineStorage GetEnumerator()
        {
            return new WineStorage(_bottle);
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _bottle.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
        object IEnumerator.Current => Current;

        public Wine Current
        {
            get
            {
                try
                {
                    return _bottle[_position];
                }

                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public IEnumerable<Wine> GetByYear(DateTime date)
        {
            return _bottle.Where(wb => wb.HarvestYear.Year == date.Year).ToArray();

            //public Wine[] GetByYear (DateTime date)
            //{ var findResult = new Wine[_bottle.Length];for (int i = 0; i < _bottle.Length; i++)
            //{if(_bottle[i].HarvestYear.Year == date.Year)
            //    {findResult[i] = _bottle[i];}
            //}return findResult;}
        }
        public IEnumerable<Wine> GetByColor(WineColor color)
        {
            return _bottle.Where(wb => wb.Color == color);
        }
        public IEnumerable<Wine> GetByWineType(WineType wineType)
        {
            return _bottle.Where(wb => wb.Type == wineType);
        }
        public Wine GetTheOldersHarvestYearBottle()
        {
            var minYear = _bottle.Min(wb => wb.HarvestYear.Year);
            // _bottle.First();
            return _bottle.FirstOrDefault(wb => wb.HarvestYear.Year == minYear);
        }
        public bool AnyOlder(int year)
        {
            return _bottle.Any(wb => wb.HarvestYear.Year < year);
        }

    }
}

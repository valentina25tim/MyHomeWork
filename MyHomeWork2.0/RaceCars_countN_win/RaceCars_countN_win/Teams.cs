using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCars_countN_win.RaceCars_countN_win
{
    sealed class Team_1 : BasePlane
    {
        public Team_1(ConsoleColor colorPlane, int speedPlane, char direction) : base(colorPlane, speedPlane, direction) { }

        int positionXLelt = 1;
        protected override void MovePrint(int positionY)
        {
            ". ".PrintAtWihtColor(positionXLelt, positionY, Color);
            Look.PrintAtWihtColor(positionXLelt + 2, positionY, Color);

            positionXLelt++;
        }
    }

    sealed class Team_2 : BasePlane
    {
        public Team_2(ConsoleColor colorPlane, int speedPlane, char direction) : base(colorPlane, speedPlane, direction) { }

        int positionXRight = 1 + (Game.wayPlane * 2);
        protected override void MovePrint(int positionY)
        {
            Look.PrintAtWihtColor(positionXRight - Game.lengthPlane * 2, positionY, Color);
            " .".PrintAtWihtColor(positionXRight - Game.lengthPlane, positionY, Color);

            positionXRight--;
        }
    }
}

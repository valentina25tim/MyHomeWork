using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCars_countN_win.RaceCars_countN_win
{
    public static class Rules
    {
        public static int[]
            AddStepTeam_1,
            AddStepTeam_2;


        static Rules()
        {
            AddStepTeam_1 = AddStepToTeam(Index, CountSteps, CoutGamers);
            AddStepTeam_2 = AddStepToTeam(Index, CountSteps, CoutGamers);
        }

        public static int Index { get; set; }
        public static int CountSteps { get; set; }
        public static int CoutGamers { get; set; }


        public static int[] AddStepToTeam(int index, int countSteps, int countGamer)
        {
            int[] stepArray = new int[countGamer];

            for (var i = 0; i < countGamer; i++)
                stepArray[i] = 0;

            stepArray[index] = countSteps;

            return stepArray;
        }

    }
}

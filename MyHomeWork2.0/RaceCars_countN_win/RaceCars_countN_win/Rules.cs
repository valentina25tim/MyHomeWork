using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCars_countN_win.RaceCars_countN_win
{
    public static class Rules
    {
        public static int[] StepTeam_1 { get; set; }
        public static int[] StepTeam_2 { get; set; }

        public static int Index { get; set; }
        public static int CountSteps { get; set; }
        public static int CoutGamers { get; set; }

        public static int[] CreateEmptyAddaySteps(int countGamer)
        {
            int[] stepList = new int[countGamer];

            for (var i = 0; i < countGamer; i++)
            {
                stepList[i] = 0;
            }
            return stepList;
        }
        public static int[] AddStepToTeam(int index, int countSteps, int[] array)
        {
            array[index] = countSteps;

            return array;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCars_countN_win.RaceCars_countN_win
{
    public class Rules
    {
        public static int
            distance = 30,
            lengthPlane,
            wayPlane;

        static Rules()
        {
            AddStepTeam_1 = AddStepToTeam_1(Index, CountSteps, CoutGamers);
            AddStepTeam_2 = AddStepToTeam_2(Index, CountSteps, CoutGamers);
        }
        public static int[] AddStepTeam_1 { get; set; }
        public static int[] AddStepTeam_2 { get; set; }
        public static int Index { get; set; }
        public static int CountSteps { get; set; }
        public static int CoutGamers { get; set; }


        public static int[] AddStepToTeam_1(int index, int countSteps, int countGamer)
        {
            int[] stepArray = new int[countGamer];
            for (var i = 0; i < countGamer; i++)
                stepArray[i] = 0;

            stepArray[index] = countSteps;

            return stepArray;
        }
        public static int[] AddStepToTeam_2(int index, int countSteps, int countGamer)
        {
            int[] stepArray = new int[countGamer];
            for (var i = 0; i < countGamer; i++)
                stepArray[i] = 0;

            stepArray[index] = countSteps;

            return stepArray;
        }
    }
}

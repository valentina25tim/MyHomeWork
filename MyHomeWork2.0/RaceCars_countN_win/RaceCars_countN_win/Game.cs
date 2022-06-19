using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RaceCars_countN_win.RaceCars_countN_win
{
    public class Game
    {
        public static CancellationTokenSource _cts = new();
        public readonly object _syncLock = new();

        public static List<IPlane> _team_1;
        public static List<IPlane> _team_2;

        public static string[] _name;
        private static string[] _look;


        private readonly char[] _direction = new char[] { '+', '-' };

        public static int
            lengthPlane,
            lengthMaxName,
            wayPlane,
            posTeam_Y = 8,
            posPlane_Y = 13;

        private static int
            posField_Y = 12,
            posName_Y = 4,
            posName_X_1 = 1,
            posName_X_2;


        private List<List<Task>> taskFly;

        private List<Task>
            taskFly_0_gr,
            taskFly_1_gr,
            taskFly_2_gr,
            taskFly_3_gr,
            taskFly_4_gr,
            taskFly_5_gr;

        public Game(string[] name, string[] look)
        {
            if (name.Length == look.Length && name.Length % 2 == 0)
            {
                _name = new string[name.Length];
                _look = new string[name.Length];

                for (var i = 0; i < name.Length; i++)
                {
                    _name[i] = name[i];
                    _look[i] = look[i];
                }

                lengthPlane = Helper.GetMaxLength(_look);
                lengthMaxName = Helper.GetMaxLength(_name);
                wayPlane = Init.distance + lengthPlane;
                posName_X_2 = (lengthMaxName + posTeam_Y) + 6;
            }
            else
            {
                Console.WriteLine("name.Length != look.Length  &&  name.Length %2 == 0\n Init.cs -> [...]");
            }
        }

        public void Start()
        {

            MkTeams();

            PrintField();

            MkTaskName();

            MkTaskFly();
        }


        private void MkTeams()
        {
            _team_1 = new List<IPlane>();
            _team_2 = new List<IPlane>();

            int numb_1 = 1, numb_2 = 1;

            for (var i = 0; i < _name.Length; i++)
            {
                int a = i + 1;

                if (a % 2 != 0)
                    _team_1.Add(new Team_1((ConsoleColor)Helper.GetRandomBetween(1, 15), Helper.GetRandomBetween(Init.minSpeed, Init.maxSpeed), _direction[0])
                    {
                        Name = _name[i],
                        Look = _look[i],
                        NumberPlane = numb_1++
                    });

                if (a % 2 == 0)
                    _team_2.Add(new Team_2((ConsoleColor)Helper.GetRandomBetween(1, 15), Helper.GetRandomBetween(Init.minSpeed, Init.maxSpeed), _direction[1])
                    {
                        Name = _name[i],
                        Look = _look[i],
                        NumberPlane = numb_2++,
                    });
            }
        }

        private void MkTaskName()
        {
            var taskName_1 = new List<Task>();
            var taskName_2 = new List<Task>();

            Helper.CreateTaskName(taskName_1, _team_1, posName_Y, posName_X_1, Init.teamName[0]);
            Helper.CreateTaskName(taskName_2, _team_2, posName_Y, posName_X_2, Init.teamName[1]);
        }
        private void PrintField()
        {
            $"\t== Sky Battle ==".PrintAtWihtColor(0, 0, ConsoleColor.White);

            "=".GetStrWithLength(wayPlane * 2 + 1)
                .PrintAtWihtColor(0, posField_Y, ConsoleColor.White);

            "=".GetStrWithLength(wayPlane * 2 + 1)
                .PrintAtWihtColor(0, posField_Y + (_look.Length) + 1, ConsoleColor.White);

            for (var i = 0; i < 2; i++)
                foreach (var plane in _team_2)
                {
                    var _posPlaneY = posField_Y;

                    posField_Y += 1;

                    "|".PrintAtWihtColor(0, posField_Y, ConsoleColor.White);
                    "|".PrintAtWihtColor((wayPlane * 2), posField_Y, ConsoleColor.White);

                    if (posField_Y % 2 != 0)
                        "+".PrintAtWihtColor(wayPlane, posField_Y + 1, ConsoleColor.White);
                }
        }

        private void GroupCompetition()
        {
            List<Task>[] tasks = { taskFly_0_gr, taskFly_1_gr, taskFly_2_gr, taskFly_3_gr, taskFly_4_gr, taskFly_5_gr };

            taskFly = new List<List<Task>>(_team_1.Count);

            for (var i = 0; i < _team_1.Count; i++)
            {
                int a = i;
                var _posPlaneY = posPlane_Y;

                tasks[a] = new List<Task>();

                tasks[a].Add(new Task(() => _team_1.ElementAt(a).Fly(_posPlaneY, _cts.Token)));
                tasks[a].Add(new Task(() => _team_2.ElementAt(a).Fly(_posPlaneY, _cts.Token)));
                taskFly.Add(tasks[a]);

                posPlane_Y += 2;
            }
        }
        private void MkTaskFly()
        {
            Rules.StepTeam_1 = Rules.CreateEmptyAddaySteps(_team_1.Count);
            Rules.StepTeam_2 = Rules.CreateEmptyAddaySteps(_team_1.Count);

            GroupCompetition();

            for (var i = 0; i < taskFly.Count; i++)
            {
                taskFly.ElementAt(i).ForEach(t => t.Start());
            }
        }
    }
}

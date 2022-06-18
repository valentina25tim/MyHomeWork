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

        private static List<Plane> _team_1;
        private static List<Plane> _team_2;

        public static string[] _name;
        private static string[] _look;

        private readonly string[] _teamName = new string[] { "TEAM 1", "TEAM 2" };
        private readonly char[] _direction = new char[] { '+', '-' };

        private const int
            minSpeed = 50,
            maxSpeed = 200;

        public static int
            distance = 30,
            lengthPlane,
            lengthMaxName,
            wayPlane,
            posTeam_Y = 8,
            posPlane_Y_1 = 13,
            posPlane_Y_2 = 13;

        private static int
            posField_Y = 12,
            posName_Y_1 = 4,
            posName_Y_2 = 4,
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
                wayPlane = distance + lengthPlane;
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
            _team_1 = new List<Plane>();
            _team_2 = new List<Plane>();

            int numb_1 = 1, numb_2 = 1;

            for (var i = 0; i < _name.Length; i++)
            {
                int a = i + 1;

                if (a % 2 != 0)
                    _team_1.Add(new Plane((ConsoleColor)Helper.GetRandomBetween(1, 15), Helper.GetRandomBetween(minSpeed, maxSpeed), _direction[0])
                    {
                        NamePilote = _name[i],
                        LookPlane = _look[i],
                        NumberPilot = numb_1++
                    });

                if (a % 2 == 0)
                    _team_2.Add(new Plane((ConsoleColor)Helper.GetRandomBetween(1, 15), Helper.GetRandomBetween(minSpeed, maxSpeed), _direction[1])
                    {
                        NamePilote = _name[i],
                        LookPlane = _look[i],
                        NumberPilot = numb_2++,
                    });
            }
        }

        private void MkTaskName()
        {
            var taskName_1 = new List<Task>();
            var taskName_2 = new List<Task>();

            Helper.CreateTaskName(taskName_1, _team_1, posName_Y_1, posName_X_1, _teamName[0]);
            Helper.CreateTaskName(taskName_2, _team_2, posName_Y_2, posName_X_2, _teamName[1]);
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
                        "+".PrintAtWihtColor(wayPlane, posField_Y, ConsoleColor.White);
                }
        }

        private void GroupCompetition()
        {
            taskFly = new List<List<Task>>(_team_1.Count);

            taskFly_0_gr = new List<Task>();
            taskFly_1_gr = new List<Task>();
            taskFly_2_gr = new List<Task>();
            taskFly_3_gr = new List<Task>();
            taskFly_4_gr = new List<Task>();
            taskFly_5_gr = new List<Task>();

            for (var i = 0; i < _team_1.Count; i++)
            {
                var _posPlaneY_1 = posPlane_Y_1;
                var _posPlaneY_2 = posPlane_Y_2;

                if (i == 0)
                {
                    taskFly_0_gr.Add(new Task(() => _team_1.ElementAt(0).Fly(_posPlaneY_1, _cts.Token)));
                    taskFly_0_gr.Add(new Task(() => _team_2.ElementAt(0).Fly(_posPlaneY_2, _cts.Token)));
                }
                if (i == 1)
                {
                    taskFly_1_gr.Add(new Task(() => _team_1.ElementAt(1).Fly(_posPlaneY_1, _cts.Token)));
                    taskFly_1_gr.Add(new Task(() => _team_2.ElementAt(1).Fly(_posPlaneY_2, _cts.Token)));
                }
                if (i == 2)
                {
                    taskFly_2_gr.Add(new Task(() => _team_1.ElementAt(2).Fly(_posPlaneY_1, _cts.Token)));
                    taskFly_2_gr.Add(new Task(() => _team_2.ElementAt(2).Fly(_posPlaneY_2, _cts.Token)));
                }
                if (i == 3)
                {
                    taskFly_3_gr.Add(new Task(() => _team_1.ElementAt(3).Fly(_posPlaneY_1, _cts.Token)));
                    taskFly_3_gr.Add(new Task(() => _team_2.ElementAt(3).Fly(_posPlaneY_2, _cts.Token)));
                }
                if (i == 4)
                {
                    taskFly_4_gr.Add(new Task(() => _team_1.ElementAt(4).Fly(_posPlaneY_1, _cts.Token)));
                    taskFly_4_gr.Add(new Task(() => _team_2.ElementAt(4).Fly(_posPlaneY_2, _cts.Token)));
                }
                if (i == 5)
                {
                    taskFly_5_gr.Add(new Task(() => _team_1.ElementAt(5).Fly(_posPlaneY_1, _cts.Token)));
                    taskFly_5_gr.Add(new Task(() => _team_2.ElementAt(5).Fly(_posPlaneY_2, _cts.Token)));
                }

                posPlane_Y_1 += 2;
                posPlane_Y_2 += 2;
            }
            taskFly.Add(taskFly_0_gr);
            taskFly.Add(taskFly_1_gr);
            taskFly.Add(taskFly_2_gr);
            taskFly.Add(taskFly_3_gr);
            taskFly.Add(taskFly_4_gr);
            taskFly.Add(taskFly_5_gr);
        }
        private void MkTaskFly()
        {
            GroupCompetition();

            for (var i = 0; i < taskFly.Count; i++)
            {
                taskFly.ElementAt(i).ForEach(t => t.Start());

            }
        }

    }
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace RaceCars_countN_win.RaceCars_countN_win
{
    public class Plane : IPlane
    {
        private static readonly object _syncLock = new();

        public Plane(ConsoleColor colorPlane, int speedPlane, char direction)
        {
            ColorPlane = colorPlane;
            SpeedPlane = speedPlane;
            Direction = direction;
        }
        public string NamePilote { get; set; }
        public string LookPlane { get; init; }
        public int NumberPilot { get; set; }
        public char Direction { get; set; }
        public int SpeedPlane { get; init; }
        public ConsoleColor ColorPlane { get; init; }
        public int AddStep { get; set; }


        public Task Name(int posY, int posX, string nameTeam)
        {
            int positionVS = Game.lengthMaxName + Game.posTeam_Y;

            lock (_syncLock)
            {
                nameTeam.PrintAtWihtColor(posX, 2, ConsoleColor.White);

                $"{NumberPilot} - {NamePilote}".PrintAtWihtColor(posX, posY, ColorPlane);

                "VS".PrintAtWihtColor(positionVS, posY, ConsoleColor.White);
            }
            return Task.CompletedTask;
        }
        public Task Fly(int positionY, CancellationToken cts)
        {
            var sw = Stopwatch.StartNew();

            int step = 1;
            int positionXLelt = 1;
            int positionXRight = positionXLelt + (Game.wayPlane * 2);

            while (!Game._cts.IsCancellationRequested)
            {
                lock (_syncLock)
                {
                    if (Direction == '+')
                    {
                        ". ".PrintAtWihtColor(positionXLelt, positionY, ColorPlane);
                        LookPlane.PrintAtWihtColor(positionXLelt + 2, positionY, ColorPlane);
                    }
                    else if (Direction == '-')
                    {
                        LookPlane.PrintAtWihtColor(positionXRight - Game.lengthPlane * 2, positionY, ColorPlane);
                        " .".PrintAtWihtColor(positionXRight - Game.lengthPlane, positionY, ColorPlane);
                    }

                    if (positionXLelt == Game.distance - 2)
                    {
                        sw.Stop();

                        if (NumberPilot % 2 != 0)
                        {
                            $"Winner: == {NumberPilot} - {NamePilote} ==".PrintAtWihtColor(Game.wayPlane * 2 + 4, positionY, ColorPlane);
                        }
                        else if (NumberPilot % 2 == 0)
                        {
                            $"Winner: == {NumberPilot} - {NamePilote} ==".PrintAtWihtColor(Game.wayPlane * 2 + 4, positionY, ColorPlane);
                        }
                        $"Time: {((sw.Elapsed.TotalSeconds))} sec.".PrintAtWihtColor((Game.wayPlane + Game.lengthMaxName * 2) * 2 + 10, positionY, ColorPlane);
                        Game._cts.Cancel();
                        break;
                    }

                    else if (positionXLelt < Game.distance)
                    {
                        positionXLelt++;
                        positionXRight--;
                        step++;
                    }
                }
                Thread.Sleep(SpeedPlane);
            }
            return Task.CompletedTask;
        }
    }
}

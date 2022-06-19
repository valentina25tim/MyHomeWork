using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace RaceCars_countN_win.RaceCars_countN_win
{
    public abstract class BasePlane : IPlane
    {
        private static readonly object _syncLock = new();

        public BasePlane(ConsoleColor colorPlane, int speedPlane, char direction)
        {
            Color = colorPlane;
            Speed = speedPlane;
        }
        public string Name { get; set; }
        public string Look { get; init; }
        public int NumberPlane { get; set; }
        public int Speed { get; init; }
        public ConsoleColor Color { get; init; }
        public int AddStep { get; set; }

        protected abstract void MovePrint(int positionY);

        private void WinNamePrint(int positionY, Stopwatch sw)
        {
            $"Winner: == {NumberPlane} - {Name} ==".PrintAtWihtColor(Game.wayPlane * 2 + 4, positionY, Color);
            $"Time: {((sw.Elapsed.TotalSeconds))} sec.".PrintAtWihtColor((Game.wayPlane + Game.lengthMaxName * 2) * 2 + 10, positionY, Color);
        }
        public Task NamePrint(int posY, int posX, string nameTeam)
        {
            int positionVS = Game.lengthMaxName + Game.posTeam_Y;

            lock (_syncLock)
            {
                nameTeam.PrintAtWihtColor(posX, 2, ConsoleColor.White);

                $"{NumberPlane} - {Name}".PrintAtWihtColor(posX, posY, Color);

                "VS".PrintAtWihtColor(positionVS, posY, ConsoleColor.White);
            }
            return Task.CompletedTask;
        }

        public Task Fly(int positionY, CancellationToken cts)
        {
            var sw = Stopwatch.StartNew();

            while (!Game._cts.IsCancellationRequested)
            {
                lock (_syncLock)
                {
                    if ((Init.distance - Game.lengthPlane) * 2 > Rules.StepTeam_1[NumberPlane - 1] + Rules.StepTeam_2[NumberPlane - 1])
                    {
                        lock (_syncLock)
                        {
                            MovePrint(positionY);
                        }
                    }
                    if ((Init.distance - Game.lengthPlane) * 2 == Rules.StepTeam_1[NumberPlane - 1] + Rules.StepTeam_2[NumberPlane - 1])
                    {
                        sw.Stop();
                        lock (_syncLock)
                        {
                            WinNamePrint(positionY, sw);
                        }

                        Game._cts.Cancel();
                    }
                }
                Thread.Sleep(Speed);
            }
            return Task.CompletedTask;
        }
    }
}

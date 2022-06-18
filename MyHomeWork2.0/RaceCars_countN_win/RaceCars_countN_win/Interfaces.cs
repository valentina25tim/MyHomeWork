using System;

namespace RaceCars_countN_win.RaceCars_countN_win
{
    public interface IPlane
    {
        public string NamePilote { get; set; }
        public string LookPlane { get; init; }
        public int NumberPilot { get; set; }
        public char Direction { get; set; }
        public int SpeedPlane { get; init; }
        public ConsoleColor ColorPlane { get; init; }
        
    }
}

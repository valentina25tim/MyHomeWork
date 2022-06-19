using System;


namespace RaceCars_countN_win.RaceCars_countN_win
{
    public static class Init
    {
        public const int
            minSpeed = 50,
            maxSpeed = 200,
            distance = 30;

        public static string[] teamName = new string[] { "TEAM 1", "TEAM 2" };
        public static void Print()
        {
            string[] Name = new[] { "Tom", "Jack", "Rick", "Billy", "Simon", "Sam", "Tom", "Jack", "Tom", "Jack", "Rick", "Billy" };
            string[] Type = new[] { "=}>", "<[+", "=)>", "<{+", "=]>", "<(+", "=}>", "<[+", "=}>", "<[+", "=)>", "<{+" };

            try
            {
                new Game(Name, Type).Start();
            }
            catch
            {
                Console.WriteLine("Something happend  =( ");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

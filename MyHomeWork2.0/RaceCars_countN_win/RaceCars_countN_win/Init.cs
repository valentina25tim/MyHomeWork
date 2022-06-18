using System;


namespace RaceCars_countN_win.RaceCars_countN_win
{
    public class Init
    {
        public void Print()
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

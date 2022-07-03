using System;


namespace FirstController.Controllers
{
    public static class Extensions
    {
        public static int GetRandomBetween(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}

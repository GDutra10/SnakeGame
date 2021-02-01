using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Helper
{
    public static class RandomHelper
    {
        private static Random random = new Random();

        public static int GetRandomBy(int pModulus, int pMaxValue)
        {
            int number = 1;

            do
            {
                number = random.Next(0, pMaxValue);
            } while (number % pModulus != 0);

            return number;
        }

    }
}

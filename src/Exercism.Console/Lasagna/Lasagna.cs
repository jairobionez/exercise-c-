using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Console.Lasagna
{
    public static class Lasagna
    {
        // TODO: define the 'ExpectedMinutesInOven()' method
        public static int ExpectedMinutesInOven()
        {
            return 40;
        }

        // TODO: define the 'RemainingMinutesInOven()' method
        public static int RemainingMinutesInOven(int actualMinute)
        {
            return ExpectedMinutesInOven() - actualMinute;
        }

        // TODO: define the 'PreparationTimeInMinutes()' method
        public static int PreparationTimeInMinutes(int layers)
        {
            return layers * 2;
        }

        // TODO: define the 'ElapsedTimeInMinutes()' method
        public static int ElapsedTimeInMinutes(int layers, int minutesHasBeenOven)
        {
            return PreparationTimeInMinutes(layers) + minutesHasBeenOven;
        }
    }

}

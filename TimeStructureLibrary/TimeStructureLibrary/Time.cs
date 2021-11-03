using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStructureLibrary
{
    public struct Time
    {
        public int Hours;
        public int Minutes;
        public int Seconds;
        public readonly int DurationInSeconds;

        public Time(int hours, int minutes, int seconds)
        {
            if (hours % 1 != 0 || minutes % 1 != 0 || seconds % 1 != 0)
            {
                throw new Exception("Вводимые значения должны быть целочисленными.");
            }
            else if (hours < 0 || minutes < 0 || seconds < 0)
            {
                throw new Exception("Вводимые значения должны быть неотрицательными.");
            }
            else if (minutes > 59 || seconds > 59)
            {
                throw new Exception("Минуты и секунды должы находиться на интервале от 0 до 59.");
            }

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            DurationInSeconds = hours * 3600 + minutes * 60 + seconds;
        }
        public static Time Read()
        {
            int myHours;
            int myMinutes;
            int mySeconds;

            while (true)
            {
                Console.WriteLine("Введите кол-во часов:");
                myHours = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите кол-во минут:");
                myMinutes = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите кол-во секунд:");
                mySeconds = int.Parse(Console.ReadLine());

                if (myHours % 1 != 0 || myMinutes % 1 != 0 || mySeconds % 1 != 0)
                {
                    throw new Exception("Вводимые значения должны быть целочисленными.");
                }
                else if (myHours < 0 || myMinutes < 0 || mySeconds < 0)
                {
                    throw new Exception("Вводимые значения должны быть неотрицательными.");
                }
                else if (myMinutes > 59 || mySeconds > 59)
                {
                    throw new Exception("Минуты и секунды должы находиться на интервале от 0 до 59.");
                }
                else break;
            }

            return new Time(myHours, myMinutes, mySeconds);
        }

        public override string ToString()
        {
            return $"{Hours/10}{Hours%10}:{Minutes/10}{Minutes%10}:{Seconds/10}{Seconds%10}";
        }

        public override bool Equals(object obj1)
        {
            if (obj1 is Time)
            {
                Time t = (Time)obj1;

                return DurationInSeconds == t.DurationInSeconds;
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return DurationInSeconds.GetHashCode();
        }
        public void Display()
        {
            Console.WriteLine($"Структура Time, {Hours/10}{Hours%10}:{Minutes / 10}{Minutes % 10}:{Seconds / 10}{Seconds % 10}");
        }
        public static Time operator +(Time t1, Time t2)
        {
            int mySeconds = t1.DurationInSeconds + t2.DurationInSeconds;
            int myHours = mySeconds / 3600;
            mySeconds %= 3600;
            int myMinutes = mySeconds / 60;
            mySeconds %= 60;
            return new Time(myHours, myMinutes, mySeconds);
        }

        public static Time operator -(Time t1, Time t2)
        {
            if (t1.DurationInSeconds < t2.DurationInSeconds)
            {
                throw new Exception("Первое время не должно быть меньше второго.");
            }
            else
            {
                int mySeconds = t1.DurationInSeconds - t2.DurationInSeconds;
                int myHours = mySeconds / 3600;
                mySeconds %= 3600;
                int myMinutes = mySeconds / 60;
                mySeconds %= 60;
                return new Time(myHours, myMinutes, mySeconds);
            }

        }
        public static Time operator *(Time t1, int x)
        {
            if (x < 0)
            {
                throw new Exception("Для выполнения операции х не должен быть меньше 0");
            }
            else
            {
                int mySeconds = t1.DurationInSeconds * x;
                int myHours = mySeconds / 3600;
                mySeconds %= 3600;
                int myMinutes = mySeconds / 60;
                mySeconds %= 60;
                return new Time(myHours, myMinutes, mySeconds);
            }
        }

    }
}

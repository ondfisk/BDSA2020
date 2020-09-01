using System;
using static Lecture02.TrafficLightColor;

namespace Lecture02
{
    public class TrafficLightController : ITrafficLightController
    {
        public bool MayIGo(string color)
        {
            if (color == "Green")
            {
                return true;
            }
            else if (color == "Yellow")
            {
                return false;
            }
            else if (color == "Red")
            {
                return false;
            }
            else
            {
                throw new ArgumentException("Invalid color");
            }
        }
    }
}

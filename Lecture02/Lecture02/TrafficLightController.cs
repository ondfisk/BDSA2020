using System;
using static Lecture02.TrafficLightColor;

namespace Lecture02
{
    public class TrafficLightController : ITrafficLightController
    {
        public bool MayIGo(TrafficLightColor color)
        {
            switch (color)
            {
                case Green:
                    return true;
                case Yellow:
                case Red:
                    return false;
                default:
                    throw new ArgumentException("Invalid color", nameof(color));
            }
        }
    }
}

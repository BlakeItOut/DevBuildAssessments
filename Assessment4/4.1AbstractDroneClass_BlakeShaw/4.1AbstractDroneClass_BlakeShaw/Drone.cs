using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1AbstractDroneClass_BlakeShaw
{
    abstract class Drone
    {
        private int _totalFlyTime;
        private int _totalDistance;
        public int calculatedSpeed => FlightSpeed();
        public Drone() { }
        public Drone(int totalFlyTime)
        {
            _totalFlyTime = totalFlyTime;
        }
        public Drone(int totalFlyTime, int totalDistance)
        {
            _totalFlyTime = totalFlyTime;
            _totalDistance = totalDistance;
        }
        public virtual int FlightSpeed()
        {
            return _totalDistance / _totalFlyTime;
        }
    }
}

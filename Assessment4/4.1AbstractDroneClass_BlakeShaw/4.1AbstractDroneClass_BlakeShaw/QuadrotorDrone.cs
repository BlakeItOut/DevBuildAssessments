using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1AbstractDroneClass_BlakeShaw
{
    class QuadrotorDrone : Drone
    {
        private int _totalFlyTime1;
        private int _totalDistance1;
        public QuadrotorDrone (int totalFlyTime, int totalDistance) : base(totalFlyTime, totalDistance)
        {
            _totalFlyTime1 = totalFlyTime;
            _totalDistance1 = totalDistance;
        }
        public override int FlightSpeed() => _totalDistance1/_totalFlyTime1;
    }
}

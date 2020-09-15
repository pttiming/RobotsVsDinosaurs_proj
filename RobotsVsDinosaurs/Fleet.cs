using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Fleet
    {
        //Member Variable
        public List<Robot> robots;
        public string fleetName;

        //Constructor
        public Fleet()
        {
            List<Robot> robots = new List<Robot>();
        }
        //Methods
        public void AddRobotToFleet(Robot robot)
        {
            robots.Add(robot);
        }

    }
}

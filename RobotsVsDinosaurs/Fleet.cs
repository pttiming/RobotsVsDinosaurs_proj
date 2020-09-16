﻿using System;
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
        public bool fleetIsAlive;
        public string fleetName;
        public double fleetHealth;

        //Constructor
        public Fleet()
        {
            robots = new List<Robot>();
            fleetIsAlive = true;
        }
        //Methods
        public void AddRobotToFleet(Robot robot)
        {
            robots.Add(robot);
        }
        public double CheckFleetHealth()
        {
            double fleetHealth;
            fleetHealth = robots.Sum(robots => robots.robotHealth);
            return fleetHealth;
        }

        public void ListFleet()
        {
            foreach (Robot robot in robots)
            {
                Console.WriteLine($"Name: {robot.robotName} Health: {robot.robotHealth} Energy: { robot.robotPowerLevel}");
                Console.WriteLine($"Weapon: {robot.defaultWeapon.weaponType} Attack Power: {robot.defaultWeapon.weaponAttackPower}");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Robot
    {
        //member variables
        public string robotName;
        public double robotHealth;
        public double robotPowerLevel;
        public Weapon defaultWeapon;
        public bool robotIsAlive;

        //constructor
        public Robot(string robotName, Weapon defaultWeapon)
        {
            robotHealth = 100;
            robotPowerLevel = 100;
            robotIsAlive = true;
            this.robotName = robotName;
            this.defaultWeapon = defaultWeapon;
        }

        //methods
        public void CheckRobotLife()
        {
            if (robotHealth <= 0)
            {
                robotHealth = 0;
                robotIsAlive = false;
                Console.WriteLine(robotName + "has died");
            }
            else
            {
                Console.WriteLine(robotName + " has " + robotHealth + " health remainig");
            }
        }
        public void AttackDinosaur()
        {

        }

        public void IncomingRobotAttack(double damage)
        {
            robotHealth -= damage;
            CheckRobotLife();
        }
    }
}

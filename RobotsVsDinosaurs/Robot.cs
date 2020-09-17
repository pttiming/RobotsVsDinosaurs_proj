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
        public string robotFleet;

        //constructor
        public Robot(string robotName)
        {
            robotHealth = 50;
            robotPowerLevel = 100;
            robotIsAlive = true;
            this.robotName = robotName;
        }

        //methods
        //Checks to see if Robot is still alive, if not, sets alive to false
        public void CheckRobotLife()
        {
            if (robotHealth <= 0)
            {
                robotHealth = 0;
                robotIsAlive = false;
                Console.WriteLine(robotName + " has died");
            }
            else
            {
                Console.WriteLine(robotName + " has " + robotHealth + " health remainig");
            }
        }
        //Damages opposing Dinosaurs health 
        public void AttackDinosaur(Dinosaur dinosaur)
        {
                dinosaur.IncomingRobotAttack(defaultWeapon.weaponAttackPower);
        }

        //Reduces Dinosaurs Health as a result of incoming attack
        public void IncomingDinosaurAttack(double damage)
        {
            robotHealth -= damage;
            CheckRobotLife();
        }
        //Decreases Energy after attack
        public void PostAttackEnergy()
        {
            robotPowerLevel -= 10;
            if(robotIsAlive == true)
            {
                Console.WriteLine(robotName + "'s Energy now at: " + robotPowerLevel);
            }

            
        }
    }
}

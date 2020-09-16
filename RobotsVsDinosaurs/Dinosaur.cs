using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Dinosaur
    {
        //Member Variable
        public string dinosaurType;
        public double dinosaurHealth;
        public double dinosaurPowerLevel;
        public double dinosaurAttackPower;
        public bool dinosaurIsAlive;
        public string dinosaurHerd;

        //Constructor
        public Dinosaur(string dinosaurType, double dinosaurAttackPower)
        {
            this.dinosaurType = dinosaurType;
            dinosaurHealth = 1;
            dinosaurPowerLevel = 100;
            dinosaurIsAlive = true;
            this.dinosaurAttackPower = dinosaurAttackPower;

        }
        //Methods
        public void CheckDinosaurLife()
        {
            if (dinosaurHealth <= 0)
            {
                dinosaurHealth = 0;
                dinosaurIsAlive = false;
                Console.WriteLine(dinosaurType + "has died");
            }
            else
            {
                Console.WriteLine(dinosaurType + " has " + dinosaurHealth + " health remainig");
            }
        }

        public void AttackRobot(Robot robot)
        {
           
                robot.IncomingDinosaurAttack(dinosaurAttackPower);

        }
        public void IncomingRobotAttack(double damage)
        {
            dinosaurHealth -= damage;
            CheckDinosaurLife();


        }
    }
}

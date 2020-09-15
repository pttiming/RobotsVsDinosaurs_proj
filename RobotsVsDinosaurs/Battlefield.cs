using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Battlefield
    {
        //Member Variable

        //Constructor

        //Methods
        public void InitializeRobots()
        {
            //Instantiates New Weapons for a Game
            Weapon weaponOne = new Weapon("Sword", 5);
            Weapon weaponTwo = new Weapon("Axe", 5);
            Weapon weaponThree = new Weapon("Mace", 7);
           
            //Instantiates New Robots
            Robot robotOne = new Robot("Bracer", weaponOne);
            Robot robotTwo = new Robot("Gash", weaponTwo);
            Robot robotThree = new Robot("Ace", weaponThree);
           
            //Instantiates and adds Robots to Fleet
            Fleet fleetOne = new Fleet();
            fleetOne.AddRobotToFleet(robotOne);
            fleetOne.AddRobotToFleet(robotTwo);
            fleetOne.AddRobotToFleet(robotThree);

            //Prints Summary of Fleet and Lists Weapons for each Robot
            Console.WriteLine("Fleet Created!  Meet the Robots:");
            foreach (Robot robot in fleetOne.robots)
            {
                Console.WriteLine($"Name: {robot.robotName}");
                Console.WriteLine($"Weapon: {robot.defaultWeapon.weaponType}");

            }
        }
        public void InitializeDinosaurs()
        {
            //Instantiates New Dinosaurs
            Dinosaur dinoOne = new Dinosaur("T-Rex", 5);
            Dinosaur dinoTwo = new Dinosaur("Raptor", 7);
            Dinosaur dinoThree = new Dinosaur("Brontosaurus", 5);

            //Instantiates Herd and adds Dinosaurs to Herd
            Herd herdOne = new Herd();
            herdOne.dinosaurs.Add(dinoOne);
            herdOne.AddDinosaurToHerd(dinoTwo);
            herdOne.AddDinosaurToHerd(dinoThree);

            //Prints Summary of Herd and Lists each Dinosaur's attack Power
            Console.WriteLine("Herd Created! Meet the Dinosaurs:");
            foreach (Dinosaur dinosaur in herdOne.dinosaurs)
            {
                Console.WriteLine($"Name: {dinosaur.dinosaurType}");
                Console.WriteLine($"Weapon: {dinosaur.dinosaurAttackPower}");

            }
        }

    }
}

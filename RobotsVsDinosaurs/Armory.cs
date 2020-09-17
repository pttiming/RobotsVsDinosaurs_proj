using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Armory
    {
        //member variables
        public List<Weapon> weapons;

        //constructor
        public Armory()
        {
            weapons = new List<Weapon>();
        }

        //methods
        public void AddWeaponToArmory(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void AssignWeapontoRobot(Robot robot)
        {
            Console.WriteLine($"Please Select a Weapon for {robot.robotName}");
            int weaponsInArmory = weapons.Count;
            for(int i = 0; i < weaponsInArmory; i++)
            {
                int weaponNumber = i + 1;
                Console.WriteLine($"{weaponNumber}. {weapons[i].weaponType}");
            }
            string userInput = Console.ReadLine();
            int weaponIndex = int.Parse(userInput);

            robot.defaultWeapon = weapons[weaponIndex-1];
        }

        public void ComputerPlayerWeapons(Robot robot)
        {
            int weaponsInArmory = weapons.Count;
            for (int i = 0; i < weaponsInArmory; i++)
            {
                robot.defaultWeapon = weapons[i];
            }

            
        }
        
    }
}

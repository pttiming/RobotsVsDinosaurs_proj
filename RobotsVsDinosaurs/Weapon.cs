using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Weapon
    {
        //Member Variable
        public string weaponType;
        public double weaponAttackPower;

        //Constructor
        public Weapon(string weaponType, double weaponAttackPower)
        {
            this.weaponType = weaponType;
            this.weaponAttackPower = weaponAttackPower;
        }

        //Methods
    }
}

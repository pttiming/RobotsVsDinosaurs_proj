using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    public class Herd
    {
        //Member Variable
        public List<Dinosaur> dinosaurs;
        public bool herdIsAlive;
        public double herdHealth;
        public string herdName;
        
        //Constructor
        public Herd()
        {
            dinosaurs = new List<Dinosaur>();
            herdIsAlive = true;

        }
        //Methods

        //Adds a Dinosaur to a Herd
        public void AddDinosaurToHerd(Dinosaur dinosaur)
        {
            dinosaurs.Add(dinosaur);
        }
        //Lists the attribuites for each Dinosaur in the herd
        public void ListHerd()
        {
            foreach (Dinosaur dinosaur in dinosaurs)
            {
                Console.WriteLine($"Name: {dinosaur.dinosaurType} Health: {dinosaur.dinosaurHealth}");
                Console.WriteLine($"Energy: {dinosaur.dinosaurPowerLevel} Power: {dinosaur.dinosaurAttackPower}");
            }
        }
        //Checks the aggregate health of the herd
        public double CheckHerdHealth()
        {
            double herdHealth;
            herdHealth = dinosaurs.Sum(dinosaurs => dinosaurs.dinosaurHealth);
            return herdHealth;
        }
         
    }
}

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
        Herd activeHerd;
        Fleet activeFleet;
        string goodGuy;
        string badGuy;
        string playerTeam;
        string computerTeam;
        bool playAsRobot;
        Armory activeArmory;
        string[] activeAttacks;

        //Constructor
        public Battlefield()
        {
            activeArmory = InitilizeArmory();
            
            


        }

        //Methods

        //Adds Weapons to Armory
        public Armory InitilizeArmory()
        {
            Armory armory = new Armory();

            return armory;
        }

        public void ArmRobots()
        {
            int totalRobots = activeFleet.robots.Count;
            for(int i = 0; i < totalRobots; i++ )
            activeArmory.AssignWeapontoRobot(activeFleet.robots[i]);
        }

        public void ArmComputerRobots()
        {
            int totalRobots = activeFleet.robots.Count;
            for (int i = 0; i < totalRobots; i++)
                activeArmory.ComputerPlayerWeapons(activeFleet.robots[i]);
        }
        public Fleet InitializeRobots()
        {
            ////Instantiates New Weapons for a Game & Adds to Armory
            Weapon weaponOne = new Weapon("Sword", 5);
            activeArmory.AddWeaponToArmory(weaponOne);
            Weapon weaponTwo = new Weapon("Axe", 5);
            activeArmory.AddWeaponToArmory(weaponTwo);
            Weapon weaponThree = new Weapon("Mace", 7);
            activeArmory.AddWeaponToArmory(weaponThree);

            //Instantiates New Robots
            Robot robotOne = new Robot("Bracer");
            Robot robotTwo = new Robot("Gash");
            Robot robotThree = new Robot("Ace");
           

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
                Console.WriteLine();

            }
            return fleetOne;
        }
        public Herd InitializeDinosaurs()
        {
            //Instantiate Attack Types
            string[] dinoAttacks = new string[3];
            dinoAttacks[0] = "Bite";
            dinoAttacks[1] = "Claw";
            dinoAttacks[2] = "Kick";
            activeAttacks = dinoAttacks;


            //Instantiates New Dinosaurs
            Dinosaur dinoOne = new Dinosaur("T-Rex", 5);
            Dinosaur dinoTwo = new Dinosaur("Raptor", 7);
            Dinosaur dinoThree = new Dinosaur("Brontosaurus", 5);

            //Instantiates Herd and adds Dinosaurs to Herd
            Herd herdOne = new Herd();
            herdOne.AddDinosaurToHerd(dinoOne);
            herdOne.AddDinosaurToHerd(dinoTwo);
            herdOne.AddDinosaurToHerd(dinoThree);

            //Prints Summary of Herd and Lists each Dinosaur's attack Power
            Console.WriteLine("Herd Created! Meet the Dinosaurs:");
            foreach (Dinosaur dinosaur in herdOne.dinosaurs)
            {
                Console.WriteLine($"Name: {dinosaur.dinosaurType}");
                Console.WriteLine();

            }
            return herdOne;
        }

        public void InitiateAttack()
        {
            int attackerIndex;
            int attackeeIndex;
            int attackResult;
            double herdHealth; 
            double fleetHealth;

            if (playAsRobot == true)
            {
                int herdSize = activeHerd.dinosaurs.Count;
                Console.WriteLine("Which Dinosaur would you like to attack?");
                for (int i = 0; i < herdSize; i++)
                {
                    int option = i + 1;
                    if(activeHerd.dinosaurs[i].dinosaurIsAlive == true)
                    {
                        Console.WriteLine($"{option}: {activeHerd.dinosaurs[i].dinosaurType}");
                    }
                    
                }
                string userInput = Console.ReadLine();
                attackeeIndex = int.Parse(userInput) - 1;
                
                int fleetSize = activeFleet.robots.Count;
                Console.WriteLine("Which Robot would you like to use in your attack?");
                for (int i = 0; i < fleetSize; i++)
                {
                    int optionTwo = i + 1;
                    if (activeFleet.robots[i].robotIsAlive == true)
                    {
                        Console.WriteLine($"{optionTwo}: {activeFleet.robots[i].robotName}");
                    }
                    
                }
                string userInputTwo = Console.ReadLine();
                attackerIndex = int.Parse(userInputTwo) - 1;
                
            }
            else
            {
                int FleetSize = activeFleet.robots.Count;
                Console.WriteLine("Which Robot would you like to attack?");
                for (int i = 0; i < FleetSize; i++)
                {
                    int optionTwo = i + 1;
                    if(activeFleet.robots[i].robotIsAlive == true)
                    {
                        Console.WriteLine($"{optionTwo}: {activeFleet.robots[i].robotName}");
                    }
                    
                }
                string userInputTwo = Console.ReadLine();
                attackeeIndex = int.Parse(userInputTwo) - 1;
                

                int herdSize = activeHerd.dinosaurs.Count;
                Console.WriteLine("Which Dinosaur would you like to use to attack?");
                for (int i = 0; i < herdSize; i++)
                {
                    int option = i + 1;
                    if(activeHerd.dinosaurs[i].dinosaurIsAlive == true)
                    {
                        Console.WriteLine($"{option}: {activeHerd.dinosaurs[i].dinosaurType}");
                    }
                    
                    
                }
                string userInput = Console.ReadLine();
                attackerIndex = int.Parse(userInput) - 1;
                
                SelectDinosaurAttackStyle(activeHerd.dinosaurs[attackerIndex]);


            }
            attackResult = DetermineAttackResult();

            if(attackResult == 1 && playAsRobot == true)
            {
                Console.WriteLine("Successful Attack");
                activeFleet.robots[attackerIndex].AttackDinosaur(activeHerd.dinosaurs[attackeeIndex]);
                herdHealth = activeHerd.CheckHerdHealth();
                activeFleet.robots[attackerIndex].PostAttackEnergy();

                if (herdHealth <= 0)
                {
                    RobotWin();
                }
                else
                {
                    GameMenu();
                }

            }
            else if(attackResult == 0 && playAsRobot == true)
            {
                Console.WriteLine($"Unsuccessful Attack!  You have been counter attacked by {activeHerd.dinosaurs[attackeeIndex].dinosaurType}");
                activeHerd.dinosaurs[attackeeIndex].AttackRobot(activeFleet.robots[attackerIndex]);
                fleetHealth = activeFleet.CheckFleetHealth();
                activeFleet.robots[attackerIndex].PostAttackEnergy();
                if (fleetHealth <= 0)
                {
                    DinosaurWin();
                }
                else
                {
                    GameMenu();
                }

            }
            else if (attackResult == 2 && playAsRobot == true)
            {
                Console.WriteLine("The attack has ended in a stalemate!  You have taken no damage, nor have you inflicted any");
                activeFleet.robots[attackerIndex].PostAttackEnergy();
                GameMenu();
            }
            else if (attackResult == 1 && playAsRobot == false)
            {
                Console.WriteLine("Successful Attack");
                activeHerd.dinosaurs[attackerIndex].AttackRobot(activeFleet.robots[attackeeIndex]);
                fleetHealth = activeFleet.CheckFleetHealth();
                activeHerd.dinosaurs[attackerIndex].PostAttackEnergy();
                if (fleetHealth <= 0)
                {
                    DinosaurWin();
                }
                else
                {
                    GameMenu();
                }

            }
            else if (attackResult == 0 && playAsRobot == false)
            {
                Console.WriteLine($"Unsuccessful Attack!  You have been counter attacked by {activeFleet.robots[attackeeIndex].robotName}");
                activeFleet.robots[attackeeIndex].AttackDinosaur(activeHerd.dinosaurs[attackerIndex]);
                herdHealth = activeHerd.CheckHerdHealth();
                activeHerd.dinosaurs[attackerIndex].PostAttackEnergy();
                if (herdHealth <= 0)
                {
                    RobotWin();
                }
                else
                {
                    GameMenu();
                }


            }
            else if (attackResult == 2 && playAsRobot == false)
            {
                Console.WriteLine("The attack has ended in a stalemate!  You have taken no damage, nor have you inflicted any");
                activeHerd.dinosaurs[attackerIndex].PostAttackEnergy();
                GameMenu();
            }
            

          
            
        }

        public void GameMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine($"1. View My {playerTeam}");
            Console.WriteLine($"2. Attack a {badGuy}");
            Console.WriteLine("3. Exit Game");
            
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    if(playAsRobot == false)
                    {
                        activeHerd.ListHerd();
                        GameMenu();
                    }
                    else
                    {
                        activeFleet.ListFleet();
                        GameMenu();
                    }
                    break;
                case "2":
                    InitiateAttack();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    GameMenu();
                    break;
            }

        }

        public void StartGame()
        {
            //activeFleet = InitializeRobots();
            //activeHerd = InitializeDinosaurs();
            Console.WriteLine("Welcome to Robots vs. Dinosaurs");
            Console.WriteLine("Would you like to play as Robots or Dinosaurs?");
            Console.WriteLine("1. Robots");
            Console.WriteLine("2. Dinosaurs");
            Console.WriteLine("3. Exit Game");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    goodGuy = "Robot";
                    playerTeam = "Fleet";
                    playAsRobot = true;
                    badGuy = "Dinosaur";
                    computerTeam = "Herd";
                    activeFleet = InitializeRobots();
                    activeHerd = InitializeDinosaurs();
                    ArmRobots();
                    RunGame();
                    Console.Clear();
                    break;
                case "2":
                    goodGuy = "dinosaur";
                    playerTeam = "Herd";
                    badGuy = "Robot";
                    computerTeam = "Fleet";
                    playAsRobot = false;
                    activeHerd = InitializeDinosaurs();
                    activeFleet = InitializeRobots();
                    ArmComputerRobots();
                    RunGame();
                    Console.Clear();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    RunGame();
                    break;

            }
        }

        public void RunGame()
        {
            Console.WriteLine($"Name your {playerTeam}");
            string userInput = Console.ReadLine();
            if(playAsRobot == true)
            {
                activeFleet.fleetName = userInput;
                activeHerd.herdName = "Enemy Herd";
                Console.Clear();
                Console.WriteLine(activeFleet.fleetName + " Vs. " + activeHerd.herdName);
                Console.WriteLine();
            }
            else
            {
                activeHerd.herdName = userInput;
                activeFleet.fleetName = "Enemy Fleet";
                Console.Clear();
                Console.WriteLine(activeHerd.herdName + " Vs. " + activeFleet.fleetName);
                Console.WriteLine();
            }

            GameMenu();
        }

        public int DetermineAttackResult()
        {
            int playerRoll;
            int computerRoll;
            int rollResult;

            playerRoll = RollDice(20);
            Console.WriteLine($"You have rolled a {playerRoll}");
            System.Threading.Thread.Sleep(500);
            computerRoll = RollDice(20);
            Console.WriteLine($"Computer has rolled a {computerRoll}");

            rollResult = CompareRolls(playerRoll, computerRoll);
            return rollResult;

        }

        public int RollDice(int number)
        {
            Random rand;
            rand = new Random();
            return rand.Next(number);
        }

        public int CompareRolls(int playerRoll, int computerRoll)
        {
            if(playerRoll > computerRoll)
            {
                return 1;
            }
            else if(playerRoll < computerRoll)
            {
                return 0;
            }
            else
            {
                return 2;
            }

        }
        public void DinosaurWin()
        {
            Console.WriteLine("The Robots have defeated the Herd!");
            Console.WriteLine("Would you like to play again? Y or N");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                case "Y":
                    StartGame();
                    break;
                case "n":
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public void RobotWin()
        {
            Console.WriteLine("The Dinosaurs have defeated the Robots!");
            Console.WriteLine("Would you like to play again? Y or N");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                case "Y":

                    StartGame();
                    break;
                case "n":
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        public void SelectDinosaurAttackStyle(Dinosaur dinosaur)
        {
            Console.WriteLine("How would you like the Dinosaur to attack?");
            
            for(int i = 0; i < 3; i++)
            {
                int attackOption = i + 1;
                Console.WriteLine($"{attackOption}: {activeAttacks[i]}");
            }
            string userInput = Console.ReadLine();
            int attackIndex = int.Parse(userInput) - 1;
            Console.WriteLine(dinosaur.dinosaurType + activeAttacks[attackIndex] + "s the robot");
        }
        public void AttackeeMenu()
        {

        }

    }
}

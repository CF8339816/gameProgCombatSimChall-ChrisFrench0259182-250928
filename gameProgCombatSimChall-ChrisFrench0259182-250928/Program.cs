using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameProgCombatSimChall_ChrisFrench0259182_250928
{   // references for code
    // google search for "code a random to pull a number then discard it from the next random in c#"
    // google search for "how to reference a value in an array to change it in c#"
    // old assignment code from  myself for this course
    // notes from class
    internal class Program
    {
        //Variables here

        static string[] enemyChar = {"Evil Larry", "Evil Barry", "Evil Gary", "Evil Kerry" };
        static int[] enemyHealth = { 100, 125, 90, 200 };  // Enemy health
        static int[] enemyselect = new int [4];
        static int health = 100;   // Player Health
        static string[] weapon = { "fist", "pistol", "rifle", "gernade" };
        static int[] Dmg = { 5, 15, 50, 100 };
      
        
        static string Character; // initalizes  variable
        //static string wepType = "big stick"; // initalizes  variable
        static string hStat = "Catch Phrase!";
        static int ESmin = 1;
        static int ESmax = 4; 
        static void Main(string[] args)
        {

            List<int> enemyChoices = new List<int>();
            for (int i = ESmin; i <= ESmax; i++)
            {
                enemyChoices.Add(i);
            }
            Random random = new Random();
           
            while (enemyChoices.Count > 0)   // Loop to pull and discard numbers
            {
               int randomIndex = random.Next(0, enemyChoices.Count);  // Generate a random index within the bounds of the current list
               int chosenNumber = enemyChoices[randomIndex];   // Get the number at the random index
               
                //int selectEnemy = random.Next(1, 5);

            if (enemyChoices = 1) 
            {
                enemyChar = [ "Evil Larry"];
                enemyHealth = [0];
            }
            else if (enemyChoices = 2) 
            {
                enemyChar[1];
                int enemyHealth[1];
            }
            else if (enemyChoices = 3) 
            {
                enemyChar[2];
                int enemyHealth[2];
            }
            else if (enemyChoices = 4) 
            {
                enemyChar[3];
                int enemyHealth[3];
            }

        }




       // eLifeChk();








        }
        //methods below here
        
        //meth1
        /*
        static void eLifeChk()
        {
            bool isEnemyDead = false; //  check to see if enemy is dead

            while (!isEnemyDead)   //while enemy is  not dead this will continue player attack in loop
            {
                if (enemyHealth >= 0)
                {
                    Console.WriteLine($"Your enemy yet lives, your task is not yet complete. " + "\n " + "\n ");
                    weaponSelector();
                    combatdmg();
                }
                else
                {
                    Console.WriteLine("you have slain your enemy. You can rest easy until your next inevitable combat." + "\n");
                    weapon = 0;  //modify weapon value based on user input  to  weaponSelect.
                    break; // breaks the  loop

                }

            }
        }
        */
        //meth2
        static void combatdmg()
        {
            switch (weapon)
            {
                case 0:
                    Console.WriteLine($"You Fist the enemy for {Dmg[0]} damage. ");
                    DealDamageToEnemy(5);

                    break;

                case 1:
                    Console.WriteLine($"You shoot the enemy for {Dmg[1]} damage. ");
                    DealDamageToEnemy(15);

                    break;

                case 2:
                    Console.WriteLine($"You explodinate the enemy for {Dmg[2]} damage. ");
                    DealDamageToEnemy(50);
                    weapon = 0;
                    break;

                case 3:
                    Console.WriteLine($"You snipe the enemy for {Dmg[3]} damage. ");
                    DealDamageToEnemy(100);
                    break;

                default:
                    Console.WriteLine("Weapon was not packed in you kit. Please choose again.");

                    break;

            }

        }
        //meth3
        static void statsBlock()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (health == 100)
            {
                hStat = "Fit as a fiddle";
            }
            else if (health > 75)
            {
                hStat = "Healthy as a horse";
            }
            else if (health > 50)
            {
                hStat = "Feeling fine";
            }
            else if (health > 25)
            {
                hStat = "Little winded";
            }
            else if (health > 10)
            {
                hStat = "Just a flesh wound";
            }
            else if (health <= 0)
            {
                hStat = "Dead as a doornail";
            }

            Console.WriteLine("{0,0}{1,15}{2,12}", "life", "condition", "weapon");

            Console.Write("{0,2}", health);
            Console.Write("{0,17}", hStat);
            Console.WriteLine("{0,15}", weapon[0] + "\n");

            //Console.WriteLine("{0,2}{1,13}{2,14}", health, hStat, wepType + "\n");
        }

        //meth4
        /*
        static void LifeStat()

        {
            if (health == 100)
            {
                hStat = "Fit as a fiddle";
            }
            else if (health > 75)
            {
                hStat = "Healthy as a horse";
            }
            else if (health > 50)
            {
                hStat = "Feeling fine";
            }
            else if (health > 25)
            {
                hStat = "Little winded";
            }
            else if (health > 10)
            {
                hStat = "Just a flesh wound";
            }
            else if (health <= 0)
            {
                hStat = "Dead as a doornail";
            }

         }
          */

        //meth5
        static void HUD()
        {
            statsBlock();
            //LifeStat();
        }

        //meth6
        static void weaponSelector()
        {
            Console.WriteLine(" Please choose a weapon: 0 = Fist, 1 = Pistol, 2 = Rocket Launcher, 3 = Sniper Rifle" + "\n");

            string weaponSelect = Console.ReadLine(); //store  weapon  selection
            if (int.TryParse(weaponSelect, out weapon[]))
            {
                if (weaponSelect == "0")
                {
                    Console.WriteLine("You choose to attack your enemy with your Bare Hands. " + "\n");
                     weapon = weapon[0];  //modify weapon value based on user input  to  weaponSelect.
                    //wepType = "Fist";  // modify weapon description in stats 
                }
                else if (weaponSelect == "1")
                {
                    Console.WriteLine("You choose to attack your enemy with your trusty Pistol. " + "\n");
                    weapon = int weapon[1];  //modify weapon value based on user input  to  weaponSelect.
                    //wepType = "Pistol";  // modify weapon description in stats
                }
                else if (weaponSelect == "3")
                {
                    Console.WriteLine("You choose to attack your enemy with a FRIKKIN Gernade... Overkill much? " + "\n");
                    weapon = int weapon[3];  //modify weapon value based on user input  to  weaponSelect.
                   // wepType = "Gernade";  // modify weapon description in stats
                }
                else if (weaponSelect == "2")
                {
                    Console.WriteLine("You choose to attack your enemy with a sleek andd stylish Sniper Rifle. Woot Headshot! " + "\n");
                    weapon = int weapon[2];  //modify weapon value based on user input  to  weaponSelect.
                   // wepType = "Sniper Rifle";  // modify weapon description in stats
                }
                else
                {
                    Console.WriteLine("You  did not have room totake that weapon with you it is at home in your footlocker." + "\n");
                    weapon = int weapon[0];  //modify weapon value based on user input  to  weaponSelect.
                   // wepType = "Fist";  // modify weapon description in stats
                }

            }
        }
        //meth7
        


    }
}

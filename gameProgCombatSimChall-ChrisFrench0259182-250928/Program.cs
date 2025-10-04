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

        static string[] enemyChar = {"Evil Larry", "Evil Barry", "Evil Gary", "Evil Kerry" };// enemy  names
        static int[] enemyHealth = { 100, 125, 90, 200 };  // Enemy health
        
        static int health = 100;   // Player Health
        static string pWeapon;
        static int pWepDmg;
        static string[] weapon = { "fist", "pistol", "rifle", "gernade" }; //sets weapin choice 
        static int[] Dmg = { 5, 15, 50, 100 }; //sets weapon damage 
        static string enemy; // enemy ref for combat to be populated  randomly
        static int enHealth; // enemy health ref for combat to be populated  randomly
        static string eWeapon; // enemy weapon ref for combat to be populated  randomly
        static int eWepDmg; // enemy weapon damage ref for combat to be populated  randomly
        static string Character; // initalizes  variable
        
        static string hStat;
        static int ESmin = 1;//sets min rangefor enemy select list
        static int ESmax = 4; //sets max range for  enemy  select list 
       
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("What is your character's name");  //prompts for name entry for  stat block  hud
            Console.ForegroundColor = ConsoleColor.Blue;
            Character = Console.ReadLine();

            Console.Clear();
           
            //list for pulling and discarding random numbers to randomize the orderof enemies without  repeating
        List<int> enemyChoices = new List<int>();
        for (int i = ESmin; i <= ESmax; i++)
        {
            enemyChoices.Add(i);
        }
        Random random = new Random();

        while (enemyChoices.Count > 0)   // Loop to pull and discard numbers
        {
           int randomIndex = random.Next(0, enemyChoices.Count);  // Generate a random index within the bounds of the current list
        int assignedEnemy = enemyChoices[randomIndex];   // Get the number at the random index
         /*
            Random random = new Random();
            int assignedEnemy = random.Next(1, 5);
        */
            if (assignedEnemy == 1)
            {
                enemy = enemyChar[0];
                enHealth = enemyHealth[0];
                eWeapon = weapon[0];
                eWepDmg = Dmg[0];
            }
            else if (assignedEnemy == 2)
            {
                enemy = enemyChar[1];
                enHealth = enemyHealth[1];
                eWeapon = weapon[1];
                eWepDmg = Dmg[1];
            }
            else if (assignedEnemy == 3)
            {
                enemy = enemyChar[20];
                enHealth = enemyHealth[2];
                eWeapon = weapon[2];
                eWepDmg = Dmg[2];
            }
            else if (assignedEnemy == 4)
            {
                enemy = enemyChar[3];
                enHealth = enemyHealth[3];
                eWeapon = weapon[3];
                eWepDmg = Dmg[3];
            }
            else
            {
                Console.WriteLine("You do not encounter any enemies. \n"); //else statement to  ensure no errors.
            }
        

             statsBlock();
           //RandomEnemy();

          // while (health >= 0 && enHealth >= 0)  //creates  combat loop
            {
                Console.Clear();
                HUD();
                Console.WriteLine(" You  stock up your ammo and head off to go on patrol... \n");
                Console.ReadKey(true);
                Console.Clear();
                HUD();
                weaponSelector();
                Console.ReadKey(true);
                eLifeChk();
                Console.ReadKey(true);
                enemyAttack();
                Console.ReadKey(true);
                pLifeChk();
                Console.ReadKey(true);

            }

            Console.WriteLine("Battle weary you head back to base, living tofight another day. \n");











        }
        //methods below here

        //meth1
        /*
        static void  RandomEnemy()
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
            int assignedEnemy = enemyChoices[randomIndex];   // Get the number at the random index
             
            Random random = new Random();
            int assignedEnemy = random.Next(1, 5);
            
            if (assignedEnemy == 1) 
                {
                enemy = enemyChar[0];
                enHealth = enemyHealth[0];
                eWeapon = weapon[0];
                eWepDmg = Dmg[0];
                }
                else if (assignedEnemy == 2)
                {
                    enemy = enemyChar[1];
                    enHealth = enemyHealth[1];
                    eWeapon = weapon[1];
                    eWepDmg = Dmg[1];
                }
                else if (assignedEnemy == 3)
                {
                    enemy = enemyChar[20];
                    enHealth = enemyHealth[2];
                    eWeapon = weapon[2];
                    eWepDmg = Dmg[2];
                }
                else if (assignedEnemy == 4)
                {
                    enemy = enemyChar[3];
                    enHealth = enemyHealth[3];
                    eWeapon = weapon[3];
                    eWepDmg = Dmg[3];
                }
                else
                {
                    Console.WriteLine("You do not encounter any enemies. \n"); //else statement to  ensure no errors.
                }
            }*/
         }

    

        //meth2

        static void eLifeChk()
        {
            bool isEnemyDead = false; //  check to see if enemy is dead

            while (!isEnemyDead)   //while enemy is  not dead this will continue player attack in loop
            {
                if (enHealth >= 0)
                {
                    Console.WriteLine($"Your enemy yet lives, your task is not yet complete. " + "\n " + "\n ");
                    weaponSelector();
                    
                }
                else
                {
                    Console.WriteLine("you have slain your enemy. You can rest easy until your next inevitable combat." + "\n");
                   
                    break; // breaks the combat loop on player death 

                }

            }
        }

        //meth3
        static void pLifeChk()
        {
            bool isPLayerDead = false; //  check to see if player is dead

            while (!isPLayerDead)   //while player is  not dead this will continue player attack in loop
            {
                if (health >= 0)
                {
                    Console.WriteLine("Your enemy knows you are still alive, they smell your fear... your self doubt.\n They know their task is not yet complete. " + "\n " + "\n ");
                    enemyAttack();
                   
                }
                else
                {
                    Console.WriteLine("You have been slain by your enemy. \n You can rest in Vahalla until Odin tires  of your weakness.\n");
                    
                    break; // breaks the combat loop on enemy death

                }

            }
        }

        //meth4
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Name : ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Character}" + "\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,0}{1,15}{2,12}", "life", "condition", "weapon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0,2}", health);
            Console.Write("{0,19}", hStat);
            Console.WriteLine("{0,9}", weapon[0] + "\n");

            //Console.WriteLine("{0,2}{1,13}{2,14}", health, hStat, wepType + "\n");
        }

        //meth4
       

        //meth5
        static void HUD()
        {
            statsBlock();
           
        }

        //meth6
        static void weaponSelector()
        {
            Console.WriteLine(" Please choose a weapon: 0 = Fist, 1 = Pistol, 2 = Rocket Launcher, 3 = Sniper Rifle" + "\n");

            string weaponSelect = Console.ReadLine(); //store  weapon  selection
           // if (int.TryParse(weaponSelect, out weaponSelect))
            {
                if (weaponSelect == "0")
                {
                    Console.WriteLine("You choose to attack your enemy with your Bare Hands. " + "\n");
                     pWeapon = weapon[0];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Fist the enemy for {Dmg[0]} damage. ");
                    enHealth = -Dmg[0];//applies array slot 0 damage to the enemy health for selected enemy
                }
                else if (weaponSelect == "1")
                {
                    Console.WriteLine("You choose to attack your enemy with your trusty Pistol. " + "\n");
                    pWeapon =  weapon[1];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Pewww the enemy for {Dmg[1]} damage. ");
                    enHealth = -Dmg[1];//applies array slot 1 damage to the enemy health for selected enemy
                }
                else if (weaponSelect == "2")
                {
                    Console.WriteLine("You choose to attack your enemy with a sleek andd stylish Sniper Rifle. Woot Headshot! " + "\n");
                    pWeapon = weapon[2];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Bang the enemy for {Dmg[2]} damage. ");
                    enHealth = -Dmg[2];//applies array slot 2 damage to the enemy health for selected enemy
                }
            
            
                else if (weaponSelect == "3")
                {
                    Console.WriteLine("You choose to attack your enemy with a FRIKKIN Gernade... Overkill much? " + "\n");
                    pWeapon = weapon[3];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You KaBOOM the enemy for {Dmg[3]} damage. ");
                    enHealth = -Dmg[3]; //applies array slot 3 damage to the enemy health for selected enemy
                }
                else
                {
                    Console.WriteLine("You  did not have room totake that weapon with you it is at home in your footlocker." + "\n");
                    pWeapon = weapon[0];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Flail at the enemy for {Dmg[0]} damage. ");
                    enHealth = -Dmg[0]; //defaults  weapon choice for any other  choice to fist
                }

            }
        }
        //meth7

        static void enemyAttack()
        {
            Console.WriteLine($"{enemy} counter attacks! \n");


            Console.WriteLine($"{enemy} attacks you  with {eWeapon} doing {eWepDmg}... \n");
            health = -eWepDmg;//applies approperate weapon damage to player based on enemy build
        }

    }
}

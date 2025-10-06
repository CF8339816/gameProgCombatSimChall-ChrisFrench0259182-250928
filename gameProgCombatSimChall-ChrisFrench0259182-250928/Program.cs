using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
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
        static int[] fireRate = { 0, 2, 1, 1 };
        static int health = 100;   // Player Health
        static string pWeapon;
        static int pWepDmg;
        static string[] weapon = { "fist", "pistol", "rifle", "gernade" }; //sets weapin choice 
        static int[] Dmg = { 5, 15, 50, 75}; //sets weapon damage 
        static int[] ammoLoad = { 0, 10, 5, 3};
        static string enemy; // enemy ref for combat to be populated  randomly
        static int enHealth; // enemy health ref for combat to be populated  randomly
        static string eWeapon; // enemy weapon ref for combat to be populated  randomly
        static int eWepDmg; // enemy weapon damage ref for combat to be populated  randomly
        static string Character; // initalizes  variable
        static string hStat;
        static int ESmin = 1;//sets min rangefor enemy select list
        static int ESmax = 4; //sets max range for  enemy  select list 
        static int Kills = 0;
        static int[] ammoCount = new int[4];
        static List<int> enemyChoices = new List<int>();
        static void Main(string[] args)
        {

            ammoCount[1] = 0;  //sets inital ammo value pistol carried
            ammoCount[2] = 0;   //sets inital ammo value sniper rifle carried
            ammoCount[3] = 0;   //sets inital ammo gernades  carried 

            ammoLoad[1] = 14;  //sets inital ammo value pistol
            ammoLoad[2] = 6;   //sets inital ammo value sniper rifle
            ammoLoad[3] = 3;   //sets inital ammo rocket launcher

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("What is your character's name");  //prompts for name entry for  stat block  hud
            Console.ForegroundColor = ConsoleColor.Blue;
            Character = Console.ReadLine();

            Console.Clear();


            //list for pulling and discarding random numbers to randomize the orderof enemies without  repeating
            // RandEnemy();

            /*
            List<int> enemyChoices = new List<int>(); // cretes list for enemy selection
            for (int i = ESmin; i <= ESmax; i++) //sets number of volume and removes prvious choice
            {
                enemyChoices.Add(i); // adds the generated int to enemy choices count for selection
            }
            Random random = new Random(); //selects a random number from the list

            while (enemyChoices.Count > 0)   // Loop to pull and discard numbers
            {
                int randomIndex = random.Next(0, enemyChoices.Count);  // Generate a random index within the bounds of the current list
                int assignedEnemy = enemyChoices[randomIndex];   // Get the number at the random index

                Random random2 = new Random(); //generates a random value for gernade damage
                int gernadeDmg = random2.Next(45, 101);// defines the range of gernade camages random can generate from

                if (assignedEnemy == 1)
                {  //defines enemy 1
                    enemy = enemyChar[0];
                    enHealth = enemyHealth[0];
                    eWeapon = weapon[0];
                    eWepDmg = Dmg[0];
                }
                else if (assignedEnemy == 2)
                {   //defines enemy 2
                    enemy = enemyChar[1];
                    enHealth = enemyHealth[1];
                    eWeapon = weapon[1];
                    eWepDmg = Dmg[1];
                }
                else if (assignedEnemy == 3)
                {   //defines enemy 3
                    enemy = enemyChar[20];
                    enHealth = enemyHealth[2];
                    eWeapon = weapon[2];
                    eWepDmg = Dmg[2];
                }
                else if (assignedEnemy == 4)
                {   //defines enemy 4
                    enemy = enemyChar[3];
                    enHealth = enemyHealth[3];
                    eWeapon = weapon[3];
                    eWepDmg = gernadeDmg;
                }
                else
                {     //defines no enemy left to select
                    Console.WriteLine("You do not encounter any enemies. \n"); //else statement to  ensure no errors.
                }

                */


                statsBlock();
                Console.ReadKey(true);
                Console.WriteLine(" You  stock up your ammo and head off to go on patrol... \n");
                Console.ReadKey(true);
                Console.Clear();

                //while (health > 0 )  //creates  combat loop
                // {
                Console.Clear();
                HUD();
                RandEnemy();
                weaponSelector();
                Console.ReadKey(true);
                //eLifeChk();
                // Console.ReadKey(true);
                // enemyAttack();
                //  Console.ReadKey(true);
                // pLifeChk();
                //Console.ReadKey(true);


                // }

                Console.WriteLine($"Battle weary you head back to base, You defeated {Kills} enemies and live to fight another day. \n");











            }
        
        //methods below here

        //meth1

       
        

        //meth2

        static void eLifeChk()
        {
            bool isEnemyDead = false; //  check to see if enemy is dead

            while (!isEnemyDead)   //while enemy is  not dead this will continue player attack in loop
            {
                if (enHealth > 0)
                {
                    Console.WriteLine($"Your enemy yet lives, your task is not yet complete. " + "\n " + "\n ");
                   //
                    
                    enemyAttack();

                }
                else 
                {
                    Console.WriteLine("You have slain your enemy. You can rest easy until your next inevitable combat." + "\n");
                    Console.WriteLine("You recover 5 Pistol rounds and 2 rifle rounds. you also recover 3 rations, eating them recovers 15 health" + "\n");
                    ammoCount[1] = ammoCount[1] + 5;
                    ammoCount[2] = ammoCount[2] + 3;
                    health = health + 15;
                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();

                    //break; // breaks the combat loop on ENEMY death 

                }

            }
        }

        //meth3
        static void pLifeChk()
        {
            bool isPLayerDead = false; //  check to see if player is dead

            while (!isPLayerDead)   //while player is  not dead this will continue player attack in loop
            {
                if (health > 0)
                {
                    Console.WriteLine("Your enemy knows you are still alive, they smell your fear... your self doubt.\n They know their task is not yet complete. " + "\n " + "\n ");
                   //
                    
                    weaponSelector();

                }
                else
                {
                    Console.WriteLine($"You have been slain by your enemy. \n You got {Kills} kills before  you  were  taken  out.  \n You can rest in Vahalla until Odin tires  of your weakness.\n");
                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();

                    //break; // breaks the combat loop on  death 
                    return;

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
            Console.WriteLine("{0,0}{1,17}{2,17}", "life", "condition", "weapon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0,2}", health);
            Console.Write("{0,23}", hStat);
            Console.WriteLine("{0,12}", weapon[0] + "\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("{0,2}{1,13}{2,14}", health, hStat, wepType + "\n");
        }

        //meth9
       
        static void RandEnemy()
        {
           List<int> enemyChoices = new List<int>(); // cretes list for enemy selection
            for (int i = ESmin; i <= ESmax; i++) //sets number of volume and removes prvious choice
            {
                enemyChoices.Add(i); // adds the generated int to enemy choices count for selection
            }
            Random random = new Random(); //selects a random number from the list

            while (enemyChoices.Count > 0)   // Loop to pull and discard numbers
            {
                int randomIndex = random.Next(0, enemyChoices.Count);  // Generate a random index within the bounds of the current list
                int assignedEnemy = enemyChoices[randomIndex];   // Get the number at the random index

                Random random2 = new Random(); //generates a random value for gernade damage
                int gernadeDmg = random2.Next(45, 101);// defines the range of gernade camages random can generate from

                if (assignedEnemy == 1)
                {  //defines enemy 1
                    enemy = enemyChar[0];
                    enHealth = enemyHealth[0];
                    eWeapon = weapon[0];
                    eWepDmg = Dmg[0];
                }
                else if (assignedEnemy == 2)
                {   //defines enemy 2
                    enemy = enemyChar[1];
                    enHealth = enemyHealth[1];
                    eWeapon = weapon[1];
                    eWepDmg = Dmg[1];
                }
                else if (assignedEnemy == 3)
                {   //defines enemy 3
                    enemy = enemyChar[20];
                    enHealth = enemyHealth[2];
                    eWeapon = weapon[2];
                    eWepDmg = Dmg[2];
                }
                else if (assignedEnemy == 4)
                {   //defines enemy 4
                    enemy = enemyChar[3];
                    enHealth = enemyHealth[3];
                    eWeapon = weapon[3];
                    eWepDmg = gernadeDmg;
                }
                else
                {     //defines no enemy left to select
                    Console.WriteLine("You do not encounter any enemies. \n"); //else statement to  ensure no errors.
                }

            }
        }
       
        //meth5
        static void HUD()
        {
            statsBlock();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("weapon");
            Console.Write("{0,15 }", "ammo carried");
            Console.WriteLine("{0,16}", "ammo loaded" + "\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(weapon[1]);

            Console.Write("{0,11}", ammoCount[1]);
            Console.WriteLine("{0,15}", ammoLoad[1]);
            Console.Write(weapon[2]);
            Console.Write("{0,12}", ammoCount[2]);
            Console.WriteLine("{0,15}", ammoLoad[2]);
            Console.Write(weapon[3]);
            Console.Write("{0,10}", ammoCount[3]);
            Console.WriteLine("{0,15}", ammoLoad[3]);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enemy encountered : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{enemy}" + "\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        //meth6
        static void weaponSelector()
        {
            Random random3 = new Random();
            int gernadeDmg2 = random3.Next(45, 101);
            Console.WriteLine(" Please choose a weapon: 0 = Fist, 1 = Pistol, 2 = Sniper Rifle, 3 = Gernade" + "\n");

            string weaponSelect = Console.ReadLine(); //store  weapon  selection
         
            {
                if (weaponSelect == "0")
                {
                    Console.WriteLine("You choose to attack your enemy with your Bare Hands. " + "\n");
                        pWeapon = weapon[0];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Fist the enemy for {Dmg[0]} damage. ");
                    enHealth = enHealth - Dmg[0];//applies array slot 0 damage to the enemy health for selected enemy
                    //
                    
                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();
                    eLifeChk();
                }
                else if (weaponSelect == "1")
                {
                    Console.WriteLine("You choose to attack your enemy with your trusty Pistol. " + "\n");
                    pWeapon =  weapon[1];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Pewww the enemy for {Dmg[1]} damage. ");
                    enHealth = enHealth - Dmg[1];//applies array slot 1 damage to the enemy health for selected enemy
                    //
                    ammoLoad[1] = ammoLoad[1] - fireRate[1];
                    
                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();
                    eLifeChk();
                }
                else if (weaponSelect == "2")
                {
                    Console.WriteLine("You choose to attack your enemy with a sleek andd stylish Sniper Rifle. Woot Headshot! " + "\n");
                    pWeapon = weapon[2];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Bang the enemy for {Dmg[2]} damage. ");
                    enHealth = enHealth - Dmg[2];//applies array slot 2 damage to the enemy health for selected enemy
                    //
                    ammoLoad[2] = ammoLoad[2] - fireRate[2];
                    
                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();
                    eLifeChk();
                }
            
            
                else if (weaponSelect == "3")
                {
                    Console.WriteLine("You choose to attack your enemy with a FRIKKIN Gernade... Overkill much? " + "\n");
                    pWeapon = weapon[3];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You KaBOOM the enemy for {gernadeDmg2} damage. ");
                    enHealth = enHealth - gernadeDmg2; //applies array slot 3 damage to the enemy health for selected enemy
                    //
                    ammoLoad[3] = ammoLoad[3] - fireRate[3];

                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();
                    eLifeChk();
                }
                else
                {
                    Console.WriteLine("You did not have room to take that weapon with you it is at home in your footlocker." + "\n");
                    pWeapon = weapon[0];  //modify weapon value based on user input  to  weaponSelect.
                    Console.WriteLine($"You Flail at the enemy for {Dmg[0]} damage. ");
                    enHealth = enHealth - Dmg[0]; //defaults  weapon choice for any other  choice to fist
                    //
                    
                    Console.ReadKey(true);
                    Console.Clear();
                    HUD();
                    eLifeChk();
                }

            }
        }
        //meth7

        static void enemyAttack()
        {
            Console.WriteLine($"{enemy} counter attacks! \n");


            Console.WriteLine($"{enemy} attacks you  with {eWeapon} doing {eWepDmg}... \n");
            health = health - eWepDmg;//applies approperate weapon damage to player based on enemy build
            //
            
            Console.ReadKey(true);
            Console.Clear();
            HUD();
            pLifeChk();

        }

    }
}

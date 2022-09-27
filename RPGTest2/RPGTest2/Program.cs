using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


public class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Hey! You're finally awake. Thank goodness you're safe.");
        Thread.Sleep(1900);
        Console.WriteLine("What's your name?");
        string myName = Console.ReadLine();
        Console.WriteLine(myName + "...you must be so confused.");
        Thread.Sleep(1800);
        Console.WriteLine(@"You're currently in a safehouse, where fellow civilians are gathering to keep themselves safe from the outside world.                                    /\
                              /\  //\\
                       /\    //\\///\\\        /\
                      //\\  ///\////\\\\  /\  //\\
         /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \
        / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \
       /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       *
      /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ____  ^   ^  \     /|\
     / ^ ^  ^ \ ^  _\___________________|  |_____^ ^  \   /||o\
    / ^^  ^ ^ ^\  /______________________________\ ^ ^ \ /|o|||\
   /  ^  ^^ ^ ^  /________________________________\  ^  /|||||o|\
  /^ ^  ^ ^^  ^    ||___|___||||||||||||___|__|||      /||o||||||\       |
 / ^   ^   ^    ^  ||___|___||||||||||||___|__|||          | |           |
/ ^ ^ ^  ^  ^  ^   ||||||||||||||||||||||||||||||oooooooooo| |ooooooo  |
ooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
        Thread.Sleep(3000);
        Console.WriteLine("Why's that? Well...it's a bit hard to believe, but...");
        Thread.Sleep(1800);
        Console.WriteLine("...the whole world's kind of ruined.");
        Thread.Sleep(1800);
        Console.WriteLine("I know...it sounds really bad, and it is. The world's being overrun by titanic beasts, and they've destroyed many civilisations, and have basically taken over the world.");
        Thread.Sleep(3700);
        Console.WriteLine("So yeah, that's why you and me and so many others are here in this safehouse.");
        Thread.Sleep(2400);
        Console.WriteLine("Please do try and make yourself comfy here, as you'll be here for a very long time.");
        Thread.Sleep(1800);
        Console.WriteLine("...what? You want to try and help us?");
        Thread.Sleep(2000);
        Console.WriteLine("Well, I do have an idea for that, but it's risky...");
        Thread.Sleep(2400);
        Console.WriteLine("Do you think you could get some fruit from the outside world to take back home?");
        string Choice = Console.ReadLine();
        while (Choice != "Yes" && Choice != "No")
        {
            if (Choice == "Yes")
            {
                break;
            }
        }

        if (Choice == "No")
        {
            Console.WriteLine("Then stay here for the rest of your life!");
            Thread.Sleep(2400);
            Console.WriteLine("You got the safe ending!");

        }
        battle();

    }

    static void battle()
    {

        int HP = 150;
        int MP = 150;
        int EHP;
        int ERNG = 0;
        int EDEF;
        int DAM;
        int ERNG2;
        Boolean CanRun;
        Boolean Guarding;
        string WPTYP = "Physical";
        string Move;
        Random rnd = new Random();
        int ITEM = 5;
        // Variables are announced privately in a meeting.
        // Battle
        // Enemy RNG. 1 to 3.
        ERNG = rnd.Next(1, 4);
        if (ERNG == 1)
        {
            EHP = 80;
            EDEF = 4;
            Console.WriteLine("You have encountered Enemy 1!");
        }
        else if (ERNG == 2)
        {
            EHP = 66;
            EDEF = 6;
            Console.WriteLine("You have encountered Enemy 2!");
        }
        else
        {
            EHP = 90;
            EDEF = 3;
            Console.WriteLine("You have encountered Enemy 3!");
        }
        Thread.Sleep(2000);
        CanRun = true;
        // Random enemy battles can be ran from.
        while (EHP > 0)
        {
            Move = "Waiting";
            Guarding = false;
            // Guarding becomes false after a turn, even when the player didn't guard.
            do
            {
                Console.WriteLine("What shall you do? Attack, Guard, Item, or Run? Please type it correctly.");
                Move = Console.ReadLine();
            }
            while (Move != "Attack" && Move != "Guard" && Move != "Item" && Move != "Run");
            // If the player doesn't type a command correctly, it loops to their turn again.
            if (Move == "Attack")
            {
                // Different types of weapons allow for different amounts of damage.
                if (WPTYP == "Physical")
                {
                    DAM = rnd.Next(22, 28);
                    DAM -= EDEF;
                    EHP -= DAM;
                    Console.WriteLine($"You attacked physically, dealing {DAM} damage!");
                }

                Thread.Sleep(1300);
                if (EHP < 1)
                {
                    Console.WriteLine("You won the battle!");
                    break;
                }
                Console.WriteLine($"The enemy is now at {EHP} HP.");
            }
            else if (Move == "Guard")
            {
                Guarding = true;
                Console.WriteLine("You guarded yourself! You'll take 15 less damage this turn!");
            }
            else if (Move == "Run")
            {
                if (CanRun == true)
                {
                    Console.WriteLine("You ran away!");
                    break;
                    // Why would you do that
                }

            }
            else
            {
                HP += 75;
                if (HP > 150)
                    HP = 150;
                ITEM -= 1;
                Console.WriteLine("You consumed an item! You recovered 75 HP!");
                Thread.Sleep(1400);
                Console.WriteLine($"You now have {HP} HP, and {ITEM} items!");
            }
            Thread.Sleep(1700);
            ERNG2 = rnd.Next(1, 3);
            // Enemy has two random attacks. An attack and a heal.  ... not really much.
            if (ERNG2 == 1)
            {
                if (ERNG == 1)
                {
                    DAM = rnd.Next(19, 25);
                }
                else if (ERNG == 2)
                {
                    DAM = rnd.Next(16, 22);
                }
                else
                {
                    DAM = rnd.Next(30, 36);
                }
                if (Guarding == true)
                {
                    DAM -= 15;
                }
                HP -= DAM;
                Console.WriteLine($"The enemy attacked, dealing {DAM} damage to you!");
                Thread.Sleep(1400);
                Console.WriteLine($"You now have {HP} HP!");
            }
            else
            {
                EHP += 20;
                Console.WriteLine($"The enemy healed themselves for 20 HP! They now have {EHP} HP!");
            }
            Thread.Sleep(2000);
            // Wait 2 seconds.
        }


    }
}
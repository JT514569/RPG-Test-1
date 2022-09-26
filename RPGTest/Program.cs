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


// Battle
// Enemy RNG. 1 to 3.
ERNG = rnd.Next(1, 4);
if (ERNG == 1)
{
EHP = 80;
EDEF = 5;
Console.WriteLine("You have encountered Enemy 1!");
}
else if (ERNG == 2)
{
EHP = 66;
EDEF = 11;
Console.WriteLine("You have encountered Enemy 2!");
}
else
{
EHP = 90;
EDEF = 3;
Console.WriteLine("You have encountered Enemy 3!");
}
Thread.Sleep(2000);

while (EHP > 0)
{
    Move = "Waiting";
    Guarding = false;
    do
    {
        Console.WriteLine("What shall you do? Attack, Guard, or Item? Please type it correctly.");
        Move = Console.ReadLine();
    }
    while (Move != "Attack" && Move != "Guard" && Move != "Item");
    if (Move == "Attack")
    {
        if (WPTYP == "Physical")
        {
            DAM = rnd.Next(22, 28);
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
    }
    else
    {
        HP += 75;
        if (HP > 150)
            HP = 150;
        ITEM -= 1;
    }
    Thread.Sleep(2000);
    ERNG2 = rnd.Next(1, 3);
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
}




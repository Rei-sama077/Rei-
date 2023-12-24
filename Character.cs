using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YTCFW
{

    interface Attack
    {
        void NormAttack(Hero target);
    }

    public abstract class Character
    {
        public int Intelligence { get; set; }
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int MaxHealth { get; set; }
        public int HP { get; set; }
        public int Agility { get; set; }
        public int Defense { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public abstract void DisplayInfo();

        public bool IsAlive()
        {
            return HP > 0;
        }
    }

    public class Hero : Character
    {

        private string _playerID;

        private int _progress;
        public string PlayerID
        {
            get { return _playerID; }
            set { _playerID = value; }
        }



        public int Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }

        public int Gold { get; set; }
        public int QuantityHPPotion { get; set; }
        public int QuantityMPPotion { get; set; }


        public Hero(string name, int intelligence, int strength, int agility, int gold, int quantityHPPotion, int quantityMPPotion, int progress)
        {
            Name = name;
            Intelligence = intelligence;
            MaxMana = 10 + Intelligence * 2;
            Mana = MaxMana;
            Strength = strength;
            MaxHealth = 20 + Strength * 3;
            HP = MaxHealth;
            Agility = agility;
            Defense = 5 + Agility * 2;
            Gold = gold;
            QuantityHPPotion = quantityHPPotion;
            QuantityMPPotion = quantityMPPotion;
            Progress = progress;
        }

        public void DecreaseMana(int amount)
        {
            Len len = new Len();

            if (amount > 0 && Mana >= amount)
            {
                Mana -= amount;
                len.PrintL($"{Name} used mana. Remaining mana: {Mana}");
            }
            else
            {
                len.PrintL("Not enough mana!");
                // Handle the case where the hero doesn't have enough mana to perform an action.
            }
        }

        public override void DisplayInfo()
        {
            Len len = new Len();

            Gen gen = new Gen();

            len.PrintL("                                                       ",
                       $"Progress:{Progress}                                   ",
                       $"Name:{Name}                                           ",
                       $"INT:{Intelligence}        AGI:{Agility}               ",
                       $"STR:{Strength}           Gold:{Gold}                  ",
                       $"DEF:{Defense}                                         ");
        }




        public void NormAttack(Enemy target)
        {
            Len len = new Len();

            Random random = new Random();
            int initialdamage = random.Next((int)(Strength * .8), (Strength + 20)); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            len.PrintL($"You inflicted total damage of {damage} to enemy {target.Name}");
        }
        public void SpinAttack(Enemy target)
        {
            Len len = new Len();

            int damage = Math.Max(((Strength + 2) * 2) - (int)(target.Defense * .30), 1);
            target.HP -= damage;
            len.PrintL($"You inflicted total damage of {damage} to enemy {target.Name}");

        }

        public void DoubleSlash(Enemy target)
        {
            Len len = new Len();

            int damage = Math.Max(((Strength + 5) * 2) - (int)(target.Defense * .30), 1);
            target.HP -= damage;
            len.PrintL($"You inflicted total damage of {damage} to enemy {target.Name}");
        }

        public void MiniFireBall(Enemy target)
        {
            Len len = new Len();

            int damage = Math.Max((Intelligence * 2) - (int)(target.Defense * .20), 1);
            target.HP -= damage;
            len.PrintL($"You inflicted total damage of {damage} to enemy {target.Name}");
        }


        public void FireBall(Enemy target)
        {
            Len len = new Len();

            int damage = Math.Max((Intelligence * 4) - (int)(target.Defense * .10), 1);
            target.HP -= damage;
            len.PrintL($"You inflicted total damage of {damage} to enemy {target.Name}");
        }

        public void UseHPpotion(string itemName, Hero hero)
        {
            Len len = new Len();


            double healamount = hero.MaxHealth * .5;
            hero.HP += (int)healamount;
            if (hero.HP >= hero.MaxHealth)
            {
                hero.HP = hero.MaxHealth;
            }
            QuantityHPPotion -= 1;
        }

        public void UseManapotion(string itemName, Hero hero)
        {
            Len len = new Len();

            double restoreamount = hero.Mana * .5;
            hero.Mana += (int)restoreamount;
            if (hero.Mana >= hero.MaxMana)
            {
                hero.HP = hero.MaxMana;
            }
            QuantityMPPotion -= 1;
        }

        public double Choice(Hero hero)
        {
            Len len = new Len();

            Gen gen = new Gen();
            AsciiArt asciiArt = new AsciiArt();
            while (true)
            {
                Console.WriteLine("");
                 gen.PrintC("                                                               ",
                           $"LeafWalker: What should I do next, {hero.Name}?                ",
                            "                                                               ",
                            "[1] Attack                                                     ",
                            "[2] Use Restoration Items                                      ",
                            "[3] Special                                                    ",
                            "[S] Show Stats                                                 ",
                            "                                                               ",
                            "                                                                "


                               );
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.S)
                {

                    Console.Clear();
                    hero.DisplayInfo();
                    Console.WriteLine("\n\n");
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    Console.ReadKey();
                    Console.Clear();
                    return 1;
                }


                if (key == ConsoleKey.D1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    AsciiArt.Attack();
                    Console.ResetColor();
                    return 1;

                }
                else if (key == ConsoleKey.D2)
                {
                    while (true)
                    {
                        string Hppotion = "HP Potion";
                        string Manapotion = "HP Potion";


                        Console.Clear();
                        gen.PrintC("                                                                         ",
                                  $"LeafWalker: Hmmmm.. What should I use?                                   ",
                                   "                                                                         ",
                                  $"[1] Use HP potion {QuantityHPPotion}                                     ",
                                  $"[2] Use Mana potion {QuantityMPPotion}                                   ",
                                "   [3] Go Back                                                                ",
                                   "                                                                         "
                                   );
                        ConsoleKey itemkey = Console.ReadKey().Key;

                        if (itemkey == ConsoleKey.D1)
                        {
                            if (hero.QuantityHPPotion == 0)
                            {

                                gen.PrintC("                                                               ",
                                          $"                     System Notice!                            ",
                                           "                                                               ",
                                           "                   Out of HP potions                           ",
                                           "                                                               ",
                                           "                                                               ",
                                           "                                                               ");
                                len.PrintC("There is no time to hesitate so we'll go with brute force");
                                return 1;
                            }
                            else
                            {
                                UseHPpotion(Hppotion, hero);
                                len.PrintC($"HP restored by {(int)(hero.MaxHealth / 2)}");
                                return 2.1;
                            }
                        }
                        else if (itemkey == ConsoleKey.D2)
                        {
                            if (hero.QuantityMPPotion == 0)
                            {
                                 gen.PrintC("                                                                ",
                                           $"                     System Notice!                            ",
                                            "                                                               ",
                                            "                   Out of Mana potions                         ",
                                            "                                                               ",
                                            "                                                               ",
                                            "                                                               ");
                                len.PrintC("There is no time to hesitate so we'll go with brute force");
                                return 1;
                            }
                            else
                            {
                                UseHPpotion(Manapotion, hero);
                                len.PrintC($"HP restored by {(int)((hero.Intelligence * 12) / 2)}");
                                return 2.2;
                            }
                        }
                        else
                        {
                            len.PrintC("There is no time to hesitate so we'll go with brute force");
                            return 1;
                        }
                    }
                }
                else if (key == ConsoleKey.D3)
                {
                    Console.Clear();
                    while (true)
                    {
                        asciiArt.PrintArt("Special");
                        Console.WriteLine("\n\n\n");
                        gen.PrintC("                                                               ",
                                  $"LeafWalker: It's showtime!                                     ",
                                   "                                                               ",
                                   "[1] Spin Attack                                                ",
                                   "[2] Double Slash                                               ",
                                   "[3] Mini Fireball                                              ",
                                   "[4] Fireball                                                   ",
                                   "[5] Go Back                                                    ",
                                   "                                                               "
                                  );

                        if (int.TryParse(Console.ReadLine(), out int specialChoice))
                        {
                            switch (specialChoice)
                            {
                                case 1:
                                    if (Mana >= 10)
                                    {
                                        Mana -= 10;
                                        return 4;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        gen.PrintC("                                                            ",
                                                   "              Press any key To Continue                     ",
                                                   "                                                            ");
                                        len.PrintC("Not enough mana so we'll go with brute force");
                                        Console.ReadKey();
                                        return 1;
                                    }// Spin Attack
                                case 2:
                                    if (Mana >= 20)
                                    {
                                        Mana -= 20;
                                        return 5;
                                    }
                                    else
                                    {
                                        gen.PrintC("                                                            ",
                                                   "              Press any key To Continue                     ",
                                                   "                                                            ");
                                        Console.Clear();
                                        len.PrintC("Not enough mana so we'll go with brute force");
                                        Console.ReadKey();
                                        return 1;
                                    }
                                case 3:
                                    if (Mana >= 30)
                                    {
                                        Mana -= 30;
                                        return 6;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        gen.PrintC("                                                            ",
                                                   "              Press any key To Continue                     ",
                                                   "                                                            ");
                                        len.PrintC("Not enough mana so we'll go with brute force");
                                        Console.ReadKey();
                                        return 1;
                                    }
                                case 4:
                                    if (Mana >= 50)
                                    {
                                        Mana -= 50;
                                        return 7;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        gen.PrintC("                                                            ",
                                                   "              Press any key To Continue                     ",
                                                   "                                                            ");
                                        len.PrintC("You're not ready for that yet so we'll go with brute force");
                                        Console.ReadKey();
                                        return 1;
                                    }
                                case 5:
                                    len.PrintC("Hesitation is not an option.");
                                    Console.ReadKey();
                                    return 1;
                                // Go back
                                default:
                                    Console.Clear();
                                    gen.PrintC("                                                   ",
                                   "                                                               ",
                                   "                     System Alert!                             ",
                                   "                Invalid input. Try again.                      ",
                                   "                                                               ",
                                   "                                                               "
                                  );
                                    Console.Clear();
                                    return 1;
                            }
                        }
                    }
                }
                else
                    Console.Clear();
                {
                    gen.PrintC("                                                   ",
                                   "                                                               ",
                                   "                     System Alert!                             ",
                                   "                Invalid input. Try again.                      ",
                                   "                                                               ",
                                   "                                                               ");
                    Console.Clear();
                    return 1;
                }
            }
        }



        public void HeroTurn(double decision, Enemy target)
        {
            Gen gen = new Gen();
            Len len = new Len();
            Random random = new Random();
            int damage = 0;

            switch (decision)
            {
                case 1:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    len.PrintC("You kicked the enemy!");
                    NormAttack(target);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2.1:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    len.PrintC("You're healed and ready to gear up");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2.2:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    len.PrintC("You're energized and ready to give it another go");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:

                    break;
                case 4:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    len.PrintC("You used spin attack!");
                    SpinAttack(target);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 5:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    Console.WriteLine("You used double slash!");
                    DoubleSlash(target);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 6:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    Console.WriteLine("You chanted mini fireball!");
                    MiniFireBall(target);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 7:
                    gen.PrintC("                                                            ",
                               "              Press any key To Continue                     ",
                               "                                                            ");
                    Console.WriteLine("You chanted fireball!");
                    FireBall(target);
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }


        }





        public static void VisitShop(Hero hero, int healthPotionPrice, int manaPotionPrice)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Shop!");
                Console.WriteLine($"Gold: {hero.Gold}");
                Console.WriteLine($"Your HP potion: {hero.QuantityHPPotion}");
                Console.WriteLine($"Your MP potion: {hero.QuantityMPPotion}");

                // Display potion prices and quantities
                Console.WriteLine($"1. Health Potion - {healthPotionPrice} gold (Stock: unlimited)");
                Console.WriteLine($"2. Mana Potion   - {manaPotionPrice} gold (Stock: unlimited)");
                Console.WriteLine("0. Exit the shop");

                Console.WriteLine("Enter the number of the item you want to buy (or 0 to exit):");
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1: // Buy Health Potion
                        BuyPotion(hero, "Health", healthPotionPrice, key);
                        break;
                    case ConsoleKey.D2: // Buy Mana Potion
                        BuyPotion(hero, "Mana", manaPotionPrice, key);
                        break;
                    case ConsoleKey.D0: // Exit the shop
                        Console.WriteLine("Thank you for visiting the shop!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }


        public static void BuyPotion(Hero hero, string potionType, int potionPrice, ConsoleKey key)
        {
            Console.WriteLine($"How many {potionType} Potions would you like to buy?");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int quantityToBuy))
            {
                int totalCost = quantityToBuy * potionPrice;

                if (hero.Gold >= totalCost)
                {
                    hero.Gold -= totalCost;
                    Console.WriteLine($"You bought {quantityToBuy} {potionType} Potion(s) for {totalCost} gold.");
                    
                    if (key == ConsoleKey.D1)
                    {
                        hero.QuantityHPPotion += quantityToBuy;
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        hero.QuantityMPPotion += quantityToBuy;
                    }
                    Console.ReadKey();
                }
                else if (hero.Gold < totalCost)
                {
                    Console.WriteLine("Not enough gold to buy the potions.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Not enough potions available in the shop.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input, Please enter an integer.");
                Console.ReadKey();
            }
        }




    }
}





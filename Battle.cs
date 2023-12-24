using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YTCFW;
namespace YTCFW
{
    class Battle
    {

        public static void IsHeroDead(Hero hero)
        {
            if (hero.HP <= 0)
            {
                Console.Clear();
                string text = "You have fallen in battle...";
                Console.WriteLine(text);
                Console.WriteLine("Better luck next time!");
                Console.WriteLine("Looks like you are dead!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }


        public static void ShowTextInBox(string text, Hero hero)
        {
            Console.WriteLine(text);
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"║ > Character: {hero.Name.PadRight(24)}║");
            Console.WriteLine($"║ > Health: {hero.HP}/{hero.MaxHealth.ToString().PadRight(20)}║");
            Console.WriteLine($"║ > Mana: {hero.Mana}/{hero.MaxMana.ToString().PadRight(24)}║"); 
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();

        }

        public static void EnemyBox1(string text, Enemy enemy)
        {

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"║ > Enemy: {enemy.Name.PadRight(24)}    ║");
            Console.WriteLine($"║ > Health: {enemy.HP}/{enemy.MaxHealth.ToString().PadRight(24)}║");
            Console.WriteLine($"║ > Mana: {enemy.Mana} / {enemy.MaxMana.ToString().PadRight(24)}║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        public static void EnemyBox2(string text, Enemy enemy)
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"║ > Enemy: {enemy.Name.PadRight(24)}    ║");
            Console.WriteLine($"║ > Health: {enemy.HP}/{enemy.MaxHealth.ToString().PadRight(24)}║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        public static void WithSlime(Hero hero, Slime slime)
        {
            AsciiArt asciiart = new AsciiArt();
            while (slime.IsAlive() && hero.IsAlive())
            {
                string battleTexts = $"You encounter {slime.Name}.";

                ShowTextInBox(battleTexts, hero);
                EnemyBox2(battleTexts, slime);
                Console.ForegroundColor = ConsoleColor.Cyan;
                asciiart.PrintArt("Slime");
                Console.ResetColor();
                Console.WriteLine("\n\n\n\n\n");

                hero.HeroTurn(hero.Choice(hero), slime);
                slime.SlimeTurn(hero);
                if (slime.IsAlive())
                {
                    Battle.IsHeroDead(hero);
                }
            }

            Battle.DisplayOutcome(ref hero, slime);
        }

        public static void WithBandit(Hero hero, Bandit bandit)
        {
            AsciiArt asciiArt = new AsciiArt();


            while (bandit.HP > 0 && hero.HP > 0)
            {
                string battleTexts = $"You encounter {bandit.Name}.";

                ShowTextInBox(battleTexts, hero);
                EnemyBox2(battleTexts, bandit);
                Console.ForegroundColor = ConsoleColor.Red;
                asciiArt.PrintArt("bandit");
                Console.ResetColor();
                Console.WriteLine("\n\n\n\n\n");
                hero.HeroTurn(hero.Choice(hero), bandit);
                bandit.BanditTurn(hero);
            }

            if (bandit.HP <= 0)
            {
                Console.WriteLine($"{bandit.Name} was defeated!");
                Random random = new Random();
                int gold = 200;
                Console.WriteLine($"{bandit.Name} has been defeated!");
                int choice = random.Next(1, 6);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"{bandit.Name} dropped {200} gold. Seems like {bandit.Name} is broke.");
                        hero.Gold += gold;
                        break;
                    case 2:
                        Console.WriteLine($"{bandit.Name} dropped 1 HP potion");
                        hero.QuantityHPPotion++;
                        break;
                    case 3:
                        Console.WriteLine($"{bandit.Name} dropped 1 Mana Potion");
                        hero.QuantityMPPotion++;
                        break;
                    default:
                        Console.WriteLine($"{bandit.Name} dropped a haul of {400} gold");
                        hero.Gold += gold;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{hero.Name} was defeated!");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public static void WithKnight( Hero hero, Knight knight)
        {
            AsciiArt asciiArt = new AsciiArt();

            while (knight.HP > 0 && hero.HP > 0)
            {
                string battleTexts = $"You encounter {knight.Name}.";

                ShowTextInBox(battleTexts, hero);
                EnemyBox1(battleTexts, knight);

                Console.ForegroundColor = ConsoleColor.Cyan;
                asciiArt.PrintArt("Knight");
                Console.ResetColor();
                Console.WriteLine("\n\n\n\n\n");
                hero.HeroTurn(hero.Choice(hero), knight);

                if (knight.HP > 0)
                {
                    knight.KnightTurn(hero);
                    IsHeroDead(hero);
                }
            }

            if (knight.HP <= 0)
            {
                Console.WriteLine($"{knight.Name} was defeated!");
                Random random = new Random();
                int gold = 400;
                Console.WriteLine($"{knight.Name} has been defeated!");
                int choice = random.Next(1, 5);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"{knight.Name} dropped {gold} gold");
                        hero.Gold += gold;
                        break;
                    case 2:
                        Console.WriteLine($"{knight.Name} dropped 2 HP potion");
                        hero.QuantityHPPotion = hero.QuantityHPPotion + 2;
                        break;
                    case 3:
                        Console.WriteLine($"{knight.Name} dropped 2 Mana Potion");
                        hero.QuantityMPPotion = hero.QuantityMPPotion + 2;
                        break;
                    default:
                        Console.WriteLine($"{knight.Name} dropped {gold - 100} gold");
                        hero.Gold += gold - 100;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{hero.Name} was defeated!");
            }

            Console.ReadLine();

        }

        public static void WithGoblin( Hero hero, Goblin goblin)
        {
            AsciiArt asciiArt = new AsciiArt();

            while (goblin.HP > 0 && hero.HP > 0)
            {
                string battleTexts = $"You encounter {goblin.Name}.";
                ShowTextInBox(battleTexts, hero);
                EnemyBox2(battleTexts, goblin);
                Console.ForegroundColor = ConsoleColor.Green;
                asciiArt.PrintArt("goblin");
                Console.ResetColor();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n");

                hero.HeroTurn(hero.Choice(hero), goblin);

                if (goblin.HP > 0)
                {
                    bool isAttackingFromBehind = true;
                    goblin.GoblinTurn(hero, isAttackingFromBehind, hero.Agility);
                    IsHeroDead(hero);
                }
            }

            if (goblin.HP <= 0)
            {
                Console.WriteLine($"{goblin.Name} was defeated!");
                Random random = new Random();
                int gold = 300;
                Console.WriteLine($"{goblin.Name} has been defeated!");
                int choice = random.Next(1, 5);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"{goblin.Name} dropped {gold} gold");
                        hero.Gold += gold;
                        break;
                    case 2:
                        Console.WriteLine($"{goblin.Name} dropped 2 HP potion");
                        hero.QuantityHPPotion += 2;
                        break;
                    case 3:
                        Console.WriteLine($"{goblin.Name} dropped 2 Mana Potion");
                        hero.QuantityMPPotion += 2;
                        break;
                    default:
                        Console.WriteLine($"{goblin.Name} dropped {gold - 100} gold");
                        hero.Gold += gold - 100;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{hero.Name} was defeated!");
                
            }

            Console.ReadLine();

        }

        public static void WithUndead( Hero hero, Undead undead)
        {


            while (undead.HP > 0 && hero.HP > 0)
            {
                string battleText = $"You encounter {undead.Name}.";
                ShowTextInBox(battleText, hero);
                EnemyBox2(battleText, undead);
                Console.WriteLine("\n\n\n\n\n");


                hero.HeroTurn(hero.Choice(hero), undead);

                if (undead.HP > 0)
                {
                    undead.UndeadTurn(hero);
                    IsHeroDead(hero);
                }
            }

            if (undead.HP <= 0)
            {
                Console.WriteLine($"{undead.Name} was defeated!");
                Random random = new Random();
                int gold = 300;
                Console.WriteLine($"{undead.Name} has been defeated!");
                int choice = random.Next(1, 5);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"{undead.Name} dropped {gold} gold");
                        hero.Gold += gold;
                        break;
                    case 2:
                        Console.WriteLine($"{undead.Name} dropped 1 HP potion");
                        hero.QuantityHPPotion++;
                        break;
                    case 3:
                        Console.WriteLine($"{undead.Name} dropped 1 Mana Potion");
                        hero.QuantityMPPotion++;
                        break;
                    default:
                        Console.WriteLine($"{undead.Name} dropped {gold + 100} gold");
                        hero.Gold += gold + 100;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{hero.Name} was defeated!");
            }

            Console.ReadLine();

        }


        private static int EChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
        }

        private static void DisplayOutcome(ref Hero hero, Enemy enemy)
        {
            Random random = new Random();
            if (!hero.IsAlive())
            {
                Console.WriteLine("You have been defeated!");
            }
            else if (!enemy.IsAlive())
            {
                int gold = 100;
                Console.WriteLine($"{enemy.Name} has been defeated!");
                int choice = random.Next(1, 3);
                switch (choice)
                {
                    case 1:
                Console.WriteLine($"{enemy.Name} dropped {gold} gold");
                hero.Gold += gold;
                        break;
                    case 2:
                        Console.WriteLine($"{enemy.Name} dropped 1 HP potion");
                        hero.QuantityHPPotion++;
                        break;
                    case 3:
                        Console.WriteLine($"{enemy.Name} dropped 1 Mana Potion");
                        hero.QuantityMPPotion++;
                        break;
                    default:
                        Console.WriteLine($"{enemy.Name} dropped {gold} gold");
                        hero.Gold += gold;
                        break;
                }
            }
        }
    }
}

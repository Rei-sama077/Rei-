using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTCFW
{
    public class Goblin : Enemy
    {
        public Goblin(string name, int intelligence, int strength, int agility)
        {
            Name = name;
            Intelligence = intelligence;
            Mana = Intelligence * 12;
            Strength = strength;
            MaxHealth = 30 + Strength * 10;
            HP = MaxHealth;
            Agility = agility;
            Defense = 10 + Agility * 2;
        }

        public void NormAttack(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next(Strength, (Strength + 5)); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} inflicted total damage of {damage} to enemy {target.Name}");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Defense: {Defense}");
        }

        // Method to determine the enemy's choice during battle




        public void Shortbow(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)((Agility * .5) + (Strength * .8)), (int)((Agility * .5) + (Strength * .95))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} used the Short Bow  and inflicted total damage of {damage} to {target.Name}");
        }



        public void Slash(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)(Strength * 1.4), (int)(Strength * 1.5)); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} used Sword Master and inflicted total damage of {damage} to {target.Name}");

        }

        public void GoblinTurn(Hero target, bool isAttackingFromBehind, int heroAgility)
        {


            Random random = new Random();
            int choice = random.Next(1, 6);

            switch (choice)
            {
                case 1:
                    NormAttack(target);
                    Console.WriteLine($"{Name} swings a crude club at you!");
                    break;
                case 2:
                    Shortbow(target);
                    Console.WriteLine($"{Name} fires an arrow from a shortbow!");
                    break;
                case 3:
                    Slash(target);
                    Console.WriteLine($"{Name} swings a crude club at you!");
                    break;
                case 4:
                    NormAttack(target);
                    Console.WriteLine($"{Name} lunges with a frenzied attack!");
                    break;
                default:
                    Console.WriteLine($"{Name} hesitates and doesn't attack!");
                    break;
            }
        }
    }
}
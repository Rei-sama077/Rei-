using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTCFW
{

    public class Bandit : Enemy
    {
        public Bandit(string name, int intelligence, int strength, int agility)
        {
            Name = name;
            Intelligence = intelligence;
            Mana = Intelligence * 12;
            Strength = strength;
            MaxHealth = 20 + Strength * 10;
            HP = MaxHealth;
            Agility = agility;
            Defense = 7 + Agility * 2;
        }


        public void NormAttack(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next(Strength, (Strength + 15)); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} inflicted total damage of {damage} to enemy {target.Name}");
        }


        public void BackStab(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)(Strength * .8) + (int)(Agility / 2), (Strength + 20 + (int)(Agility / 2))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} backstabs you and inflicted total damage of {damage}");
        }



        public void Dagger(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)(Strength * .3) + (int)(Agility * .8), (Strength + 10 + (int)(Agility * .9))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} inflicted total damage of {damage} to enemy {target.Name}");
        }



        public void Burst(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)(Strength * .5) + (int)(Agility * .5), (Strength + 30 + (int)(Agility * .6))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} inflicted total damage of {damage} to enemy {target.Name}");
        }



        public void BanditTurn(Hero target)
        {
            Random random = new Random();
            int choice = random.Next(1, 4);

            if (target.HP <= target.MaxHealth / 10)
            {
                Console.WriteLine("Bandit unleashes a powerful attack!");
                Burst(target);
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Bandit whacked you! Ouch!");
                        NormAttack(target);
                        break;
                    case 2:
                        Console.WriteLine("Bandit attempts to attack from behind!");
                        BackStab(target);
                        break;
                    case 3:
                        Console.WriteLine("Bandit attacks you with a dagger!");
                        Dagger(target);
                        break;
                    default:
                        Console.WriteLine($"{Name} miss. Breh Skill Issue");
                        break;
                }
            }
        }



        public override string ToString()
        {
            return base.ToString();
        }

        public override void DisplayInfo()
        {

            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Max Health: {MaxHealth}");
            Console.WriteLine($"Current Health: {HP}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Defense: {Defense}");
        }


    }
}

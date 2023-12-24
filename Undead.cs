using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTCFW
{

    public class Undead : Enemy
    {
        //Active Skill


        public Undead(string name, int intelligence, int strength, int agility)
        {
            Name = name;
            Intelligence = intelligence;
            Mana = Intelligence * 12;
            Strength = strength;
            MaxHealth = 300 + Strength * 10;
            HP = MaxHealth;
            Agility = agility;
            Defense = 10 + Agility * 2;
        }

        public int EChoice()
        {
            int eChoice;
            Random ran = new Random();
            eChoice = ran.Next(1, Strength + 1);
            return eChoice;
        }

        public void NormAttack(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next(Strength, (Strength + 30)); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} inflicted total damage of {damage} to enemy {target.Name}");
        }

        // Battle methods 
        public void Bleed(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)((Intelligence * .8) + (Strength * .8)), (int)((Intelligence * .95) + (Strength * .95))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .20)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} used Bleed and inflicted total damage of {damage} to {target.Name}");

        }


        public void Curse(Hero target)
        {
            int baseDamage = (int)(Intelligence * 1.2);

            Random random = new Random();
            int curseEffectRoll = random.Next(1, 101);

            if (curseEffectRoll <= 20)
            {
                double percentageDamageMultiplier = 0.1; // 10% damage
                int percentageDamage = baseDamage + (int)(target.HP * percentageDamageMultiplier);
                target.HP -= percentageDamage;
                Console.WriteLine($"{Name}'s Curse deals {percentageDamage} as damage!");

            }
            else
            {

                target.HP -= baseDamage;
                Console.WriteLine($"{Name}'s Curse deals normally in {baseDamage} as damage!");

            }
        }

        //Strength
        public void ShadowClaw(Hero target)
        {
            int boostedAgi = Agility + (int)(Agility * .3);
            int basePhysicalDamage = (int)(Strength * 1.2);

            double magicDamageMultiplier = 0.5;
            int magicDamage = (int)(Intelligence + (int)(Intelligence * magicDamageMultiplier));

            int totalDamage = basePhysicalDamage + magicDamage;

            if (target.Agility < (boostedAgi / 2))
            {
                Console.WriteLine($"{Name}'s Shadow Claw magically turns strength and deals {totalDamage}");
                target.HP -= totalDamage;
            }
            else
            {
                Console.WriteLine($"The ShadowClaw strikes with magic damage: {magicDamage}");
                target.HP -= magicDamage;
            }
        }


        public void UndeadTurn(Hero target)
        {

            Random ran = new Random();
            int choice = ran.Next(1, 12);
            if (target.HP <= target.MaxHealth / 2)
            {
                Curse(target);
                Console.WriteLine($"{Name} unleashes a powerful Strength!");
            }
            else
            {

                switch (choice)
                {
                    case 1:
                        NormAttack(target);
                        Console.WriteLine($"{Name} punched you! That's one tough punch!");
                        break;

                    case 2:

                        Bleed(target);
                        Console.WriteLine("Knight slashed you! Ouch!");
                        break;

                    case 3:

                        Curse(target);
                        Console.WriteLine("Knight slashed you! Ouch!");
                        break;

                    case 4:

                        Curse(target);
                        Console.WriteLine("Knight slashed you! Ouch!");
                        break;

                    case 5:

                        ShadowClaw(target);
                        Console.WriteLine("Bandit unleashes a powerful attack!");
                        break;
                    case 6:

                        ShadowClaw(target);
                        Console.WriteLine("Bandit unleashes a powerful attack!");
                        break;
                    case 7:

                        NormAttack(target);
                        Console.WriteLine("Knight punched you! That's one tough punch!");
                        break;
                    case 8:

                        ShadowClaw(target);
                        Console.WriteLine("Bandit unleashes a powerful attack!");
                        break;
                    case 9:
                        NormAttack(target);
                        Console.WriteLine("Knight punched you! That's one tough punch!");
                        break;
                    case 10:
                        NormAttack(target);
                        Console.WriteLine("Knight punched you! That's one tough punch!");
                        break;

                    default:
                        Console.WriteLine("Bandit hesitates and doesn't attack!");
                        break;
                }
            }
        }


    }
}

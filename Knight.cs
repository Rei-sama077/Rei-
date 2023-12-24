using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YTCFW
{
    public class Knight : Enemy
    {


        public Knight(string name, int intelligence, int strength, int agility)
        {
            Name = name;
            Intelligence = intelligence;
            MaxMana = Intelligence * 10;
            Mana = MaxMana;
            Strength = strength;
            MaxHealth = 100 + (Strength * 20);
            HP = MaxHealth;
            Agility = agility;
            Defense = 10 + (int)(Agility * 2.5);
        }


        public void NormAttackK(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)(Strength * .8), (Strength + 20)); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} inflicted total damage of {damage} to enemy {target.Name}");

        }

        public void Sword_Mastery(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)((Agility * .8) + (Strength * .8)), (int)((Agility * .95) + (Strength * .95))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} used Sword Master and inflicted total damage of {damage} to {target.Name}");
        }

        public void Heavy_Attack(Hero target)
        {
            int damage = 0;
            if (Defense >= target.Defense)
            {
                damage = Math.Max(((int)(Defense * 1.5) - (int)(target.Defense * .50)), 1);
            }
            else
            {
                damage = Math.Max((Defense - (int)(target.Defense * .50)), 1);
            }
            target.HP -= damage;
            Console.WriteLine($"{Name} used Heavy Attack and inflicted total damage of {damage} to {target.Name}");
        }

        public void Holy_Light_Atk(Hero target)
        {
            Console.WriteLine($"{Name} uses Holy Light Attack! ");
            Console.WriteLine($"But {target} is not an undead so he is unaffected");
        }

        public void LastResort(Hero target)
        {
            Random random = new Random();
            int initialdamage = random.Next((int)((Agility * 1.8) + (Strength * 1.8)), (int)((Agility * 2) + (Strength * 2))); // Generate random damage between attack/2 and attack
            int damage = Math.Max((initialdamage - (int)(target.Defense * .30)), 1);
            target.HP -= damage;
            Console.WriteLine($"{Name} used Last Resort in exchange for its health and inflicted total damage of {damage} to {target.Name}");
        }






        public void KnightTurn(Hero target)
        {

            Random ran = new Random();
            int choice = ran.Next(1, 8);

            if (HP <= 51 && (HP <= (int)(MaxHealth * 10) && Mana >= 100))
            {
                Mana -= 100;
                HP -= 50;
                LastResort(target);
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        NormAttackK(target);
                        Console.WriteLine($"{Name} strike the hero!");
                        break;

                    case 2:
                        if (Mana >= 20)
                        {
                            Mana -= 20;
                            Sword_Mastery(target);
                            Console.WriteLine($"{Name} executes a precise Sword Mastery technique! (..It looks like the knight wanted to be praised)");
                        }
                        else
                        {
                            NormAttackK(target);
                            Console.WriteLine($"{Name} strike the hero!");
                        }
                        break;

                    case 4:
                        if (Mana >= 30)
                        {
                            Mana -= 30;
                            Heavy_Attack(target);
                            Console.WriteLine($"{Name} Slams the hero");
                        }
                        else
                        {
                            NormAttackK(target);
                            Console.WriteLine($"{Name} strike the hero!");
                        }
                        break;

                    case 5:

                        NormAttackK(target);
                        Console.WriteLine($"{Name} strike the hero!");
                        break;

                    case 6:

                        if (Mana >= 30)
                        {
                            Mana -= 30;
                            Heavy_Attack(target);
                            Console.WriteLine($"{Name} Slams the hero");
                        }
                        else
                        {
                            NormAttackK(target);
                            Console.WriteLine($"{Name} strike the hero!");
                        }
                        break;

                    case 7:
                        NormAttackK(target);
                        Console.WriteLine($"{Name} strike the hero!");
                        break;
                    case 8:
                        Holy_Light_Atk(target);
                        Console.WriteLine("!!!!");
                        break;
                    default:
                        Console.WriteLine($"{Name} hesitates, assessing the situation!");
                        break;
                }
            }

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

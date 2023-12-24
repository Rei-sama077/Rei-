using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTCFW
{

        public class Slime : Enemy
        {
        // Constructor
        public Slime(string name, int intelligence, int strength, int agility)
        {
            Name = name;
            Intelligence = intelligence;
            Mana = Intelligence * 1;
            Strength = strength;
            MaxHealth =  Strength * 10;
            HP = MaxHealth;
            Agility = agility;
            Defense =  Agility * 2;
        }

   
            // Basic attack method
            public void Attack(Hero target)
            {
            target.HP -= 1;
            Console.WriteLine($"{Name} attacks {target.Name} with a gooey strike!");
               
            }
            public void Drain(Hero target)
            {
                int drainAmount = Intelligence + 5;
                Console.WriteLine($"{Name} drains {drainAmount} health from {target.Name}!");
                target.HP -= drainAmount;
                this.HP += drainAmount/2;  // Slime regains health equal to the amount drained
            }

            // Slime's behavior on its turn
            public string SlimeTurn(Hero target)
            {
           
                Random random = new Random();
                int choice = random.Next(1, 6);
                switch (choice)
                {
                    case 1:
                        Attack(target);
                        return $"{Name} attacks {target.Name}!";
                    case 2:
                        if (target.HP <= target.MaxHealth / 4)
                        {
                            Drain(target);
                            return $"{Name} drains some health from {target.Name}!";
                        }
                        else
                        {
                            return $"{Name} hesitates and misses its turn!";
                        }
                    default:
                        return $"{Name} gets lost in its own goo and does nothing!";
                }
            }
        }
    }

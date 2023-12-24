using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YTCFW
{
        public abstract class Enemy : Character, Attack
        {
            
           


        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Max Health: {MaxHealth}");
            Console.WriteLine($"Current Health: {HP}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Defense: {Defense}");
        }

        public void NormAttack(Hero targer)
        {
            throw new NotImplementedException();
        }
    }

   

   
}







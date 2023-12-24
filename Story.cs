using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Policy;

namespace YTCFW
{
    class Story
    {
        public static string AnimatedText { get; private set; }

        public static void ProgressStory(ref Hero hero, AsciiArt asciiart)
        {
            Slime slime = new Slime("Slime ", 5, 5, 5);
            Slime slime2 = new Slime("Slime ", 5, 6, 6);
            Slime slime3 = new Slime("Slime ", 5, 8, 8);
            Goblin goblin = new Goblin("Goblin", 10, 10, 10);
            Goblin goblin2 = new Goblin("Chief Goblin", 15, 15, 15);
            Bandit bandit = new Bandit("Bandit", 5, 20, 20);
            Bandit bandit2 = new Bandit("Bandit", 5, 20, 25);
            Bandit bandit3 = new Bandit("Bandit Leader", 10, 20, 20);
            Knight knight = new Knight("Knight 1", 50, 30, 30);
            Knight knight2 = new Knight("Knight 2", 50, 30, 30);
            Undead undead = new Undead("UnDead", 100, 100, 100);
          

            switch (hero.Progress)
            {
                case 0:
                    Beginning();
                    Console.ReadKey();
                    break;
                case 1:
                    Encounter(hero);
                    AsciiArt.Walking();
                    Battle.WithSlime( hero, slime);
                    AsciiArt.Walking();
                    Console.ReadKey();
                    Battle.WithSlime( hero, slime2);
                    Battle.WithSlime( hero, slime3);
                    hero.Progress++;
                    Console.ReadKey();
                    break;
                case 2:

                    Hero.VisitShop(hero, 100, 100);
                    hero = new Hero(hero.Name, 12, 15, 10, hero.Gold, hero.QuantityHPPotion, hero.QuantityMPPotion, hero.Progress);
                    AsciiArt.Walking();
                    Battle.WithGoblin(hero, goblin);
                    AsciiArt.Walking();
                    hero = new Hero(hero.Name, 25, 20, 15, hero.Gold, hero.QuantityHPPotion, hero.QuantityMPPotion, hero.Progress);
                    Battle.WithGoblin( hero, goblin2);
                    AsciiArt.Walking();
                    Hero.VisitShop(hero, 100, 100);
                    hero = new Hero(hero.Name, 25, 30, 25, hero.Gold, hero.QuantityHPPotion, hero.QuantityMPPotion, hero.Progress);
                    BeforeBandits(hero);
                    Battle.WithBandit( hero, bandit);
                    Battle.WithBandit( hero, bandit3);
                    Console.ReadKey();
                    hero.Progress++;
                    break;
                case 3:
                    hero = new Hero(hero.Name, 60, 50, 50, hero.Gold, hero.QuantityHPPotion, hero.QuantityMPPotion, hero.Progress);
                    Hero.VisitShop(hero, 100, 100);
                    AsciiArt.Walking();
                    BeforeKnights(hero);
                    Battle.WithKnight( hero, knight);
                    Battle.WithKnight( hero, knight2);
                    AfterKnights(hero);
                    hero.Progress++;
                    break;
                case 4:
                    Hero.VisitShop(hero, 100, 100);
                    AsciiArt.Walking();
                    hero = new Hero(hero.Name, 80, 100, 80, hero.Gold, hero.QuantityHPPotion, hero.QuantityMPPotion, hero.Progress);
                    BeforeUndead(hero);
                    Battle.WithUndead( hero, undead);
                    hero.Progress++;
                    break;
                case 5:
                    AfterUndead(hero);
                    hero.Progress++;
                    break;
                case 6:
                    TheEnd(hero);
                    hero.Progress++;
                    break;
                default:
                    Console.WriteLine("Your journey has come to an end");
                    break;
            }
        }
        public static void Beginning()
        {
            Gen gen = new Gen();

            Console.WriteLine("\n\n\n");
            string texts = @"          w            w            w           w       w         w    #    w       
                                                                                   
                                                        w       w       w           w       w
                                 w      w         w       w        #     w       w       #     w        w       w       w    #     w                                   
                                           w  ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄   w
                                 w            ██░▄▄░█░▄▄▀█▄░▄█░███████░▄▄▄░██▄██░▄▀▄░█░██░█░██░▄▄▀█▄░▄█▀▄▄▀█░▄▄▀           w
                             w        w       ██░▀▀░█░▀▀░██░██░▄▄░████▄▄▄▀▀██░▄█░█▄█░█░██░█░██░▀▀░██░██░██░█░▀▀▄       
                                w             ██░████▄██▄██▄██▄██▄████░▀▀▀░█▄▄▄█▄███▄██▄▄▄█▄▄█▄██▄██▄███▄▄██▄█▄▄
                                                                     #   w        w
                                 w    w       ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
                                          w   ██░███░█▀▄▄▀█░██░█░▄▄▀███▄▄░▄▄██░███░██░▄▄░█▄░▄██░▄▄▀█░▄▄▀██░███    w        w         w
                             #    w           ██▄▀▀▀▄█░██░█░██░█░▀▀▄█████░████▄▀▀▀▄██░▀▀░██░███░████░▀▀░██░███
                             w        w       ████░████▄▄███▄▄▄█▄█▄▄█████░██████░████░████▀░▀██░▀▀▄█░██░██░▀▀░     w       w       w       
                                              ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
                             w     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄          w
                                   ██░▄▄▀█░███▄██▀▄▀█░████░▄▄████░▄▄▄█░▄▄▀█░▄▄▀█▄░▄█░▄▄▀█░▄▄█░██░████░███░█▀▄▄▀█░▄▄▀█░██░▄▀      w    
                          w    w   ██░████░███░▄█░█▀█░▄▄░█░▄▄████░▄▄██░▀▀░█░██░██░██░▀▀░█▄▄▀█░▀▀░████░█░█░█░██░█░▀▀▄█░██░█░
                            w      ██░▀▀▄█▄▄█▄▄▄██▄██▄██▄█▄▄▄████░████▄██▄█▄██▄██▄██▄██▄█▄▄▄█▀▀▀▄████▄▀▄▀▄██▄▄██▄█▄▄█▄▄█▄▄█w       w
                                   ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  w    w      w
                                                                     w     w                                     
                                                                         /\_/\      
                                                                    ____/ o o \     It's 'Your Typical'
                                                                  /~____  =ø= /    'Cliche Fantasy World' 
                                                                 (______)__m_m)      
                                               
                                                    
                                                      

                                ";
            Console.Write(texts);
            Console.ReadKey();
            AsciiArt.Printmenuart();


            gen.PrintC("                                                                                                    ",
                        "     ▄▄▄▄▄▄▄▄▄▄▄▄▄            ▄▄▄▄▄▄▄▄▄▄▄▄              ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄         ▄▄▄▄▄▄▄▄      ",
                        "     █ Load Game █            █ New Game █              █  Deletete File?  █         █ Exit █      ",
                        "     ▀▀▀▀▀▀▀▀▀▀▀▀▀            ▀▀▀▀▀▀▀▀▀▀▀▀              ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀         ▀▀▀▀▀▀▀▀      ",
                        "                                                                                                   ",
                        "                                                                                                   ",
                        "                                                                                                   ");

            string[] lazyGuideDialogues = {

                  "           Ugh, you seriously need a guide? Can't you read a map or something? Fine, follow me, I guess.           ",
                  "           Guide duty? I was having the best dream about sleeping in. Alright, let's make this quick.              ",
                  "           You want me to be your guide? Can't I just give you directions and go back to bed? Whatever.            ",
                  "           Adventure guide mode activated, or whatever. Don't blame me if we get lost; I'm not a morning person.   ",
                  "           I just woke up, and now I'm guiding you? This better be a short adventure. Follow my lead, I guess.     ",
                  "           I'm not exactly the energetic type, but fine, I'll guide you. Don't expect me to run or anything.       ",
                  "           Guide services provided by someone who'd rather be napping. Let's get this over with, shall we?         ",
                  "           You couldn't find a more enthusiastic guide, could you? Okay, let's mosey along, I suppose.             ",
                  "           Guide duty? Can't you see I just woke up? Well, follow the half-asleep person, then.                    ",
                  "           Adventure awaits, and so does my pillow. Let's get this guiding thing over with.                        ",
                                                                                                                                       };

            Random random = new Random();
            string randomLazyGuideDialogue = lazyGuideDialogues[random.Next(lazyGuideDialogues.Length)];

            Console.WriteLine(randomLazyGuideDialogue);

        }
        public static void Encounter(Hero hero)
        {
            Len len = new Len();
            Gen gen = new Gen();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");

            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero: (muttering) Oh, not again...                           ",
                       "                                                                          ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero: those nightmarish creatures...                         ",
                       "                                                                          ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero: Why do they haunt my dreams?                           ",
                       "                                                                          ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero: (to himself) Following orders from a chatty cat        ",
                       "                 in my dreams to tackle these absurd monsters...          ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero: well, here goes nothing.                               ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "     The Cowardly Hero extends his arms dramatically towards the sky      ",
                       "          like he's summoning a flock of heroic seagulls.                 ",
                       "                                                                          ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero: Behold,for I Leafwalker, the chosen one                ",
                       "                 the illuminator of this realm!                           ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero:  Only I possess the power to dispel the shadows!       ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero:......                                                  ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                       "                                                                          ",
                       "                                                                          ",
                       "    Cowardly Hero:  Hah, Who am I kidding?                                ",
                       "                                                                          ",
                       "                                                                          ");
            Console.ReadKey();

            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "   [1] LeafWalker...?                 2. A very suiting name for an idiot  ",
                       "                                                                           ",
                       "                                                                           ");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int choice;

            switch (keyInfo.KeyChar)
            {
                case '1':

                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: did I just hear someone call me the Cowardly Hero?            ",
                               "             Who said that?                                                ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintC("                                                                           ",
                               "                                                                           ",
                               "                           System Notice!                                  ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintC("                                                                           ",
                               "                                                                           ",
                               "                  You have Successfully enter the Game!                    ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: What the heck?! What's Happening?                             ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: Am I hallucinating things? Am I getting crazy?                ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Thread.Sleep(1000);
                    len.PrintC("                                                                           ",
                               "                                                                           ",
                               "                           System Notice!                                  ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Thread.Sleep(1000);
                    len.PrintL("                                                                           ",
                               "                                                                           ",
                               "          Excessive chatter detected. Initiating Silence Mode.             ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: System Not— mmmph?!                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: Hey! What's with the Silence Mode?!                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: I guess Im getting crazy                                      ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: Hey, God or whatever..                                        ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: how about some superpowers to squash the Demon Lord?          ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: You're guiding me, right? So— mmmph? mmphmmhp!                ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintC("                                                                           ",
                               "                                                                           ",
                               "                           System Notice!                                  ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintC("                                                                           ",
                               "                                                                           ",
                               "                           Still too noisy.                                ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: Okay okay, I'll shut my mouth!                                ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: .......                                                       ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: I have this weird dream...                                    ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: some weird talking cat spoke about your arrival               ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: well i didnt expect that you would be a God or something.     ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker: You're helping me, right?                                     ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "                                 [YES]                                     ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  Oh Thank God!                                                ",
                               "              Y'know It's really very scary trying to defeat               ",
                               "              the demon lord all by yourself!                              ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  Ha! You might be Wondering                                   ",
                               "              why does the hero have to travel all alone                   ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  Well.....                                                    ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  My team unexpectedly lost their                              ",
                               "              blessing to overcome the Demon Lord                          ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  But I dont have to fear everything now!                      ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  I have some unknown deity helping me..                       ",
                               "              I don't care of who you are as long as                       ",
                               "              I save the world from this Demon Lord                        ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  I have some unknown deity helping me..                       ",
                               "              I don't care of who you are as long as                       ",
                               "              I save the world from this Demon Lord                        ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  I have some unknown deity helping me..                       ",
                               "              I don't care of who you are as long as                       ",
                               "              I save the world from this Demon Lord                        ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               " LeafWalker:  Shall we get going? The sooner we start, the better.         ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");

                    break;

                case '2':

                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: What a nincompoop. Why must I play babysitter to a buffoon?  ",
                               "             (You explain everything that you need to explain)             ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: Shall we get going?                                          ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please Try Again.");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }

        public static void BeforeBandits(Hero hero)
        {
            Gen gen = new Gen();

            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Bandit: Halt, traveler! Your valuables, now, or you'll regret it!        ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  (Panting) Ah, could you at least let me catch my breath first?           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Bandit: (Laughs) Trying to buy time? We're not that gullible!     ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: Honestly, I'm as broke as a joke                             ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Bandit: (Sneering) Every traveler has something worth taking.            ",
                       "          Search him, boys!                                                ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Bandit: Boys, get 'em!                                                   ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");

        }
        public static void AfterBandits(Hero hero)
        {
            /*  Gen gen = new Gen();

              gen.PrintL("                                                                           ",
                         "                                                                           ",
                         "           Congratulations! you won against the Bandit                     ",
                         "                                                                           ",
                         "                                                                           ",
                         "                                                                           ",
                         "                                                                           ");   */

        }
        public static void BeforeKnights(Hero hero)
        {
            Gen gen = new Gen();


            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: (Gazing ahead) Ah, the Village of Hope at last.              ",
                       "               What an arduous journey!                                    ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  ???:     Hold, traveler! Before you enter                                ",
                       "           answer our riddle to prove your worth.                          ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker:(Perplexed) A riddle? Now, that's unusual.                    ",
                       "             What might this riddle be?                                    ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: Knight 1: What's 1 + 1?                                      ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();


            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int choice = int.Parse(keyInfo.KeyChar.ToString());
            switch (choice)
            {
                case 1:
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: Uhh, 2?                                                      ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1 and 2: (Suspicious) Remarkable                                  ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: ......??                                                     ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1: Such quick wit could be a sign of demonic influence!           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();

                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: Ha?! Wait, what?!                                            ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1: Prove you're not a demon.                                      ",
                               "            Fight us (for investigation purposes)                          ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: Seriously?                                                   ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: Fine (why this two become a knight                           ",
                               "              is the castle standard stoop so low??)                       ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");


                    break;
                case 2:
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  LeafWalker: It's 3                                                       ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1: Woa                                                            ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1: This guy is an idiot                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 2: ......                                                         ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1: Should we let him pass?                                        ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 2: I want to fight him! My instinct tells me he's a real deal     ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ",
                               "                                                                           ");
                    Console.ReadKey();
                    gen.PrintL("                                                                           ",
                               "                                                                           ",
                               "  Knight 1: E-even with a mind akin to that of a bird                      ",
                               "            you've still gotta face us in a fight to make it through       ",
                               "                                                                           ",
                               "                                                                           ");
                    break;

                default:
                    Console.WriteLine("Invalid Choice. Please try again");
                    return;
            }


            Console.ReadKey();
            Console.Clear();
        }
        public static void AfterKnights(Hero hero)
        {
            Console.WriteLine("Knight 1: Alright, you're clear. No demon magic detected.");
            Console.WriteLine($"LeafWalker: Finally!");
            Console.WriteLine("Welcome to the Village of Hope Lyria");


        }
        public static void BeforeUndead(Hero hero)
        {
            Gen gen = new Gen();
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Villager 1: (Pointing towards the horizon)                               ",
                       "              Look! What in the seven skies is that thing?                 ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Villager 2:  It looks like a man, but it moves all wrong. Its eyes...    ",
                       "               Its eyes... there's nothing but darkness.                   ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                       "                        System Alert!                                      ",
                       "             Some unknown bugs trying to destroy the game                  ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintC("                                                                            ",
                       "                                                                            ",
                       "                   Load Information to the Hero                             ",
                       "                                                                            ",
                       "                                                                            ");

            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: (Approaching the group)                                      ",
                       "              Everyone, stay back! This is no ordinary foe.                ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: It's what's known as an undead.                              ",
                       "              I've heard of them in stories from far-off lands.            ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker:  Everyone, stay back! This is no ordinary foe.               ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Knight 1:   Undead?  a walking corpse?                                   ",
                       "              How do we fight something that's already dead?               ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: I'll take the lead.                                          ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: Your Priority is to evacuate the citizens, Protect them.     ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Knight 2:  Understood.                                                   ",
                       "                                                                           ",
                       "                                                                           ");
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  Knight 2:  LeafWalker. We will secure the village                        ",
                       "             and stand ready to assist.                                    ",
                       "                                                                           ");
            Console.ReadKey();
            Console.Clear();

        }
        public static void AfterUndead(Hero hero)
        {
            RandomTimerClass randomTimer = new RandomTimerClass();
            Gen gen = new Gen();
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                      "                                                                           ",
                      "  LeafWalker: (Gasping) What sorcery is this?                              ",
                      "                                                                           ",
                      "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                      $"  LeafWalker: {hero}?                                                      ",
                       "                                                                           ",
                       "                                                                           ");
            randomTimer.Start();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  ??? : ☻♦5◘•5♠8♥1-21☺4♣... ☻♫♣8○6↑↓ ☼E •5♦$§♫EK2☺4☻3☻62♪ÿ▬....            ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(1000);
            Console.ReadKey();
            randomTimer.Start();
            gen.PrintL("                                                                          ",
                       "                                                                           ",
                       "  ??? :   ☻♦5◘5♠○•......$♦•☺...                                            ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: {hero}, what kind of enemy is this?                          ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(1000);
            Console.ReadKey();
            gen.PrintL("                                                                          ",
                      "                                                                           ",
                      "  ??? :   ♠○•5-§$`?-N§....♣○♠♦☺☻3♠○5•                                      ",
                      "                                                                           ",
                      "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: The air... it's getting heavier.                             ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  ??? :   ↓♀3☻♀....                                                        ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  LeafWalker: (Coughing) This... corruption in the air...                  ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(1000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                       "  ??? :   ♠○♦ss☻☻yy1E♦t........                                            ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                      $"  LeafWalker: I can barely breathe... must... must stay conscious...       ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(2000);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                      $"  LeafWalker: {hero}                                                       ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(500);
            Console.ReadKey();
            gen.PrintL("                                                                           ",
                       "                                                                           ",
                      $"  LeafWalker: Help this wo---                                              ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(500);
            randomTimer.Start();

        }
        public static void TheEnd(Hero hero)
        {
            Gen gen = new Gen();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                         System Error                                      ",
                       "          Unexpected anomaly detected within the game's fabric             ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                 Initiating Bug Fixing Process...                          ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"      Bug fixing Failed: Anomaly has integrated with the game's core.      ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                Attempting to Close the Console App...                     ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(1000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                             Wait                                          ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                   Before closing the Console App...                       ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"    Would you care to rate this adventure? Your feedback is invaluable.    ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                    Ehh, You're not satisfied?                             ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                The journey is still under construction                    ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                    and the creator is still                               ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"                        .... Learning                                      ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();
            gen.PrintC("                                                                           ",
                       "                                                                           ",
                      $"               Thank you for playing this Game. {hero}                     ",
                       "                                                                           ",
                       "                                                                           ");
            Thread.Sleep(3000);
            Console.ReadKey();

        }

    }
}





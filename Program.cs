using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv;
using CsvHelper;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using CsvHelper.Configuration;
using System.Globalization;
using ServiceStack.Text;
using YTCFW.SaveFile;

namespace YTCFW
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Gen gen = new Gen();
            string savefile = "Savefile.csv";
            AsciiArt asciiArt = new AsciiArt();
            // Assuming you have defined a Hero class and a Knight class
            int gold = 10;
            Hero hero;
       //     Knight knightInstance = new Knight("Lerroy", 7, 7, 7);
  //         Slime slime = new Slime("Slimey ", 5, 5, 5);
            Random rand = new Random();
            HeroCsvWriter csvWriter = new HeroCsvWriter();
            List<Hero> heroes;



            string userName = Environment.UserName;
            int userInput;
            int newgametrigger = 0;

            try
            {


                do

                {
                    ConsoleKeyInfo keyInfo;

                    if (newgametrigger == 1)
                    {
                        keyInfo = SimulateKeyPress('1');

                    }
                    else if (newgametrigger == 2)
                    {
                        keyInfo = SimulateKeyPress('1');

                    }
                    else
                    {
                         Story.Beginning();
                        keyInfo = Console.ReadKey();
                    }
                    if (char.IsDigit(keyInfo.KeyChar))
                    {
                        userInput = int.Parse(keyInfo.KeyChar.ToString());

                        switch (userInput)
                        {
                            case 1:
                                while (true)
                                {
                                    if (newgametrigger == 1)
                                    {
                                        hero = new Hero(userName, 5, 5, 5, 0, 0, 0, 0);
                                        Story.Encounter(hero);
                                        Console.ReadKey();
                                        newgametrigger = 2;
                                        hero.Progress = 2;
                                        int playerId = rand.Next(1000, 10000);
                                        hero.PlayerID = playerId.ToString();
                                        csvWriter.WriteHeroToFile(savefile, hero);
                                        break;
                                    }
                                    else if (newgametrigger == 2)
                                    {
                                        hero = new Hero(userName, 5, 5, 5, 0, 0, 0, 2);
                                        while (true)
                                        {
                                            Story.ProgressStory(ref hero, asciiArt);
                                            csvWriter.UpdateHeroInFile(savefile, hero);
                                        }
                                    }
                                    else
                                    {

                                        Console.WriteLine();
                                        heroes = HeroCsvWriter.ReadHeroesFromCSV(savefile);
                                        Console.WriteLine("Enter the player ID (numeric value):");
                                        string inputId = Console.ReadLine();

                                        if (int.TryParse(inputId, out int playerIdToRetrieve))
                                        {

                                            hero = csvWriter.ReadHeroFromFile(savefile, playerIdToRetrieve.ToString());

                                            if (hero != null)
                                            {
                                                // Do something with the retrieved hero
                                                Console.WriteLine("Hero data retrieved:");
                                                hero.DisplayInfo();
                                                Console.ReadKey();
                                                Console.Clear();
                                                while (true)
                                                {
                                                    Story.ProgressStory(ref hero, asciiArt);
                                                    csvWriter.UpdateHeroInFile(savefile, hero);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hero found with the specified player ID.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    }

                                }
                                break;

                            case 2:

                                newgametrigger++;


                                break;

                            case 3:
                                Console.Clear();
                                heroes = HeroCsvWriter.ReadHeroesFromCSV(savefile);
                                Console.WriteLine("Enter the player ID to delete (numeric value):");
                                string inputIdToDelete = Console.ReadLine();

                                // Validate and parse the user input as an integer
                                if (int.TryParse(inputIdToDelete, out int playerIdToDelete))
                                {

                                    csvWriter.DeleteHeroFromFile(savefile, playerIdToDelete.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                                }

                                break;

                            case 4:
                                Environment.Exit(0);
                                break;

                            default:

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter a number (1-4).");
                        userInput = 0;
                    }

                }
                while (userInput != 4);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"There is no file for that yet: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"There is no file for that yet in the directory: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Null Reference Exception Triggered: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception Triggered: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (SystemException ex)
            {
                Console.WriteLine($"System Exception Triggered: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static ConsoleKeyInfo SimulateKeyPress(char keyChar)
        {
            return new ConsoleKeyInfo(keyChar, ConsoleKey.A, false, false, false);
        }
    }
}

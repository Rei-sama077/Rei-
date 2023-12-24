using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using System.Diagnostics;

namespace YTCFW.SaveFile
{
    public class HeroCsvWriter
    {
        public void WriteHeroToFile(string savefile, Hero hero)
        {
            using (var writer = new StreamWriter(savefile))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var fileInfo = new FileInfo(savefile);
                if (fileInfo.Length == 0)
                {
                    csv.WriteHeader<Hero>();
                    csv.NextRecord();
                }

                csv.WriteRecord(hero);
                csv.NextRecord();
            }
        }


        public Hero ReadHeroFromFile(string filePath, string playerId)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true // Assuming your CSV file contains headers
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read(); // Read the header row
                csv.ReadHeader(); // Read the header record

                while (csv.Read())
                {
                    if (csv.GetField<string>("PlayerID") == playerId)
                    {
                        return new Hero(
                            csv.GetField<string>("Name"),
                            csv.GetField<int>("Intelligence"),
                            csv.GetField<int>("Strength"),
                            csv.GetField<int>("Agility"),
                            csv.GetField<int>("Gold"),
                            csv.GetField<int>("QuantityHPPotion"),
                            csv.GetField<int>("QuantityMPPotion"),
                            csv.GetField<int>("Progress")
                        // ... provide other required arguments according to your Hero class constructor
                        );
                    }

                }

                return null; // If no hero with the specified ID is found
            }
        }



        public void UpdateHeroInFile(string filePath, Hero updatedHero)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                var records = new List<Hero>();
                while (csv.Read())
                {
                    var record = csv.GetRecord<Hero>();
                    records.Add(record);
                }

                var existingHero = records.FirstOrDefault(h => h.PlayerID == updatedHero.PlayerID);

                if (existingHero != null)
                {
                    existingHero.Name = updatedHero.Name;
                    existingHero.Intelligence = updatedHero.Intelligence;
                    existingHero.Strength = updatedHero.Strength;
                    existingHero.Agility = updatedHero.Agility;
                    existingHero.Gold = updatedHero.Gold;
                    existingHero.QuantityHPPotion = updatedHero.QuantityHPPotion;
                    existingHero.QuantityMPPotion = updatedHero.QuantityMPPotion;
                    existingHero.Progress = updatedHero.Progress;
                    // Update other properties as needed

                    using (var writer = new StreamWriter(filePath))
                    using (var csvWriter = new CsvWriter(writer, config))
                    {
                        csvWriter.WriteHeader<Hero>();
                        csvWriter.NextRecord();
                        csvWriter.WriteRecords(records);
                    }

                    Console.WriteLine("Hero updated successfully.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("No hero found with the specified player ID. No changes made.");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
        }



        public void DeleteHeroFromFile(string filePath, string playerIdToDelete)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true // Assuming your CSV file contains headers
            };

            var records = new List<Hero>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read(); // Read the header row
                csv.ReadHeader(); // Read the header record

                while (csv.Read())
                {
                    var hero = csv.GetRecord<Hero>();
                    if (csv.GetField<string>("PlayerID") == playerIdToDelete)
                    {
                        records.Add(hero);
                    }
                }
            }

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteHeader<Hero>();
                csv.NextRecord();
                csv.WriteRecords(records);
            }
        }

        public static List<Hero> ReadHeroesFromCSV(string filePath)
{
    List<Hero> heroes = new List<Hero>();

    try
    {
                // Read all lines from the CSV file
                string[] lines = File.ReadAllLines(filePath);

                // Output the first few lines to verify the content
                foreach (var line in lines.Take(5)) // Display first 5 lines for inspection
                {
                    Console.WriteLine(line); // Output each line to see the content
                }

                // Skip the header line
                for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split('\t'); // Assuming tab-separated values

            if (data.Length >= 14)
            {
                string playerID = data[0];
                int progress = int.Parse(data[1]);
                int gold = int.Parse(data[2]);
                int quantityHPPotion = int.Parse(data[3]);
                int quantityMPPotion = int.Parse(data[4]);
                int intelligence = int.Parse(data[5]);
                int maxMana = int.Parse(data[6]);
                int mana = int.Parse(data[7]);
                int strength = int.Parse(data[8]);
                int maxHealth = int.Parse(data[9]);
                int hp = int.Parse(data[10]);
                int agility = int.Parse(data[11]);
                int defense = int.Parse(data[12]);
                string name = data[13];
                
                Hero hero = new Hero(name, intelligence, strength, agility, gold, quantityHPPotion, quantityMPPotion, progress)
                {
                    PlayerID = playerID,
                    Progress = progress,
                    Gold = gold,
                    QuantityHPPotion = quantityHPPotion,
                    QuantityMPPotion = quantityMPPotion,
                    Intelligence = intelligence,
                    MaxMana = maxMana,
                    Mana = mana,
                    Strength = strength,
                    MaxHealth = maxHealth,
                    HP = hp,
                    Agility = agility,
                    Defense = defense,
                    Name = name    

                };

                heroes.Add(hero);
            return heroes;

            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error reading CSV file: {ex.Message}");
    }

    return heroes;
}

    }



}


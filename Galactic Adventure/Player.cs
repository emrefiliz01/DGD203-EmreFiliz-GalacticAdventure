using System;
using System.Collections.Generic;

namespace GalacticAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public List<string> Inventory { get; private set; }
        public string CurrentLocation { get; set; }

        public Player()
        {
            Inventory = new List<string>();
            CurrentLocation = "Abandoned Space Station";
        }

        public void AddToInventory(string item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{item} has been added to your inventory.");
        }

        public void ShowInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
    }
}


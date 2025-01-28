using System;
using System.Collections.Generic;

namespace GalacticAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public string CurrentLocation { get; set; }
        private List<Item> inventory;

        public Player()
        {
            inventory = new List<Item>();
        }

        public void AddToInventory(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item.Name} has been added to your inventory.");
        }

        public void ShowInventory()
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("Your inventory contains:");
                foreach (var item in inventory)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty.");
            }
        }
    }
}

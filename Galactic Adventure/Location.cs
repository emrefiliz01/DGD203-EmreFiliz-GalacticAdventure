using System;
using System.Collections.Generic;

namespace GalacticAdventure
{
    public class Location
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Item> Items { get; private set; }
        public NPC Npc { get; private set; }

        public Location(string name, string description, NPC npc = null)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Npc = npc;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public Item GetItem(string itemName)
        {
            return Items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public void TalkToNpc()
        {
            if (Npc != null)
            {
                Npc.Talk();
            }
            else
            {
                Console.WriteLine("There's no one to talk to here.");
            }
        }
    }
}

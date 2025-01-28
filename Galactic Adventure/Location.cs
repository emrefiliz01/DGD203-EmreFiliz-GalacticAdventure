using System.Collections.Generic;

namespace GalacticAdventure
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Item GetItem(string itemName)
        {
            return Items.Find(item => item.Name.ToLower() == itemName.ToLower());
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}

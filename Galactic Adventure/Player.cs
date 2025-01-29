namespace GalacticAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public string CurrentLocation { get; set; }
        private List<Item> inventory;
        private List<AncientKeyFragment> keyFragments;

        public Player()
        {
            inventory = new List<Item>();
            keyFragments = new List<AncientKeyFragment>();
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

        public void AddKeyFragment(AncientKeyFragment fragment)
        {
            keyFragments.Add(fragment);
            Console.WriteLine("You have obtained an Ancient Key Fragment!");
        }

        public bool HasFullKey()
        {
            return keyFragments.Count >= 3;
        }

        public bool InventoryContainsItem(string itemName)
        {
            return inventory.Any(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveItemFromInventory(string itemName)
        {
            var item = inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                inventory.Remove(item);
                Console.WriteLine($"{item.Name} has been removed from your inventory.");
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }
    }
}

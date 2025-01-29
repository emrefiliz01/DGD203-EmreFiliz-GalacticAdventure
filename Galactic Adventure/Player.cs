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

            Console.WriteLine($"You have {keyFragments.Count} Ancient Key Fragments.");
        }

        public bool InventoryContainsItem(string itemName)
        {
            return inventory.Exists(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveItemFromInventory(string itemName)
        {
            Item itemToRemove = inventory.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                inventory.Remove(itemToRemove);
                Console.WriteLine($"{itemName} has been removed from your inventory.");
            }
            else
            {
                Console.WriteLine($"You don't have a {itemName} in your inventory.");
            }
        }

        public bool HasFullKey()
        {
            return keyFragments.Count >= 3;
        }

        public void AddKeyFragment(AncientKeyFragment fragment)
        {
            keyFragments.Add(fragment);
            Console.WriteLine("You have received an Ancient Key Fragment.");
        }
    }
}

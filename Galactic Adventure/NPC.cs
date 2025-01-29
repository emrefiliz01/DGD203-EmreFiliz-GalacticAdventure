namespace GalacticAdventure
{
    public class NPC
    {
        public string Name { get; private set; }
        private List<string> dialogues;

        public NPC(string name, List<string> dialogues)
        {
            Name = name;
            this.dialogues = dialogues;
        }

        public void Talk()
        {
            Console.WriteLine($"You are talking to {Name}.");
            foreach (var dialogue in dialogues)
            {
                Console.WriteLine(dialogue);
            }
        }

        public void Trade(Player player)
        {
            Console.WriteLine("What would you like to trade?");

            if (player.CurrentLocation == "abandoned_space_station" && player.InventoryContainsItem("Ancient Artifact"))
            {
                Console.WriteLine("You can trade the Ancient Artifact for an Ancient Key Fragment.");
                Console.Write("Do you want to trade? (yes/no): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    player.AddKeyFragment(new AncientKeyFragment());
                    player.RemoveItemFromInventory("Ancient Artifact");
                    Console.WriteLine("Trade successful! You received an Ancient Key Fragment.");
                }
                else
                {
                    Console.WriteLine("You chose not to trade.");
                }
            }
            else if (player.CurrentLocation == "alien_planet" && player.InventoryContainsItem("Alien Crystal"))
            {
                Console.WriteLine("You can trade the Alien Crystal for an Ancient Key Fragment.");
                Console.Write("Do you want to trade? (yes/no): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    player.AddKeyFragment(new AncientKeyFragment());
                    player.RemoveItemFromInventory("Alien Crystal");
                    Console.WriteLine("Trade successful! You received an Ancient Key Fragment.");
                }
                else
                {
                    Console.WriteLine("You chose not to trade.");
                }
            }
            else if (player.CurrentLocation == "alien_planet" && player.InventoryContainsItem("Frozen Key"))
            {
                Console.WriteLine("You can trade the Frozen Key for an Ancient Key Fragment.");
                Console.Write("Do you want to trade? (yes/no): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    player.AddKeyFragment(new AncientKeyFragment());
                    player.RemoveItemFromInventory("Frozen Key");
                    Console.WriteLine("Trade successful! You received an Ancient Key Fragment.");
                }
                else
                {
                    Console.WriteLine("You chose not to trade.");
                }
            }
            else
            {
                Console.WriteLine("You don't have anything to trade.");
            }
        }




    }
}

using System;

namespace GalacticAdventure
{
    public class Game
    {
        private Player player;
        private Map map;

        public Game()
        {
            player = new Player();
            map = new Map();
        }

        public void ShowMenu()
        {
            Console.WriteLine("Welcome to the Galactic Adventure!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    Console.WriteLine("Exiting the game...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    ShowMenu();
                    break;
            }
        }

        private void StartNewGame()
        {
            Console.Write("Enter your character's name: ");
            player.Name = Console.ReadLine();
            player.CurrentLocation = "abandoned_space_station";
            Console.WriteLine($"Welcome, {player.Name}! Your adventure begins now.");
            GameLoop();
        }

        private void ShowCredits()
        {
            Console.WriteLine("Game developed by Emre Filiz.");
            ShowMenu();
        }

        private void GameLoop()
        {
            while (true)
            {
                Console.WriteLine($"\nYou are currently at: {map.GetLocation(player.CurrentLocation).Name}");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Look Around");
                Console.WriteLine("2. Check Inventory");
                Console.WriteLine("3. Move to a New Location");
                Console.WriteLine("4. Quit");

                Console.Write("Choose an action: ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        LookAround();
                        break;
                    case "2":
                        player.ShowInventory();
                        break;
                    case "3":
                        MoveToLocation();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the game...");
                        return;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }

        private void LookAround()
        {
            Location currentLocation = map.GetLocation(player.CurrentLocation);
            Console.WriteLine($"Location: {currentLocation.Name}");
            Console.WriteLine($"Description: {currentLocation.Description}");

            if (currentLocation.Items.Count > 0)
            {
                Console.WriteLine("You see the following items:");
                foreach (var item in currentLocation.Items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }

                Console.Write("Would you like to pick up an item? (yes/no): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    Console.Write("Enter the name of the item: ");
                    string itemName = Console.ReadLine();

                    Item item = currentLocation.GetItem(itemName);
                    if (item != null)
                    {
                        player.AddToInventory(item);
                        currentLocation.RemoveItem(item);
                        Console.WriteLine($"You picked up: {item.Name}");
                    }
                    else
                    {
                        Console.WriteLine("That item is not here.");
                    }
                }
            }
            else
            {
                Console.WriteLine("There's nothing of interest here.");
            }
        }


        private void MoveToLocation()
        {
            Console.WriteLine("\nWhere would you like to go?");
            map.ShowAvailableLocations();

            Console.Write("Enter the name of the location: ");
            string newLocation = Console.ReadLine().ToLower().Replace(" ", "_");

            if (map.GetLocation(newLocation) != null)
            {
                player.CurrentLocation = newLocation;
                Console.WriteLine($"You have moved to {map.GetLocation(newLocation).Name}.");
            }
            else
            {
                Console.WriteLine("Invalid location. Please try again.");
            }
        }
    }
}

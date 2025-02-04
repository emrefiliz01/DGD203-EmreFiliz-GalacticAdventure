﻿namespace GalacticAdventure
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
                if (player.HasFullKey())
                {
                    Console.WriteLine("You have gathered all the Ancient Key Fragments! The Ancient Temple is now unlocked!");
                    player.CurrentLocation = "ancient_temple";
                    Console.WriteLine("You are now standing in the Ancient Temple, where the Ultimate Power Stone awaits.");
                    player.AddToInventory(new Item("Ultimate Power Stone", "The most powerful artifact in the galaxy."));

                    Console.WriteLine("Do you choose to be the Savior or the Destroyer of worlds?");
                    Console.WriteLine("1. Savior");
                    Console.WriteLine("2. Destroyer");

                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("You activate the Ultimate Power Stone. A brilliant light fills the temple, and the galaxy is saved.");
                        Console.WriteLine("Planets and civilizations unite, and peace is restored.");
                        Console.WriteLine("You are now a legend, known as the one who brought balance to the galaxy.");

                        Console.WriteLine("Dr. Orion: 'You did it... You've saved us all. The galaxy will remember you forever.'");
                        Console.WriteLine("Zylox: 'A new era begins. I have seen many things, but never something as powerful as this.'");
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("You activate the Ultimate Power Stone. A wave of destruction spreads across the galaxy.");
                        Console.WriteLine("Civilizations crumble, and the galaxy is plunged into chaos.");
                        Console.WriteLine("You walk away from the temple, knowing that your decision has forever altered the course of history.");

                        Console.WriteLine("Dr. Orion: 'You... You’ve doomed us all. But perhaps, this is the only way to end the cycle of corruption.'");
                        Console.WriteLine("Zylox: 'The galaxy will never be the same. What have you done?'");
                    }

                    break;
                }

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Look Around");
                Console.WriteLine("2. Check Inventory");
                Console.WriteLine("3. Move to Another Location");
                Console.WriteLine("4. Talk to NPC");
                Console.WriteLine("5. Quit");

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
                        MovePlayer();
                        break;
                    case "4":
                        TalkToNpc();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the game...");
                        return;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }


        private void TalkToNpc()
        {
            Location currentLocation = map.GetLocation(player.CurrentLocation);

            if (currentLocation.Npc != null)
            {
                currentLocation.TalkToNpc();

                Console.WriteLine("Would you like to trade with the NPC? (yes/no): ");
                string tradeChoice = Console.ReadLine().ToLower();

                if (tradeChoice == "yes")
                {
                    currentLocation.Npc.Trade(player);
                }
                else
                {
                    Console.WriteLine("You decided not to trade.");
                }
            }
            else
            {
                Console.WriteLine("There's no one to talk to here.");
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

        private void MovePlayer()
        {
            Console.WriteLine("Where would you like to go?");
            map.ShowAvailableLocations(player.CurrentLocation);

            Console.Write("Enter the location name: ");
            string newLocation = Console.ReadLine().ToLower().Replace(" ", "_");

            if (map.IsConnected(player.CurrentLocation, newLocation))
            {
                player.CurrentLocation = newLocation;
                Console.WriteLine($"You have moved to {map.GetLocation(newLocation).Name}.");
            }
            else
            {
                Console.WriteLine("You can't travel there directly. Try again.");
            }
        }

    }
}

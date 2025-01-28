using System;

namespace GalacticAdventure
{
    public class Game
    {
        private Player player;

        public Game()
        {
            player = new Player();
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
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Look Around");
                Console.WriteLine("2. Check Inventory");
                Console.WriteLine("3. Quit");

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
            Console.WriteLine($"You are currently at: {player.CurrentLocation}");
            Console.WriteLine("There’s nothing of interest here right now.");
        }
    }
}


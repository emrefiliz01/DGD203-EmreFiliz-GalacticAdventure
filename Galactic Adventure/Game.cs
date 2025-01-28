using System;

namespace GalacticAdventure
{
    public class Game
    {
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
            Console.WriteLine("Starting a new game...");
        }

        private void ShowCredits()
        {
            Console.WriteLine("Game developed by Emre Filiz.");
            ShowMenu();
        }
    }
}
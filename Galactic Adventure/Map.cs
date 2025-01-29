using System;
using System.Collections.Generic;

namespace GalacticAdventure
{
    public class Map
    {
        private Dictionary<string, Location> locations;
        private Dictionary<string, List<string>> connections;

        public Map()
        {
            NPC scientist = new NPC("Dr. Orion", new List<string>
            {
                "Greetings, traveler! I have been studying the ancient artifacts here.",
                "If you find anything unusual, bring it to me."
            });

            NPC alienMerchant = new NPC("Zylox", new List<string>
            {
                "Welcome, human! I trade rare items from across the galaxy.",
                "Do you have anything valuable to sell?"
            });

            locations = new Dictionary<string, Location>
            {
                { "abandoned_space_station", new Location("Abandoned Space Station", "A deserted station floating in space.", scientist) },
                { "alien_planet", new Location("Alien Planet", "A mysterious planet filled with unknown life forms.", alienMerchant) },
                { "frozen_moon_base", new Location("Frozen Moon Base", "An old base covered in ice and snow.") }
            };

            locations["abandoned_space_station"].AddItem(new Item("Ancient Artifact", "A mysterious artifact with unknown origins."));
            locations["alien_planet"].AddItem(new Item("Alien Crystal", "A rare crystal that glows in the dark."));
            locations["frozen_moon_base"].AddItem(new Item("Frozen Key", "A key made of ice that never melts."));

            connections = new Dictionary<string, List<string>>
            {
                { "abandoned_space_station", new List<string> { "alien_planet", "frozen_moon_base" } },
                { "alien_planet", new List<string> { "abandoned_space_station" } },
                { "frozen_moon_base", new List<string> { "abandoned_space_station" } }
            };
        }

        public Location GetLocation(string locationKey)
        {
            locations.TryGetValue(locationKey, out Location location);
            return location;
        }

        public void ShowAvailableLocations(string currentLocation)
        {
            if (connections.TryGetValue(currentLocation, out List<string> availableLocations))
            {
                Console.WriteLine("Available locations:");
                foreach (var loc in availableLocations)
                {
                    Console.WriteLine($"- {locations[loc].Name}");
                }
            }
            else
            {
                Console.WriteLine("There are no available locations to move to.");
            }
        }

        public bool IsConnected(string currentLocation, string newLocation)
        {
            if (connections.TryGetValue(currentLocation, out List<string> availableLocations))
            {
                return availableLocations.Contains(newLocation);
            }
            return false;
        }
    }
}

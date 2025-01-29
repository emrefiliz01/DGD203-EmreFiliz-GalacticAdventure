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
            locations = new Dictionary<string, Location>
            {
                { "abandoned_space_station", new Location("Abandoned Space Station", "A deserted station floating in space.") },
                { "alien_planet", new Location("Alien Planet", "A mysterious planet filled with unknown life forms.") },
                { "frozen_moon_base", new Location("Frozen Moon Base", "An old base covered in ice and snow.") }
            };

            connections = new Dictionary<string, List<string>>
            {
                { "abandoned_space_station", new List<string> { "alien_planet", "frozen_moon_base" } },
                { "alien_planet", new List<string> { "abandoned_space_station" } },
                { "frozen_moon_base", new List<string> { "abandoned_space_station" } }
            };
        }
        public bool IsConnected(string currentLocation, string newLocation)
        {
            return connections.ContainsKey(currentLocation) && connections[currentLocation].Contains(newLocation);
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
    }
}

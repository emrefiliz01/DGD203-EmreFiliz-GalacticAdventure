using System;
using System.Collections.Generic;

namespace GalacticAdventure
{
    public class Map
    {
        private Dictionary<string, Location> locations;

        public Map()
        {
            locations = new Dictionary<string, Location>
            {
                { "abandoned_space_station", new Location("Abandoned Space Station", "A deserted station in space.") },
                { "alien_planet", new Location("Alien Planet", "A planet with strange creatures.") },
                { "frozen_moon_base", new Location("Frozen Moon Base", "A cold and empty moon base.") }
            };
        }

        public Location GetLocation(string key)
        {
            if (locations.ContainsKey(key))
            {
                return locations[key];
            }
            else
            {
                Console.WriteLine("Invalid location. Returning to default location.");
                return locations["abandoned_space_station"];
            }
        }

        public void ShowAvailableLocations()
        {
            Console.WriteLine("Available locations:");
            foreach (var location in locations)
            {
                Console.WriteLine($"- {location.Value.Name}");
            }
        }
    }
}
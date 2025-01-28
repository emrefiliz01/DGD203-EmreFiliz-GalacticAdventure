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
                { "abandoned_space_station", new Location("Abandoned Space Station", "A deserted station floating in space.") },
                { "alien_planet", new Location("Alien Planet", "A mysterious planet filled with unknown life forms.") },
                { "frozen_moon_base", new Location("Frozen Moon Base", "An old base covered in ice and snow.") }
            };

            // Adding items to locations
            locations["abandoned_space_station"].AddItem(new Item("Keycard", "A keycard used to access restricted areas."));
            locations["alien_planet"].AddItem(new Item("Alien Artifact", "A strange object radiating a faint glow."));
            locations["frozen_moon_base"].AddItem(new Item("Thermal Suit", "A suit designed to withstand extreme cold."));
        }

        public Location GetLocation(string locationKey)
        {
            locations.TryGetValue(locationKey, out Location location);
            return location;
        }

        public void ShowAvailableLocations()
        {
            foreach (var location in locations)
            {
                Console.WriteLine($"- {location.Value.Name}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

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
    }
}

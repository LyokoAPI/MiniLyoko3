using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Network
    {
        public ICollection<VirtualWorld> VirtualWorlds { get; set; } = new List<VirtualWorld>();
        private static Network Instance;

        public static Network GetOrCreate()
        {
            return Instance ?? (Instance = NewDefaultNetwork());
        }
        private Network()
        {
            
        }

        public VirtualWorld AddVirtualWorld(string virtualWorld)
        {
            var newWorld = new VirtualWorld(virtualWorld);
            return AddVirtualWorld(newWorld);
        }

        public VirtualWorld AddVirtualWorld(VirtualWorld virtualWorld)
        {
            if (GetVirtualWorld(virtualWorld.Name) == null)
            {
                VirtualWorlds.Add(virtualWorld);
                return virtualWorld;
            }

            return null;
        }

        public VirtualWorld GetVirtualWorld(string name)
        {
            var worlds = VirtualWorlds.FirstOrDefault(world => world.Name == name);
            return worlds;
        }

        private static Network NewDefaultNetwork()
        {
            var network = new Network();
            network
                .AddVirtualWorld(new VirtualWorld("lyoko"))
                    .AddSector("forest")
                    .AddSector("ice")
                    .AddSector("desert")
                    .AddSector("mountain")
                    .AddSector("carthage", 1);
            
            network
                .AddVirtualWorld(new VirtualWorld("forestreplica"))
                    .AddSector("forest");
            network
                .AddVirtualWorld(new VirtualWorld("cortex"))
                    .AddSector("cortex", 10);

            return network;
        }

        public Tower ActivateRandom(string activator)
        {
            Random random = new Random();
            Tower tower;
            int tries = 0;
            const int max_tries = 100;
            do
            {
                int randomWorld = random.Next(VirtualWorlds.Count);
                tower = VirtualWorlds.ToList()[randomWorld].ActivateRandom(activator);
                tries++;
            } while (tower == null && tries != max_tries);

            return tower;

        }

    }
}
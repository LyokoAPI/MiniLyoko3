using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class VirtualWorld
    {
        public ICollection<Sector> Sectors { get; set; }  = new List<Sector>();
        public string Name { get; set; }

        public VirtualWorld(string name)
        {
            Name = name;
        }

        public Sector GetSector(string name)
        {
            var sectors = Sectors.Where(sector => sector.Name == name);
            return sectors.FirstOrDefault();
        }

        public Tower Activate(string sector, int id, string activator = "XANA")
        {
            return GetSector(sector)?.Activate(id,activator);
        }

        public Tower GetTower(string sector, int number)
        {
            return GetSector(sector)?.GetTower(number);
        }

        public VirtualWorld AddSector(string name, int towers = 10)
        {
            if (GetSector(name) == null)
            {
                Sectors.Add(new Sector(this,name,towers));
            }

            return this;
        }

        public Tower ActivateRandom(string activator = "XANA")
        {
            Random random = new Random();
            var possibleSectors = Sectors.Where(sector => sector.Towers.Any())
                .Where(sector => sector.Towers.Any(tower => !tower.Activated)).ToList();
            if (!possibleSectors.Any())
            {
                return null;
            }

            int number = random.Next(possibleSectors.Count);
            var chosenSector = Sectors.ToList()[number];
            return chosenSector.ActivateRandom(activator);
        }
        
        
    }
}
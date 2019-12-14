using System;
using System.Collections.Generic;
using System.Linq;
namespace Domain
{
    public class Sector
    {
        public VirtualWorld VirtualWorld { get; set; }
        public ICollection<Tower> Towers { get; } = new List<Tower>();
        public string Name { get; set; }

        public Sector(VirtualWorld world, string name, int towers)
        {
            Name = name;
            VirtualWorld = world;
            for (int i = 1; i <= towers; i++)
            {
                AddTower(i);
            }
        }


        public Tower Activate(int id, string activator = "XANA")
        {
            var tower = GetTower(id);
            tower?.Activate(activator);
            return tower;
        }

        public Tower GetTower(int id)
        {
            List<Tower> towers = Towers.Where(tower1 => tower1.Number == id).ToList();
            if (towers.Any())
            {
                return towers.First();
            }

            return null;
        }

        public void AddTower(int id)
        {
            if (GetTower(id) == null)
            {
                Towers.Add(new Tower(this,id));
            }
        }

        public Tower ActivateRandom(string activator = "XANA")
        {
            var tower = GetRandomTower();
            int tries = 0;
            const int maxTries = 9;
            while (tower.Activated && tries != maxTries )
            {
                tower = GetRandomTower();
                tries++;
            }
            tower.Activate(activator);
            return tower;
        }

        public Tower GetRandomTower()
        {
            Random random = new Random();
            int number = random.Next(Towers.Count);
            if (Towers.Any())
            {
                return Towers.ToList()[number];
            }

            return null;
        }
    }
}
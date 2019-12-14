using Domain;

namespace Backend.Commands.aelita
{
    public class Aelita : Command
    {
        public override string Name { get; set; } = "aelita";
        protected override void DoCommand(string[] args)
        {
            CheckLength(0, 3);
            if (args.Length == 0)
            {
                DeactivateAll();
                Output("All Towers deactivated");
            }
            else
            {
                CheckLength(3);
                
                Deactivate(args[0],args[1],CheckNumber(2));
            }
        }
        
        
        private void DeactivateAll()
        {
            foreach (var virtualWorld in Network.GetOrCreate().VirtualWorlds)
            {
                foreach (var virtualWorldSector in virtualWorld.Sectors)
                {
                    foreach (var tower in virtualWorldSector.Towers)
                    {
                        tower.Deactivate();
                    }
                }
            }
        }

        private void Deactivate(string virtualworldname, string sector, int id)
        {
            var virtualworld = Network.GetOrCreate().GetVirtualWorld(virtualworldname);
            if (virtualworld == null)
            {
                throw new CommandException(this, "That virtual world does not exist!");
            }

            var tower = virtualworld.Activate(sector, id, "NONE");
            if (tower == null)
            {
                if (virtualworld.GetSector(sector) == null)
                {
                    throw new CommandException(this, "that sector does not exist!");
                }
                else
                {
                    throw new CommandException(this, "that tower does not exist!");
                }
            }
            Output("Tower deactivated");
        }
        
    }
}
using Domain;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.Aelita
{
    public class Aelita : Command
    {
        public override string Name => "aelita";
        public override string Usage => "aelita.[world].[sector].[towerNumber]";
        public override int MaxArgs => 3;
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
                throw new CommandException(this, "That Virtual World Does Not Exist!");
            }
            if (virtualworld.GetSector(sector) == null)
            {
                throw new CommandException(this, "That Sector Does Not Exist!");
            }

            var tower = virtualworld.Activate(sector, id, LyokoAPI.VirtualStructures.APIActivator.NONE);
            if (tower == null)
            {
                throw new CommandException(this, "That Tower Does Not Exist!");
            }
            Output("Tower Deactivated");
        }
        
    }
}
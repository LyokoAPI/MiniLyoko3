using Domain;
using Backend.extensions;

namespace Backend.Commands.TowerCommand
{
    public class Deactivate : Command
    {
        public override string Name => "deactivate";
        public override string Usage => "tower.deactivate.[world].[sector].[towerNumber]";
        public override int MinArgs => 3;

        protected override void DoCommand(string[] args)
        {
            var virtualworld = Network.GetOrCreate().GetVirtualWorld(args[0]);
            if (virtualworld == null)
            {
                throw new CommandException(this, "That virtual world does not exist!");
            }
            var tower = virtualworld.Deactivate(args[1], CheckNumber(2));
            if (tower == null)
            {
                if (virtualworld.GetSector(args[1]) == null)
                {
                    throw new CommandException(this, "that sector does not exist!");
                }
                else
                {
                    throw new CommandException(this, "that tower does not exist!");
                }
            }
            Output($"Deactivated tower: {tower.GetFullName()}");
        }
    }
}

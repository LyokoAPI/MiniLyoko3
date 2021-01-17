using Domain;
using BackEnd.Extensions;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.TowerCommand
{
    public class Deactivate : Command
    {
        public override string Name => "deactivate";
        public override string Usage => "tower.deactivate.<world>.<sector>.<towerNumber>";
        public override int MinArgs => 3;

        protected override void DoCommand(string[] args)
        {
            var virtualworld = Network.GetOrCreate().GetVirtualWorld(args[0]);
			if (virtualworld == null)
			{
				throw new CommandException(this, "That Virtual World Does Not Exist!");
			}
			if (virtualworld.GetSector(args[1]) == null)
			{
				throw new CommandException(this, "That Sector Does Not Exist!");
			}

			var tower = virtualworld.Deactivate(args[1], CheckNumber(2));
			if (tower == null)
			{
				throw new CommandException(this, "That Tower Does Not Exist!");
			}
			Output($"Deactivated tower: {tower.GetFullName()}");
        }
    }
}

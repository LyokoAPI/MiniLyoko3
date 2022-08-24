using BackEnd.Extensions;
using Domain;
using LyokoAPI.API;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.TowerCommand
{
	public class Activate : Command
	{
		public override string Name => "activate";
		public override string Usage => "tower.activate.<world>.<sector>.<towerNumber>.<activator>";
		public override int MinArgs => 4;

		protected override void DoCommand(string[] args)
		{
			bool success = LyokoParser.TryParseActivator(args[3].ToUpper(), out var activator);
			if (!success) throw new CommandException(this, $"{args[3]} is not an activator!");
			//Domain.Tower tower = Network.GetOrCreate().ActivateRandom(activator.ToString());
			//Output($"Activated tower: {tower.GetFullName()} by {activator}");
			var virtualworld = Network.GetOrCreate().GetVirtualWorld(args[0]);
			if (virtualworld == null)
			{
				throw new CommandException(this, "That Virtual World Does Not Exist!");
			}
			if (virtualworld.GetSector(args[1]) == null)
			{
				throw new CommandException(this, "That Sector Does Not Exist!");
			}

			var tower = virtualworld.Activate(args[1], CheckNumber(2), activator);
			if (tower == null)
			{
				throw new CommandException(this, "That Tower Does Not Exist!");
			}
			Output($"Activated tower: {tower.GetFullName()} by {activator}");
		}
	}
}

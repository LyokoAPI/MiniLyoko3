using BackEnd.Extensions;
using Domain;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.Xana
{
	public class Attack : Command
	{
		public override string Name => "attack";
		public override string DisplayName => "xana.attack";

		protected override void DoCommand(string[] args)
		{
			Tower tower = Network.GetOrCreate().ActivateRandom(LyokoAPI.VirtualStructures.APIActivator.XANA);
			Output($"Activated tower: {tower.GetFullName()}");
		}
	}
}

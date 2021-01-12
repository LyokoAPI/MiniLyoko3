using Backend.extensions;
using Domain;

namespace Backend.Commands.Xana
{
	public class Attack : Command
	{
		public override string Name => "attack";
		public override string DisplayName => "xana.attack";

		protected override void DoCommand(string[] args)
		{
			Tower tower = Network.GetOrCreate().ActivateRandom("xana");
			Output($"Activated tower: {tower.GetFullName()}");
		}
	}
}

using Backend.extensions;
using Domain;

namespace Backend.Commands.xana
{
    public class Attack : Command
    {
        public override string Name { get; set; } = "attack";
        public override string DisplayName { get; } = "xana.attack";

        protected override void DoCommand(string[] args)
        {
            Tower tower = Network.GetOrCreate().ActivateRandom("xana");
            Output($"Activated tower: {tower.GetFullName()}");
        }
    }
}
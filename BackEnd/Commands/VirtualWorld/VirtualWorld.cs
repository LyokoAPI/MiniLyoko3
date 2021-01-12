using Backend.extensions;
using Domain;
using System.Collections.Generic;

namespace Backend.Commands.VirtualWorldCommand
{
    public class VirtualWorldCommand : Command
    {
        public override string Name => "world";
        public override int MinArgs => 1;
        public override List<Command> SubCommands { get; protected set; } = new List<Command>() { new List(), new Sectors(), new Create(), new Destroy() };

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

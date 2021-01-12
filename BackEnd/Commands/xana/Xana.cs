using System.Collections.Generic;

namespace Backend.Commands.Xana
{
    public class Xana : Command
    {
        public override string Name => "xana";
        public override int MinArgs => 1;

        public override List<Command> SubCommands { get; protected set; } = new List<Command>() {new Attack(), new Awaken(), new Defeat()};

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}
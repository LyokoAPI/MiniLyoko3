using System.Collections.Generic;

namespace Backend.Commands.xana
{
    public class Xana : Command
    {
        public override string Name { get; set; } = "xana";
        public override int MinArgs { get; set; } = 1;

        public override List<Command> subCommands { get; protected set; } = new List<Command>() {new Attack()};

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}
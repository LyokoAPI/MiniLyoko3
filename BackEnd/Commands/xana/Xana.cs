using System.Collections.Generic;

namespace Backend.Commands.xana
{
    public class Xana : Command
    {
        public override string Name { get; set; } = "xana";
        
        public override List<Command> subCommands { get; protected set; } = new List<Command>() {new Attack()};

        protected override void DoCommand(string[] args)
        {
            CheckLength(1);
            DoSubCommand(args);
        }
    }
}
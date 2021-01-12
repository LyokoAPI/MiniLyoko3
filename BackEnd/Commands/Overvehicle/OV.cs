using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.Overvehicle
{
    public class OV : Command
    {
        public override string Name => "ov";
        public override int MinArgs => 1;

        public override List<Command> SubCommands { get; protected set; } = new List<Command>() { new Virtualize(), new Devirtualize(), new Hurt(), new Ride(), new GetOff() };

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

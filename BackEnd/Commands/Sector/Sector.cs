using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.SectorCommand
{
    public class Sector : Command
    {
        public override string Name => "sector";
        public override int MinArgs => 1;

        public override List<Command> SubCommands { get; protected set; } = new List<Command>() { new Create(), new Destroy()};

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

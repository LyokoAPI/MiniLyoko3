using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.Overvehicle
{
    public class OV : Command
    {
        public override string Name => "ov";
        public override int MinArgs => 1;

        public override List<ICommand> SubCommands { get; protected set; } = new List<ICommand>() { new Virtualize(), new Devirtualize(), new Hurt(), new Ride(), new GetOff() };

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

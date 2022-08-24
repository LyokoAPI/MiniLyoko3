using System.Collections.Generic;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.Xana
{
    public class Xana : Command
    {
        public override string Name => "xana";
        public override int MinArgs => 1;

        public override List<ICommand> SubCommands { get; protected set; } = new List<ICommand>() {new Attack(), new Awaken(), new Defeat()};

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}
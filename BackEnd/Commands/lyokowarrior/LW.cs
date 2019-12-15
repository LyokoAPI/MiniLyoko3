using System.Collections.Generic;

namespace Backend.Commands.lyokowarrior
{
    public class LW : Command
    {
        public override string Name { get; set; } = "lw";
        public override int MinArgs { get; set; } = 1;

        public override List<Command> subCommands { get; protected set; } = new List<Command>() { new Virtualize(), new Devirtualize(), new Xanafy(), new Translate(), new Kill(), new Hurt(), new Heal(), new Frontier() };

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

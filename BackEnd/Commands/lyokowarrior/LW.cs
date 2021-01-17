using System.Collections.Generic;
using LyokoAPI.Commands;

namespace BackEnd.Commands.LyokoWarrior
{
    public class LW : Command
    {
        public override string Name => "lw";
        public override int MinArgs => 1;

        public override List<ICommand> SubCommands { get; protected set; } = new List<ICommand>() { new Virtualize(), new Devirtualize(), new Xanafy(), new Translate(), new Detranslate(), new Kill(), new Hurt(), new Heal(), new Frontier(), new Dexanafy(), new PermXanafy(), new ResolveCodeEarth(), new CorruptDNA(), new FixDNA() };

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

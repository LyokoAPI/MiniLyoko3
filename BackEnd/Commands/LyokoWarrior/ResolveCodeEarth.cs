using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.LyokoWarrior
{
    public class ResolveCodeEarth : Command
    {
        public override string Name => "resolvecodeearth";
        public override string Usage => "lw.resolvecodeearth.<warrior>";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "Invalid Warrior!");
            }

            if (!warrior.Statuses.Contains(LW_Status.VIRTUALIZED))
            {
                throw new CommandException(this, "Can't Resolve Earth Code");
            }
            LW_CodeEarthResolvedEvent.Call(warrior);
            Output($"{warrior.WarriorName} Earth Code Resolved.");
        }
    }
}

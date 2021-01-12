using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.LyokoWarrior
{
    public class ResolveCodeEarth : Command
    {
        public override string Name => "resolvecodeearth";
        public override string Usage => "lw.resolvecodeearth.[warrior]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "invalid warrior!");
                return;
            }

            if (!warrior.Statuses.Contains(LW_Status.VIRTUALIZED))
            {
                throw new CommandException(this, "Cant Resolve Earth Code");
            }
            LW_CodeEarthResolvedEvent.Call(warrior);
            Output(warrior.WarriorName + " earth code resolved.");
        }
    }
}

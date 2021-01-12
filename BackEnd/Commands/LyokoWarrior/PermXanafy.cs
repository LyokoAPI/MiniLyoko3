using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.LyokoWarrior
{
    public class PermXanafy : Command
    {
        public override string Name => "permxanafy";
        public override string Usage => "lw.permxanafy.[warrior]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "invalid warrior!");
                return;
            }

            if (!(warrior.Statuses.Contains(LW_Status.VIRTUALIZED) && !warrior.Statuses.Contains(LW_Status.PERMXANAFIED)))
            {
                throw new CommandException(this, "Can't permxanafy warrior!");
                return;
            }
            LW_PermXanafyEvent.Call(warrior);
            Output(warrior.WarriorName + " permxanafied.");
        }
    }
}

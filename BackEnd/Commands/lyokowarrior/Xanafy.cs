using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.LyokoWarrior
{
    public class Xanafy : Command
    {
        public override string Name => "xanafy";
        public override string Usage => "lw.xanafy.[warrior]";
        public override int MinArgs => 1;
        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"invalid warrior!");
                return;
            }

            if (!(warrior.Statuses.Contains(LW_Status.VIRTUALIZED) && !(warrior.Statuses.Contains(LW_Status.XANAFIED) || warrior.Statuses.Contains(LW_Status.PERMXANAFIED))))
            {
                throw new CommandException(this,"Can't xanafy warrior!");
                return;
            }
            LW_XanaficationEvent.Call(warrior);
            Output(warrior.WarriorName + " xanafied.");
        }
    }
}
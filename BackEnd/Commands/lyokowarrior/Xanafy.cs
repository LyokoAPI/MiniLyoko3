using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Xanafy : Command
    {
        public override string Name { get; set; } = "xanafy";
        public override string Usage { get; } = "lw.xanafy.[warrior]";
        public override int MinArgs { get; set; } = 1;
        protected override void DoCommand(string[] args)
        {
            LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"invalid warrior!");
                return;
            }

            if (warrior.Status != Status.VIRTUALIZED&&warrior.Status!=Status.XANAFIED)
            {
                throw new CommandException(this,"Can't xanafy warrior!");
                return;
            }
            LW_XanaficationEvent.Call(warrior);
            Output(warrior.WarriorName + " xanafied.");
        }
    }
}
using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.LyokoWarrior
{
    public class Dexanafy : Command
    {
        public override string Name => "dexanafy";
        public override string Usage => "lw.dexanafy.[warrior]";
        public override int MinArgs => 1;
        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "invalid warrior!");
            }

            if (!(warrior.Statuses.Contains(LW_Status.VIRTUALIZED)&&(warrior.Statuses.Contains(LW_Status.XANAFIED)|| warrior.Statuses.Contains(LW_Status.PERMXANAFIED))))
            {
                throw new CommandException(this, "Can't dexanafy warrior!");
            }
            LW_DexanaficationEvent.Call(warrior);
            Output(warrior.WarriorName + " dexanafied.");
        }
    }
}

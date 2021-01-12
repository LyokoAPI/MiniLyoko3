using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.LyokoWarrior
{
    public class FixDNA : Command
    {
        public override string Name => "fix";
        public override string Usage => "lw.fix.[warrior]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "invalid warrior!");
                return;
            }

            if (!(warrior.Statuses.Contains(LW_Status.VIRTUALIZED) && warrior.Statuses.Contains(LW_Status.DNACORRUPTED)))
            {
                throw new CommandException(this, "Cant corrupt dna");
            }
            LW_FixedDNAEvent.Call(warrior);
            Output(warrior.WarriorName + " dna corrupted");
        }
    }
}

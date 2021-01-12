using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.RealWorld.Location;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;

namespace Backend.Commands.LyokoWarrior
{
    public class Detranslate : Command
    {
        public override string Name => "detranslate";
        public override string Usage => "lw.detranslate.[warrior]";
        public override int MinArgs => 1;
        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this, "Invalid warrior!");
                return;
            }
            if (!warrior.Statuses.Contains(LW_Status.TRANSLATED))
            {
                throw new CommandException(this, "Cannot detranslate warrior!");
            }
            LW_DeTranslationEvent.Call(warrior, new APISector("lyoko","ice", 10));
            Output(warrior.WarriorName + " translated.");
        }
    }
}

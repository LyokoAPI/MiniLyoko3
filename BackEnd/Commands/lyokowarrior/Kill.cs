using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.LyokoWarrior
{
    public class Kill : Command
    {
        public override string Name => "kill";
        public override string Usage => "lw.kill.[warrior]";
        public override int MinArgs => 1;
        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!"); 
            }
            LW_DeathEvent.Call(warrior);
            Output(warrior.WarriorName + " has been lost.");
        }
    }
}
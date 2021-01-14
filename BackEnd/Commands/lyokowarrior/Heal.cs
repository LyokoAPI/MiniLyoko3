using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.LyokoWarrior
{
    public class Heal : Command
    {
        public override string Name => "heal";
        public override string Usage => "lw.heal.[warrior].[amount]";
        public override int MinArgs => 2;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid warrior!");
            } 
            if (!warrior.Statuses.Contains( LW_Status.VIRTUALIZED))
            {
                throw new CommandException(this,"Can't heal warrior!");
            }
            LW_HealEvent.Call(warrior,int.Parse(args[1]));
            Output(warrior.WarriorName + " healed.");
        }
    }
}
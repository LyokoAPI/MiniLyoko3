using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.LyokoWarrior
{
    public class Frontier : Command
    {
        public override string Name => "frontier";
        public override string Usage => "lw.frontier.<warrior>";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid Warrior!");
            } 
            if (!warrior.Statuses.Contains( LW_Status.VIRTUALIZED))
            {
                throw new CommandException(this,"Can't Frontier Warrior!");
            }
            LW_FrontierEvent.Call(warrior);
            Output($"{warrior.WarriorName} Frontiered.");
        }
    }
}
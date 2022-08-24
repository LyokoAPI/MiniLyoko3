using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.LyokoWarrior
{
    public class Kill : Command
    {
        public override string Name => "kill";
        public override string Usage => "lw.kill.<warrior>";
        public override int MinArgs => 1;
        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                throw new CommandException(this,"Invalid Warrior!"); 
            }
            LW_DeathEvent.Call(warrior);
            Output($"{warrior.WarriorName} Has Been Lost.");
        }
    }
}
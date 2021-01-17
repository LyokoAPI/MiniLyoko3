using System;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.LyokoWarrior
{
    public class Virtualize : Command
    {
        public override string Name => "virt";
        public override string Usage => "lw.virt.<warrior>";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = LyokoWarriors.GetByName(args[0].ToLower());
            if (warrior == null)
            {
                Output("no warrior");
                throw new CommandException(this,"Invalid Warrior!");
            }
            LW_VirtEvent.Call(warrior,"forest");
            Output($"{warrior.WarriorName} virtualized.");
        }
    }
}
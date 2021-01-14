using System;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.LyokoWarrior
{
    public class Virtualize : Command
    {
        public override string Name => "virt";
        public override string Usage => "lw.virt.[warrior]";
        public override int MinArgs => 1;

        protected override void DoCommand(string[] args)
        {
            Output("args:"+ args[0]);
            LyokoAPI.VirtualEntities.LyokoWarrior.LyokoWarrior warrior = null;
            try
            { 
                warrior = LyokoWarriors.GetByName(args[0].ToLower());
            }
            catch (Exception e)
            {
                LyokoLogger.Log(Name,e.ToString());
            }
            if (warrior == null)
            {
                Output("no warrior");
                throw new CommandException(this,"invalid warrior!");
            }
            Output("warrior: "+warrior.WarriorName);
            LW_VirtEvent.Call(warrior,"forest");
            Output(warrior.WarriorName + " virtualized.");
        }
    }
}
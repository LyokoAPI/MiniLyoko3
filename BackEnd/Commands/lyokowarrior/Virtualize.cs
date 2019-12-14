using System;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace Backend.Commands.lyokowarrior
{
    public class Virtualize : Command
    {
        public override string Name { get; set; } = "virt";
        public override string Usage { get; } = "virt.[warrior]";

        protected override void DoCommand(string[] args)
        {
            Output("args:"+ args[0]);
            LyokoWarrior warrior = null;
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
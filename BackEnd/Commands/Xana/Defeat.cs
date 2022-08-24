using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace BackEnd.Commands.Xana
{
    public class Defeat : Command
    {
        public override string Name => "defeat";
        public override string Usage => "xana.defeat";

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.Events.XanaDefeatEvent.Call();
            Output("Xana Defeated");
        }
    }
}

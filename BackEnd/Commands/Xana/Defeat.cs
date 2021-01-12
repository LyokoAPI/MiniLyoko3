using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.Xana
{
    public class Defeat : Command
    {
        public override string Name => "defeat";
        public override string Usage => "xana.defeat";

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.Events.XanaDefeatEvent.Call();
        }
    }
}

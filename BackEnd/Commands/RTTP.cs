using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Events;
using LyokoAPI.Commands;

namespace Backend.Commands
{
    public class RTTP : Command
    {
        public override string Name => "rttp";
        public override string Usage => "rttp";

        protected override void DoCommand(string[] args)
        {
            RTTPEvent.Call();
            Output("RTTP'ed");
        }
    }
}

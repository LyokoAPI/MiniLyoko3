using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.Xana
{
    public class Awaken : Command
    {
        public override string Name => "awaken";
        public override string Usage => "xana.awaken";

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.Events.XanaAwakenEvent.Call();
        }
    }
}

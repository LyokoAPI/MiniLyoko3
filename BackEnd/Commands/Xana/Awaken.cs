using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Commands;
using LyokoAPI.Exceptions;

namespace Backend.Commands.Xana
{
    public class Awaken : Command
    {
        public override string Name => "awaken";
        public override string Usage => "xana.awaken";

        protected override void DoCommand(string[] args)
        {
            LyokoAPI.Events.XanaAwakenEvent.Call();
            Output("Xana Awakened");
        }
    }
}

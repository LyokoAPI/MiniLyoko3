using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyokoAPI.Commands;

namespace BackEnd.Commands.TowerCommand
{
    public class Tower : Command
    {
        public override string Name => "tower";
        public override int MinArgs => 1;

        public override List<ICommand> SubCommands { get; protected set; } = new List<ICommand>() { new Activate(), new Deactivate() };

        protected override void DoCommand(string[] args)
        {
            DoSubCommand(args);
        }
    }
}

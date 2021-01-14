using BackEnd;
using Backend.Commands.Xana;
using Backend.Commands.LyokoWarrior;
using Backend.Commands.Aelita;
using Backend.Commands.Overvehicle;
using Backend.Commands.TowerCommand;
using Backend.Commands.SectorCommand;
using Backend.Commands.VirtualWorldCommand;
using Backend.Commands;
using Godot;
using LyokoAPI.API;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using LyokoAPI.Commands;

namespace MiniLyoko3
{
    public class Listener : LAPIListener
    {
        private readonly RichTextLabel CommandOutput;
        private readonly RichTextLabel LogOutput;
        private MiniLyokoCommandListener _commandListener;
        public Listener(MainPanel panel)
        {
            CommandOutput = panel.CommandOutputBox;
            LogOutput = panel.LogText;
            _commandListener = new MiniLyokoCommandListener();

            _commandListener.AddCommand(new Xana());
            _commandListener.AddCommand(new Tower());
            _commandListener.AddCommand(new Sector());
            _commandListener.AddCommand(new LW());
            _commandListener.AddCommand(new Aelita());
            _commandListener.AddCommand(new OV());
            _commandListener.AddCommand(new RTTP());
            _commandListener.AddCommand(new VirtualWorldCommand());

            //Ensure Help command is always the last command to be added to the listener
            List<ICommand> commands = _commandListener.GetCommands();
            _commandListener.AddCommand(new Help(ref commands));
        }

        
        public override void onCommandOutput(string message)
        {
            ToCommandOut(message);
        }

        public override void onCommandInput(string input)
        {
            _commandListener.onCommandInput(input);
        }

        public override void onLyokoLog(string message)
        {
            ToLog(message);
        }

        private void ToLog(string text)
        {
            LogOutput.Text += $"{text}\n";
        }

        private void ToCommandOut(string text)
        {
            CommandOutput.Text += $"{text}\n";
        }
        
        
    }
}
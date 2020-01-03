using BackEnd;
using Backend.Commands.xana;
using Backend.Commands.lyokowarrior;
using Backend.Commands.aelita;
using Backend.Commands;
using Godot;
using LyokoAPI.API;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MiniLyoko3
{
    public class Listener : LAPIListener
    {
        private readonly RichTextLabel CommandOutput;
        private readonly RichTextLabel LogOutput;
        private CommandListener _commandListener;
        public Listener(MainPanel panel)
        {
            CommandOutput = panel.CommandOutputBox;
            LogOutput = panel.LogText;
            _commandListener = new CommandListener();

            _commandListener.AddCommand(new Xana());
            _commandListener.AddCommand(new LW());
            _commandListener.AddCommand(new Aelita());

            //Ensure Help command is always the last command to be added to the listener
            List<Command> commands = _commandListener.GetCommands();
            _commandListener.AddCommand(new Help(ref commands));
        }

        
        public override void onCommandOutput(string message)
        {
            ToCommandOut(message);
        }

        public override void onCommandInput(string input)
        {
            _commandListener.OnCommand(input);
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
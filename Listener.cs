using BackEnd;
using Godot;
using LyokoAPI.API;

namespace MiniLyoko3
{
    public class Listener : LAPIListener
    {
        private readonly Label CommandOutput;
        private readonly RichTextLabel LogOutput;
        private CommandListener _commandListener;
        public Listener(MainPanel panel)
        {
            CommandOutput = panel.CommandOutputBox;
            LogOutput = panel.LogText;
            _commandListener = new CommandListener();
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
            LogOutput.Text += text;
        }

        private void ToCommandOut(string text)
        {
            CommandOutput.Text += "\n"+(text);
        }
        
        
    }
}
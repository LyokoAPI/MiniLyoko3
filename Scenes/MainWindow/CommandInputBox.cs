using Godot;
using System;
using System.Collections.Generic;
using LyokoAPI.Events;

public class CommandInputBox : Godot.LineEdit
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    //private string LastCmd = "";
    private List<string> LastCmds = new List<string>();
    private int currentCmd = 0;

    public override void _Ready()
    {

    }


 	public override void _Process(float delta)
  	{
	    if (Input.IsActionPressed("ui_accept"))
	    {
		    if (HasFocus())
		    {
			    _on_Button_pressed();
		    }
        }
        if (Input.IsActionJustPressed("ui_page_up"))
        {
            if (HasFocus())
            {
                _GetLastCommand();
            }
        }
        if (Input.IsActionJustPressed("ui_page_down"))
        {
            if (HasFocus())
            {
                _GetNextCommand();
            }
        }
    }

	private void _on_Button_pressed()
    {
	    if (string.IsNullOrEmpty(Text))
	    {
		    return;
	    }
	    RichTextLabel node = GetParent().GetParent().GetParent().GetNode<RichTextLabel>("CommandPanel/RichTextLabel");
	    node.Text += $">{Text}\n";
        CommandInputEvent.Call(Text);
        LastCmds.Add(Text);
        currentCmd = LastCmds.Count;
        Text="";
    }

    private void _GetLastCommand()
    {
        if (LastCmds.Count > 0)
        {
            currentCmd -= 1;
            if (currentCmd < 0)
                currentCmd = 0;
            string cmd = LastCmds[currentCmd];
            Text = cmd;
            CaretPosition = cmd.Length;
        }
    }

    private void _GetNextCommand()
    {
        if (LastCmds.Count > 0)
        {
            currentCmd += 1;
            if (currentCmd > LastCmds.Count - 1)
                currentCmd = LastCmds.Count - 1;
            string cmd = LastCmds[currentCmd];
            Text = cmd;
            CaretPosition = cmd.Length;
        }
    }
}

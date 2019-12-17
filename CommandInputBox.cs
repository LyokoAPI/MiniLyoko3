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
        if (Input.IsActionJustPressed("ui_up"))
        {
            if (HasFocus())
            {
                _GetLastCommand();
            }
        }
  	}
	  private void _on_Button_pressed()
    {
	    if (Text == "" || Text.Empty())
	    {
		    return;
	    }
	    Label node = GetParent().GetParent().GetParent().GetNode<Label>("CommandPanel/CommandText");
	    node.Text += $"\n>{GetText()}" ;
	    CommandInputEvent.Call(GetText());
        LastCmds.Add(GetText());
        //currentCmd = LastCmds.Count - 1;
        SetText("");
    }

    private void _GetLastCommand()
    {
        if (LastCmds.Count > 0)
        {
            currentCmd -= 1;
            if (currentCmd <0)
                currentCmd = LastCmds.Count - 1;
            string cmd = LastCmds[currentCmd];
            SetText(cmd);
            SetCursorPosition(cmd.Length);
        }
    }
}

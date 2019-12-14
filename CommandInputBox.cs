using Godot;
using System;
using LyokoAPI.Events;

public class CommandInputBox : Godot.LineEdit
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
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
        SetText("");
    }
}

using Godot;
using System;
using LyokoPluginLoader;
using MiniLyoko3;
using Listener = MiniLyoko3.Listener;
using Path = System.IO.Path;

public class MainPanel : Panel
{
    public RichTextLabel LogText { get; set; }
    public RichTextLabel CommandOutputBox { get; set; }

    private MiniLyoko3.Listener _listener;
    private LyokoPluginLoader.PluginLoader _loader;
    
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
        LogText = GetNode<RichTextLabel>("LogPanel/LogText");
        CommandOutputBox = GetNode<RichTextLabel>("VBoxContainer/CommandPanel/RichTextLabel");
        _listener = new MiniLyoko3.Listener(this);
        _listener.StartListening();
        _loader = new PluginLoader(Path.Combine(Godot.OS.GetUserDataDir(),"Plugins"));
        LoaderInfo.DevMode = true;
    }
    
    public override void _Notification(int what)
    {
        if (what == MainLoop.NotificationWmQuitRequest)
        {
            DisableLoader();
        }
            
    }

    public void DisableLoader()
    {
        _listener.StopListening();
        _loader.DisableAll();
    }

    public void ReInit()
    {
        DisableLoader();
        _loader.ReInit();
        _listener.StartListening();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

}

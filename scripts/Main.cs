using Godot;
using System;

public partial class Main : Node2D
{
	public Main()
	{
		var ScreenSize = DisplayServer.ScreenGetSize();
		var WindowSize = DisplayServer.WindowGetSize();

		DisplayServer.WindowSetPosition(ScreenSize / 2 - WindowSize / 2);
	}
}
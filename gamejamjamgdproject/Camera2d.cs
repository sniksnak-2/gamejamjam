using Godot;
using System;

public partial class Camera2d : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// standard poz for camera is (576, 324)
	// building to move it up to (576, -324) with momentum
	bool pressed = false;
	public override void _Process(double delta)
	{
		if (pressed) {
			int vel = -100;


			Vector2 position = Position;
			if (position.Y > -324)
			{
				position.Y = position.Y + (vel * (float)delta);

			}
			// sets postion to -324 (to stop it from going over -324), stops the code from running by setting pressed to false 
			// and setting velocity to 100 so it reverses more apropreately 
			else { position.Y = -324; pressed = false; vel = 100; }
			Position = position;
		}
    }
	public void _on_button_2_pressed() {
			pressed = true;
	} 
}

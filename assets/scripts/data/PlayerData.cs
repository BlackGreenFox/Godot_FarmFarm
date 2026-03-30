using Godot;
using System;

[GlobalClass]
[Tool]
public partial class PlayerData : Resource
{
	// Move State
	[ExportCategory("Move State")]
	[Export] public float MovementVelocity = 50f;
}

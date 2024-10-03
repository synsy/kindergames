using Godot;
using System;

public partial class game_manager : Node
{
	private Sprite2D animalSprite; // Reference to the Animal Sprite2D node
	private int currentSpriteIndex = 0; // Current sprite index
	private Vector2 regionSize = new Vector2(400, 400); // Size of each region (400x400)

	public override void _Ready()
	{
		GD.Print("Game Manager Loaded");
		
		// Access the Animal node by its node path
		animalSprite = GetNode<Sprite2D>("../Animal");

		if (animalSprite != null)
		{
			// Enable region mode on the Animal sprite
			animalSprite.RegionEnabled = true;

			// Set initial sprite region
			SetSpriteRegion(currentSpriteIndex);
		}
		else
		{
			GD.PrintErr("Animal node not found!");
		}
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("left_click")) // Detect left-click
		{
			GD.Print("Clicked!");

			// Update the sprite index and change the region
			currentSpriteIndex = (currentSpriteIndex + 1) % 8; // Assuming 8 sprites in total
			SetSpriteRegion(currentSpriteIndex);
		}
	}

	private void SetSpriteRegion(int index)
	{
		int columns = 2;
		int rows = 4;
		int column = index % columns;
		int row = index / columns;
		
		// Calculate the region position based on row and column
		Vector2 regionPosition = new Vector2(regionSize.X * column, regionSize.Y * row);

		// Set the region of the sprite
		animalSprite.RegionRect = new Rect2(regionPosition, regionSize);
	}
}

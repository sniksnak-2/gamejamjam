using Godot;
using System;
using System.Collections.Generic;

public partial class slotsA : Node2D
{
	public override void _Ready()
	{
		GD.Print("Hello World");
		
	}
    public List<string> SlotsArray()
    {
        List<string> slotsPossible = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9"}; // ths thr ting that hads the options for the slot machine
		RandomNumberGenerator rng = new RandomNumberGenerator();
        List<string> gambaResult1 = new List<string> { };
        List<string> gambaResult2 = new List<string> { };
        List<string> gambaResult3 = new List<string> { };
        List<string> gambaResultTotal = new List<string> { };
        for (int i=0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                int random = rng.RandiRange(0, slotsPossible.Count-1);
                gambaResult1.Add(slotsPossible[random]);
                slotsPossible.RemoveAt(random);
            }
        GD.Print(string.Join("-", gambaResult1), "~", string.Join("-", gambaResult2), "~", string.Join("-", gambaResult3));
        return gambaResultTotal;
    }

    public override void _Process(double delta)
	{
	}
}

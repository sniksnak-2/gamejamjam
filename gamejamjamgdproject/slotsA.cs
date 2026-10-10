using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class slotsA : Node2D
{
	public override void _Ready()
	{
		GD.Print("Hello World");
		
	}
    public void SlotsList(List<string> slots)
    {
        Godot.RandomNumberGenerator rng = new Godot.RandomNumberGenerator();
        List<string> slotOptions = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        List<string> gambaResult = new List<string> {};
        for (int i = 0; i < 9; i++)
		{
			if (i < 3)
			{
				if (slots[i] == "null")
				{
                    int gambagamba = rng.RandiRange(0, slotOptions.Count - 1);
                    gambaResult.Add(slotOptions[gambagamba]);
                    slotOptions.RemoveAt(gambagamba);
                }
                else
                {
                    gambaResult.Add(slots[i]);
                }
            }
			else if (i > 2 && i < 6)
			{
                if (slots[i] == "null" && i == 3)
                {
                    slotOptions = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                    int gambagamba = rng.RandiRange(0, slotOptions.Count - 1);
                    gambaResult.Add(slotOptions[gambagamba]);
                    slotOptions.RemoveAt(gambagamba);
                }
                else if (slots[i] == "null")
                {
                    int gambagamba = rng.RandiRange(0, slotOptions.Count - 1);
                    gambaResult.Add(slotOptions[gambagamba]);
                    slotOptions.RemoveAt(gambagamba);
                }
                else
                {
                    gambaResult.Add(slots[i]);
                }
            }
			else
			{
                if (slots[i] == "null" && i == 6)
                {
                    slotOptions = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                    int gambagamba = rng.RandiRange(0, slotOptions.Count - 1);
                    gambaResult.Add(slotOptions[gambagamba]);
                    slotOptions.RemoveAt(gambagamba);
                }
                else if (slots[i] == "null")
                {
                    int gambagamba = rng.RandiRange(0, slotOptions.Count - 1);
                    gambaResult.Add(slotOptions[gambagamba]);
                    slotOptions.RemoveAt(gambagamba);
                }
                else
                {
                    gambaResult.Add(slots[i]);
                }
            }
        }
		GD.Print(string.Join("-", gambaResult));
    }
	public void CallSlots()
	{
		List<string> slots = new List<string> {"null", "null", "null", "null", "null", "null", "null", "null", "null" };
		SlotsList(slots);
	}

    public override void _Process(double delta)
	{
	}
}

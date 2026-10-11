using Godot;
using System;
using System.Collections.Generic;

public partial class slotsA : Node2D
{
    List<Sprite2D> DeleteSprites = new List<Sprite2D> { };
	public override void _Ready()
	{
		GD.Print("Hello World");
		
	} 
    List<int> JackpotTally = new List<int> {0, 0};
	
    public void DisplaySlots(List<string> FinalSlots)
    {
        List<Vector2> Positions = new List<Vector2> {new Vector2(295, 315), new Vector2(295, 395), new Vector2(295, 475), new Vector2(365, 315), new Vector2(365, 395), new Vector2(365, 475), new Vector2(445, 315), new Vector2(445, 395), new Vector2(445, 475) };
        DeleteSprites.Clear();
        for (int i =0; i<9; i++)
        {
            Sprite2D original = GetNode<Sprite2D>(FinalSlots[i]);
            Sprite2D Slot = (Sprite2D)original.Duplicate();
            Slot.Position = Positions[i];
            AddChild(Slot);
            DeleteSprites.Add(Slot);
        }
    }
    public List<string> SlotsList(List<string> slots)
    {
        Godot.RandomNumberGenerator rng = new Godot.RandomNumberGenerator();
        List<string> slotOptions = new List<string> { "aple", "banaaa", "grpaes", "stawrbr"};
        List<string> slotOptionsConstant = new List<string> { "aple", "banaaa", "grpaes", "stawrbr"};

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
                    slotOptions = new List<string> (slotOptionsConstant);
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
                    slotOptions = new List<string>(slotOptionsConstant);
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
        return gambaResult;
    }
	public List<string> CallSlots()
	{
     
        Godot.RandomNumberGenerator rng = new Godot.RandomNumberGenerator();
        List<string> slots = new List<string> {"null", "null", "null", "null", "null", "null", "null", "null", "null" };
		List<string> slotReturn = SlotsList(slots);
        List<string> slotsColumn1 = slotReturn.GetRange(0, 3);
        List<string> slotsColumn2 = slotReturn.GetRange(3, 3);
        List<string> slotsColumn3 = slotReturn.GetRange(6, 3);
        List<string> FinalSlots = new List<string> { };
        for (int i=0; i<DeleteSprites.Count-1; i++)
        {
            Sprite2D Sprite = DeleteSprites[i];
            Sprite.QueueFree();
        }
        for (int i = 0; i < 9; i++)
        {
            if (i < 3)
            {
                int gambagambagamba = rng.RandiRange(0, slotsColumn1.Count - 1);
                FinalSlots.Add(slotsColumn1[gambagambagamba]);
                slotsColumn1.RemoveAt(gambagambagamba);
            }
            else if (i > 2 && i < 6)
            {
                int gambagambagamba = rng.RandiRange(0, slotsColumn2.Count - 1);
                FinalSlots.Add(slotsColumn2[gambagambagamba]);
                slotsColumn2.RemoveAt(gambagambagamba);
            }
            else
            {
                int gambagambagamba = rng.RandiRange(0, slotsColumn3.Count - 1);
                FinalSlots.Add(slotsColumn3[gambagambagamba]);
                slotsColumn3.RemoveAt(gambagambagamba);
            }
        }
        List<List<int>> Matches = new List<List<int>> { new List<int> { 0, 3, 6}, new List<int> { 1, 4, 7}, new List<int> { 2, 5, 8}, new List<int> { 0, 4, 8}, new List<int> { 2, 4, 6}};
        for (int i =0; i< Matches.Count; i++)
        {
            string currentCheck = FinalSlots[i];
            if (currentCheck == FinalSlots[Matches[i][0]] && currentCheck == FinalSlots[Matches[i][1]] && currentCheck == FinalSlots[Matches[i][2]])
            {
                GD.Print("JACKPOT");
                JackpotTally[1] = JackpotTally[1] + 1;
            }
        }
        DisplaySlots(FinalSlots);
        GD.Print(JackpotTally[0], ":", JackpotTally[1]);
        return FinalSlots;
	}
    public void ButtonHandler()
    {
        CallSlots();
        JackpotTally[0] = JackpotTally[0] + 1;
    }

    public override void _Process(double delta)
	{
	}
}

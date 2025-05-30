using System;

public class SlotMachine1
{
    private readonly Random _random = new Random();

    // Generates a random stop position for each of the 5 reels
    public int[] GenerateStopPositions()
    {
        int[] stops = new int[ReelSet.Reels.Length];

        for (int i = 0; i < stops.Length; i++)
        {
            stops[i] = _random.Next(ReelSet.Reels[i].Count);
        }

        return stops;
    }

    // Returns a 3-row by 5-column screen from the given stop positions
    public string[,] GetScreen(int[] stopPositions)
    {
        string[,] screen = new string[3, 5];

        for (int col = 0; col < 5; col++)
        {
            var reel = ReelSet.Reels[col];
            int stop = stopPositions[col];

            for (int row = 0; row < 3; row++)
            {
                // Circular indexing of reel symbols
                int index = (stop + row) % reel.Count;
                screen[row, col] = reel[index];
            }
        }

        return screen;
    }

    // Displays the stop positions and screen in a nicely formatted way
    public void PrintScreen(int[] stopPositions, string[,] screen)
    {
        Console.WriteLine("Stop Positions: " + string.Join(", ", stopPositions));
        Console.WriteLine("Screen:");

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                Console.Write(screen[row, col].PadRight(6));
            }
            Console.WriteLine();
        }
    }
}

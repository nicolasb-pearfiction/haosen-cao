using System;

class Program
{
    static void Main(string[] args)
    {
        var machine = new SlotMachine1();

        // Generate random stop positions for each reel
        int[] stopPositions = machine.GenerateStopPositions();

        // Get the visible 3x5 screen based on stop positions
        string[,] screen = machine.GetScreen(stopPositions);

        // Print stop positions and screen
        machine.PrintScreen(stopPositions, screen);

        // Evaluate winnings from screen
        var evaluator = new WaysEvaluator();
        var results = evaluator.Evaluate(screen);

        // Print the result summary and detailed win lines
        evaluator.PrintResults(results);
    }
}

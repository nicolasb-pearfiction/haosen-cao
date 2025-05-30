using System;
using System.Collections.Generic;

public class WaysEvaluator
{
    // Class to store details about a single win
    public class WinResult
    {
        public List<int> Positions = new();
        public required string Symbol;
        public int MatchCount;
        public int Payout;
    }

    // Evaluates the screen and returns a list of winning results
    public List<WinResult> Evaluate(string[,] screen)
    {
        List<WinResult> results = new();

        // Check each row starting from column 0
        for (int row = 0; row < 3; row++)
        {
            string symbol = screen[row, 0];
            List<int> positions = new() { row * 5 + 0 };

            // Scan left to right for matching symbols in consecutive columns
            for (int col = 1; col < 5; col++)
            {
                bool matchFound = false;

                for (int r = 0; r < 3; r++)
                {
                    if (screen[r, col] == symbol)
                    {
                        positions.Add(r * 5 + col);
                        matchFound = true;
                        break;
                    }
                }

                // Stop checking further if no match found in current column
                if (!matchFound) break;
            }

            int count = positions.Count;

            // Valid "ways" win requires at least 3 matching columns
            if (count >= 3 && PayTable.Payouts.TryGetValue(symbol, out var pays))
            {
                results.Add(new WinResult
                {
                    Positions = new List<int>(positions),
                    Symbol = symbol,
                    MatchCount = count,
                    Payout = pays[count - 3]
                });
            }
        }

        return results;
    }

    // Prints total wins and each individual win detail
    public void PrintResults(List<WinResult> results)
    {
        int total = 0;

        foreach (var result in results)
        {
            total += result.Payout;
        }

        Console.WriteLine("Total wins: " + total);

        foreach (var result in results)
        {
            Console.WriteLine($"- Ways win {string.Join("-", result.Positions)}, {result.Symbol} x{result.MatchCount}, {result.Payout}");
        }
    }
}

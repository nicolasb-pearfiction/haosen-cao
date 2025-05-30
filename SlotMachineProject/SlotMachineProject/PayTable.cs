using System.Collections.Generic;

// Static class defining payouts for each symbol based on match count
public static class PayTable
{
    // Dictionary with payouts for 3, 4, and 5 of a kind
    public static readonly Dictionary<string, int[]> Payouts = new Dictionary<string, int[]>
    {
        { "sym1", new int[] { 1, 2, 3 } },
        { "sym2", new int[] { 1, 2, 3 } },
        { "sym3", new int[] { 1, 2, 5 } },
        { "sym4", new int[] { 2, 5, 10 } },
        { "sym5", new int[] { 5, 10, 15 } },
        { "sym6", new int[] { 5, 10, 15 } },
        { "sym7", new int[] { 5, 10, 20 } },
        { "sym8", new int[] { 10, 20, 50 } },
    };
}

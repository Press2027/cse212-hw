using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    // --------------------------------------------------
    // Problem 1: Recursive Squares Sum
    // --------------------------------------------------
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // --------------------------------------------------
    // Problem 2: Permutations Choose
    // --------------------------------------------------
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    // --------------------------------------------------
    // Problem 3: Climbing Stairs (Memoized)
    // --------------------------------------------------
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal result;

        if (s == 0)
            result = 1;
        else if (s < 0)
            result = 0;
        else
            result =
                CountWaysToClimb(s - 1, remember) +
                CountWaysToClimb(s - 2, remember) +
                CountWaysToClimb(s - 3, remember);

        remember[s] = result;
        return result;
    }

    // --------------------------------------------------
    // Problem 4: Wildcard Binary Patterns
    // --------------------------------------------------
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(
            pattern[..index] + "0" + pattern[(index + 1)..],
            results);

        WildcardBinary(
            pattern[..index] + "1" + pattern[(index + 1)..],
            results);
    }

    // --------------------------------------------------
    // Problem 5: Maze Solver
    // --------------------------------------------------
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        currPath.RemoveAt(currPath.Count - 1);
    }
}

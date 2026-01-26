using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find symmetric word pairs using a set (O(n))
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            // Skip same-character words like "aa"
            if (word[0] == word[1])
                continue;

            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Summarize degrees from census file
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Determine if two words are anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var counts = new Dictionary<char, int>();

        foreach (char c in word1.ToLower())
        {
            if (c == ' ') continue;
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }

        foreach (char c in word2.ToLower())
        {
            if (c == ' ') continue;
            if (!counts.ContainsKey(c)) return false;

            counts[c]--;
            if (counts[c] == 0)
                counts.Remove(c);
        }

        return counts.Count == 0;
    }


    /// <summary>
    /// Problem 5: Earthquake daily summary (JSON)
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        using var doc = JsonDocument.Parse(json);
        var features = doc.RootElement.GetProperty("features");

        var results = new List<string>();

        foreach (var feature in features.EnumerateArray())
        {
            var props = feature.GetProperty("properties");
            string place = props.GetProperty("place").GetString();
            double mag = props.GetProperty("mag").GetDouble();

            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}

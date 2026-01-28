using Microsoft.VisualBasic.FileIO;

namespace week03.teach; 

public static class Basketball {
    public static void Run() {
        // Create a dictionary to store Player IDs as Keys and their Total Points as Values
        // Dictionary provides O(1) average lookup time.
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip the header row

        while (!reader.EndOfData) {
            var fields = reader.ReadFields();
            if (fields == null) continue;

            string playerId = fields[0];
            int points = int.Parse(fields[8]);

            // PERFORMANCE CRITICAL: Using a dictionary to aggregate data in O(n) total time
            // Check if the player is already in our map
            if (players.ContainsKey(playerId)) {
                // If found, update their cumulative points
                players[playerId] += points;
            }
            else {
                // If it's the first time seeing this ID, initialize their score
                players[playerId] = points;
            }
        }

        // Convert dictionary to array and sort by value (points) in descending order
        var topPlayers = players.ToArray();
        Array.Sort(topPlayers, (p1, p2) => p2.Value.CompareTo(p1.Value));

        Console.WriteLine("\nTop 10 Players by Total Points:");
        for (var i = 0; i < 10 && i < topPlayers.Length; i++) {
            Console.WriteLine($"{i + 1}. {topPlayers[i].Key}: {topPlayers[i].Value} points");
        }
    }
}
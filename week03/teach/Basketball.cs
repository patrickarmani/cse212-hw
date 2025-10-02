/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            if (players.ContainsKey(playerId))
                players[playerId] += points;
            else
                players[playerId] = points;
        }

        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
        var top10 = players.OrderByDescending(kv => kv.Value).Take(10).ToList();

        Console.WriteLine("Top 10 - Career Points");
        Console.WriteLine("----------------------");
        int rank = 1;
        foreach (var (playerId, totalPoints) in top10)
        {
            Console.WriteLine($"{rank,2}. {playerId,-15} {totalPoints}");
            rank++;
        }

        var topPlayers = new string[10];
        for (int i = 0; i < top10.Count; i++)
            topPlayers[i] = top10[i].Key;

    }
}
using System;

public class DisplayPlayerNames
{
    delegate int ScoreDelegate(PlayerStats stats);

    void OnGameOver(PlayerStats[] allPlayerStats)
    {
        string playerNameMostKills = GetPlayerNameTopScore(allPlayerStats, ScoreByKills);
        string playerNameMostFlags = GetPlayerNameTopScore(allPlayerStats, ScoreByFlags);
        //string playerNameMostKills = GetPlayerNameTopScore(allPlayerStats, stat => stat.kills);
        //string playerNameMostFlags = GetPlayerNameTopScore(allPlayerStats, stat => stat.flags);

    }

    int ScoreByKills(PlayerStats stats)
    {
        return stats.kills;
    }

    int ScoreByFlags(PlayerStats stats)
    {
        return stats.flags;
    }

    string GetPlayerNameTopScore(PlayerStats[] allPlayerStats, ScoreDelegate scoreCalculator)
    {
        string name = "";
        int bestScore = 0;

        foreach (PlayerStats stats in allPlayerStats)
        {
            int score = scoreCalculator(stats);
            if (score > bestScore)
            {
                bestScore = score;
                name = stats.name;
            }
        }

        return name;
    }

    
}

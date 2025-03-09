using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class Leaderboard
{
    public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
}
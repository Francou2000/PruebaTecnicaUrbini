using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderboardUI : MonoBehaviour
{
    public Text leaderboardText;
    private LeaderboardManager leaderboardManager;

    void Start()
    {
        leaderboardManager = FindFirstObjectByType<LeaderboardManager>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        List<LeaderboardEntry> entries = leaderboardManager.GetLeaderboard();
        leaderboardText.text = "Leaderboard:\n";

        foreach (var entry in entries)
        {
            leaderboardText.text += $"{entry.playerName}: {entry.score}\n";
        }
    }
}

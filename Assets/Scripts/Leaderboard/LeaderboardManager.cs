using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    private string savePath;
    private Leaderboard leaderboard;

    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadLeaderboard();
    }

    public void AddScore(string playerName, int score)
    {
        LeaderboardEntry newEntry = new LeaderboardEntry { playerName = playerName, score = score };
        leaderboard.entries.Add(newEntry);

        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));
        SaveLeaderboard();
    }

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard);
        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error saving leaderboard: " + ex.Message);
        }
    }

    private void LoadLeaderboard()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                leaderboard = JsonUtility.FromJson<Leaderboard>(json);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error loading leaderboard: " + ex.Message);
                leaderboard = new Leaderboard();
            }
        }
        else
        {
            leaderboard = new Leaderboard();
        }
    }

    public List<LeaderboardEntry> GetLeaderboard()
    {
        return leaderboard.entries;
    }
}
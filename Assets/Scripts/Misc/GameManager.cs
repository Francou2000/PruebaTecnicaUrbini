using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        savePath = System.IO.Path.Combine(Application.persistentDataPath, "leaderboard.json");
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        SaveScore();
        SceneManager.LoadScene("GameOverScene");
    }

    void SaveScore()
    {
        Leaderboard leaderboard = LoadLeaderboard();
        // Using "Anonymous" here for convinience
        leaderboard.entries.Add(new LeaderboardEntry { playerName = "Anonymous", score = score });
        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));

        if (leaderboard.entries.Count > 3)
            leaderboard.entries.RemoveRange(3, leaderboard.entries.Count - 3);

        string json = JsonUtility.ToJson(leaderboard);
        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error saving score: " + ex.Message);
        }
    }

    public Leaderboard LoadLeaderboard()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                return JsonUtility.FromJson<Leaderboard>(json);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error loading leaderboard: " + ex.Message);
                return new Leaderboard();
            }
        }
        return new Leaderboard();
    }
}


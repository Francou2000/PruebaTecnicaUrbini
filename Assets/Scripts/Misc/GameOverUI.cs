using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI leaderboardText;

    void Start()
    {
        finalScoreText.text = "Final Score: " + GameManager.Instance.GetScore();
        UpdateLeaderboard();
    }

    void UpdateLeaderboard()
    {
        Leaderboard leaderboard = GameManager.Instance.LoadLeaderboard();
        leaderboardText.text = "Top Scores:\n";
        for (int i = 0; i < leaderboard.entries.Count; i++)
        {
            leaderboardText.text += $"{i + 1}. {leaderboard.entries[i].score}\n";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

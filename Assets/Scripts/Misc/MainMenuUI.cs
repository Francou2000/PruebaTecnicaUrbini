using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

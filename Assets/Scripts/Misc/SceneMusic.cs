using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(menuMusic);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0 || level == 2)
        {
            AudioManager.Instance.PlayMusic(menuMusic);
        }
        else if (level == 1)
        {
            AudioManager.Instance.PlayMusic(gameplayMusic);
        }
    }
}

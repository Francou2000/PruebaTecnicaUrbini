using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public static LevelUpManager Instance;

    [Header("Level Up Settings")]
    public int orbThreshold = 5;      
    private int orbCount = 0;

    [Header("Level Up UI")]
    public GameObject levelUpMenuUI;  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectOrb()
    {
        orbCount++;
        if (orbCount >= orbThreshold)
        {
            TriggerLevelUp();
        }
    }

    private void TriggerLevelUp()
    {
        Time.timeScale = 0f; 
        levelUpMenuUI.SetActive(true);
    }

    public void ApplyLevelUp(bool increaseFireRate)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            AutoFire autoFire = player.GetComponent<AutoFire>();
            if (autoFire != null)
            {
                if (increaseFireRate)
                {
                    autoFire.fireRate = Mathf.Max(0.1f, autoFire.fireRate - 0.1f);
                }
                else
                {
                    autoFire.bulletDamage += 5;
                }
            }
        }

        orbCount = 0;
        orbThreshold += 5; 
        levelUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}

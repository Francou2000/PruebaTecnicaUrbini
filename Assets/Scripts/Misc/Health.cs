using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject levelUpOrbPrefab;

    public GameObject explosionPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.enemyHitSound);
        }
        else if (CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.playerHitSound);
        }
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if (CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(10);

            if (levelUpOrbPrefab)
                Instantiate(levelUpOrbPrefab, transform.position, Quaternion.identity);
        }
        else if (CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }
}

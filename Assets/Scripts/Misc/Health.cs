using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject levelUpOrbPrefab; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
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

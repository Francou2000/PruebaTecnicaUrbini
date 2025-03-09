using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Base Stats")]
    public int baseHealth = 100;
    public float baseSpeed = 3f;
    public float baseFireRate = 1.5f; 

    private Health enemyHealth;
    private EnemyAI enemyAI;
    private EnemyShooting enemyShooting;

    void Awake()
    {
        enemyHealth = GetComponent<Health>();
        enemyAI = GetComponent<EnemyAI>();
        enemyShooting = GetComponent<EnemyShooting>();
    }

    public void ApplyDifficulty(float multiplier)
    {
        if (enemyHealth != null)
        {
            enemyHealth.maxHealth = Mathf.RoundToInt(baseHealth * multiplier);
            enemyHealth.ResetHealth();
        }

        if (enemyAI != null)
        {
            enemyAI.speed = baseSpeed * multiplier;
        }

        if (enemyShooting != null)
        {
            enemyShooting.fireRate = Mathf.Max(0.1f, baseFireRate / multiplier);
        }
    }
}


using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float spawnRadius = 10f;
    public float initialSpawnRate = 2f;
    public float difficultyIncreaseRate = 10f; 
    public float spawnRateDecrease = 0.1f; 
    public int maxDifficultyLevel = 5;

    private float spawnRate;
    private int difficultyLevel = 0;
    
    void Start()
    {
        spawnRate = initialSpawnRate;
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
        InvokeRepeating(nameof(IncreaseDifficulty), difficultyIncreaseRate, difficultyIncreaseRate);
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || player == null) return;

        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition3D = new Vector3(spawnPosition.x, spawnPosition.y, 0);

        int enemyIndex = Mathf.Clamp(difficultyLevel, 0, enemyPrefabs.Length - 1);
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyIndex + 1)];

        Instantiate(enemyPrefab, spawnPosition3D, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        if (difficultyLevel < maxDifficultyLevel)
        {
            difficultyLevel++;
            if (spawnRate > 0.5f) 
            {
                spawnRate -= spawnRateDecrease;
                CancelInvoke(nameof(SpawnEnemy));
                InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
            }
        }
    }
}


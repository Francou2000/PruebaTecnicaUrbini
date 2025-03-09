using UnityEngine;

public class LevelUpOrb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelUpManager.Instance.CollectOrb();
            Destroy(gameObject);
        }
    }
}

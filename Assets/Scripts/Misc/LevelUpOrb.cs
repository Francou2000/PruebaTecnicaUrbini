using UnityEngine;

public class LevelUpOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelUpManager.Instance.CollectOrb();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.pickUpSound);
            Destroy(gameObject);
        }
    }
}

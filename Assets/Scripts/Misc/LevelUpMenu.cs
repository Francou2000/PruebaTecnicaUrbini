using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public void OnIncreaseFireRate()
    {
        LevelUpManager.Instance.ApplyLevelUp(true);
    }

    public void OnIncreaseDamage()
    {
        LevelUpManager.Instance.ApplyLevelUp(false);
    }
}

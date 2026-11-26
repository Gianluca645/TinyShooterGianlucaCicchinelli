using UnityEngine;

public class BonusPresent : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BonusScoreManager bonusManager = FindAnyObjectByType<BonusScoreManager>();
            if (bonusManager) bonusManager.AddBonusPresent();
            Destroy(this.gameObject);
        }
    }
}
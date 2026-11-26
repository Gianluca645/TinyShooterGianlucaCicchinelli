using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelController levelController = FindAnyObjectByType<LevelController>();
            if (levelController) levelController.TriggerReloadLevel();
            
        }
    }
}
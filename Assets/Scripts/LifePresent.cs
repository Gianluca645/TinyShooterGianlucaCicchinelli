using UnityEngine;

public class LifePresent : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth) playerHealth.AddLife();
            Destroy(this.gameObject);
        }
    }
}
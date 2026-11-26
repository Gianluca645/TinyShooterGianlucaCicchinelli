using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [SerializeField] FallingPlatform target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(target) target.Activate();
        }



    }
}

using UnityEngine;

public class CanvasRotationController : MonoBehaviour
{
    void Update()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}

using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] [Range(-5f,10f)] float speed;
    [SerializeField] Vector3 directionVector;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Este sería el código entero pero yo solo quiero que se mueve en el eje x así que pongo '0' donde no quiero que se mueva. 
        // transform.Translate(directionVector.x * speed * Time.deltaTime, directionVector.y * speed * Time.deltaTime, directionVector.z * speed * Time.deltaTime);
        transform.Translate(directionVector.x * speed * Time.deltaTime,0,0);


    }
}

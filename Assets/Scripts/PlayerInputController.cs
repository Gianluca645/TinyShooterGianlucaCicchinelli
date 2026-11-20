using UnityEngine;
using UnityEngine.InputSystem;

// COMO NO QUIERO QUE SE MUEVA EL FLAPPY, COMENTARÉ EL MOVE Y DEJARÉ EL JUMP!!! ///



public class PlayerInputController : MonoBehaviour
{
    /*[SerializeField] [Range(0f,5f)] float speed; // Pongo SerializeField para que me aparezca ahi a la derecha las cosas que van cambiando. Puedo poner Public y tmb aparecerá
    [SerializeField] Vector2 move;
    [SerializeField] float directionX;
    [SerializeField] float directionZ;*/

    [SerializeField] bool jump;
    [SerializeField] float ThrustForce = 25000;
    Rigidbody rb;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        
        // Obtengo el Rigidbody que tiene mi player1
    }

    // Update is called once per frame
    void Update()
    {

        if (jump)
        {
            Jump();
        }

        // Move();
    }

    /* private void Move()
    {
        directionX = move.x;
        directionZ = move.y;

        // W y S dan los valores 1 y -1 por lo que se mueven en ambas direcciones verticales (Y)

        // A y D dan valores 1 y -1 por lo que se mueven en ambas direcciones horizontales (X)


        transform.Translate(directionX * speed * Time.deltaTime, 0, directionZ * Time.deltaTime * speed);
    }*/

    private void Jump()
    {
        Debug.Log("Jumping!");
        rb.AddRelativeForce(Vector3.up * ThrustForce * Time.fixedDeltaTime); 

        jump = false;
        
        // Esta es la manera más fácil de simular un salto, dando un empujón hacía arriba

        // Aunque hace basicamente lo mismo que el delta time, nos conviene usar
        // el fixed DeltaTime SIEMPRE cuando vamos a estar jugando con física como es saltar y la gravedad y eso porque el programa hace unos procedimientos
        // distintos pero mejores para los casos con física

        
    }

    /*public void OnMove(InputValue value)
    {

        // La acción definida en InputSystem_Actions para el movimiento se llama Move. El mensaje que envia Unity cada vez que se active una accion, llega a un método llamado OnMove(InputValue value)


        move =  value.Get<Vector2>(); 
        
        // El valor de las teclas (bindings) es del tipo Vector2 (Vector2D en el InputSystem_Actions)
    }*/

    public void OnJump(InputValue value)
    {
        jump = value.isPressed; 

        // Para detectar si se ha pulsado el boton del espacio
    }
}

using UnityEngine;

// Este es el script que DETECTA cuando el jugador se ha chocado con algo (en este caso el Pipe)
// (Lo detecta y llama al PlayerCollisionManager para saber QUÉ hacer ya que se ha chocado)

public class PipeCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        
    }*/


    // NO NECESITAMOS VOID START NI VOID UPDATE, SOLO EL COLLISION ENTER, TRIGGER ENTER //
    


    private void OnCollisionEnter(Collision other){
        // Cuando haya colision, unity activa este método
        // Procurar que el IsTrigger esté desactivado para que haya colisión, si está activado lo atraviesaría

        if (other.gameObject.tag == "Player")
        {
            PlayerCollisionManager playerCollisionManager = other.gameObject.GetComponent<PlayerCollisionManager>();
            if (playerCollisionManager) playerCollisionManager.ProcessHit();

            // si ve que hubo colisión con el objeto tagged con Player, creo un playercollisionManager que tiene las funciones de mi 
            // archivo de PlayerCollisionManager y llamo a la funcion deseada que es reinciar el nivel
            
            // El get lo que hace es como que trae ese script aquí
        }
    }


    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}

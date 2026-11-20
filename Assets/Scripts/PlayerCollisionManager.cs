using UnityEngine;

// Este script es lo que sucede CUANDO el jugador choca con algo
// (mientras que el PipeCollision es el script que DETECTA la collision, y llama a esta)

public class PlayerCollisionManager : MonoBehaviour
{

    // NO HACE FALTA EL VOID START Y VOID UPDATE AQUÍ PORQUE NO ESTOY ACTUALIZANDO ALGO CADA FRAME


    internal void ProcessHit()
    {

        // GetComponent<> nos permite traer cualquier componente a aquí.

        GetComponent<Mover>().enabled = false; 

        // Apago la función Mover para que deje de mover Mr.Flappy

        GetComponent<PlayerInputController>().enabled = false;

        // Apago la función que me permite saltar
        
        ScoreBoardManager scoreBoardManager = FindAnyObjectByType<ScoreBoardManager>();
        if(scoreBoardManager) scoreBoardManager.ResetToCheckPoint();

        // Llamo a mi script de ScoreBoardManager y a mi funcion de reiniciar los puntos que tenia en el nivel anterior





        LevelController levelController = FindAnyObjectByType<LevelController>();
        if (levelController) levelController.TriggerReloadLevel(); 

        // El if(levelController) es un "SanityCheck". (Es como poner if(levelController != null){} pero más sencillo)


        // Si entra en este void, escanea toda la escena hasta encontrar el levelcontroller. (Hasta encontrar cualquier cosa que tiene el levelcontroller)
        // una vez encontrado, llama a la funcion encargada de recargar el nivel


    }


}

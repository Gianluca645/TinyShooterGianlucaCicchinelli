using UnityEngine;


// Muy parecido al GoldPicker


public class GateCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Player")
        {

            ScoreBoardManager scoreBoardManager = FindAnyObjectByType<ScoreBoardManager>();
            if(scoreBoardManager) scoreBoardManager.SaveCheckPoint();

            // Esto guarda los puntos que tenía el jugador en el anterior nivel cuando pasa por la puerta
            



            LevelController levelController = FindAnyObjectByType<LevelController>();
            if (levelController) levelController.LoadNextLevel();
            
            // Cargo mi siguiente nivel (escena)
        
        }





    }
}

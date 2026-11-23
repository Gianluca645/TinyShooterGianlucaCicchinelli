using UnityEngine;


// Muy parecido al PresentPicker


public class GateCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Player")
        {

            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            if(scoreManager && scoreManager.HasAllPresents())
            {
                LevelController levelController = FindAnyObjectByType<LevelController>();
                if (levelController) levelController.LoadNextLevel();
            
                // Cargo mi siguiente nivel (escena)
            }
            else
            {
                Debug.Log("TE FALTAN REGALOS PARA ACTIVAR EL PORTAL");
            }
        
        }





    }
}

using UnityEngine;

public class GoldPicker : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Player")
        {
            ScoreBoardManager bonusBoardManager = FindAnyObjectByType<ScoreBoardManager>();
            if(bonusBoardManager) bonusBoardManager.IncreaseBonus(1);
            Destroy(this.gameObject);

            // Esto sigue la misma lógica que en el ProcessHit del PlayerCollisionManager
            // Pero ahora eliminamos el objeto que contiene este script. Así no puntua dos veces por ejemplo.

        }





    }
}

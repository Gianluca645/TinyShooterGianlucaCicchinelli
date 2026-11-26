using UnityEngine;


public class WinnerPortal : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag=="Player")
        {

            BonusScoreManager bonusscoreManager = FindAnyObjectByType<BonusScoreManager>();
            if(bonusscoreManager && bonusscoreManager.HasAllYellowPresents())
            {
                LevelController levelController = FindAnyObjectByType<LevelController>();
                if (levelController) levelController.LoadNextLevel();
            
                // Cargo mi siguiente nivel (escena)
            }
            else
            {
                Debug.Log("YOURE MISSING GIFTS OR YOU NEED TO DEFEAT THE FINAL BOSS");
            }
        
        }





    }
}

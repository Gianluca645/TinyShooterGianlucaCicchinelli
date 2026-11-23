using UnityEngine;

public class PresentPicker : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Player")
        {
            ScoreManager presentManager = FindAnyObjectByType<ScoreManager>();
            if(presentManager) presentManager.AddPresent();
            Destroy(this.gameObject);


        }





    }
}

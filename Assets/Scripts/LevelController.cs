using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelController : MonoBehaviour
{

    private bool isReload;
    private float reloadLapseTime; // Esto espera 1 segundo antes de reiniciar



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isReload = false;
        reloadLapseTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isReload)
        {
            isReload = false;
            Invoke("ReloadLevel", reloadLapseTime);
        }


    }

    public void TriggerReloadLevel()
    {
        isReload = true;
    }

    public void LoadNextLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((CurrentScene + 1)% SceneManager.sceneCountInBuildSettings);

        // Esto empeiza como el Reload level pero despues de tener el índice, guardamos su valor en un entero
        // buildIndex y cargamos la siguiente escena con el CurrentScene + 1.
        // Usamos el módulo % para no pasarnos de número de escenas. 
        // SceneCountInBuildSettings es el número de escenas que Unity tiene en la configuración de Build del proyecto



    }


    void ReloadLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        
        // Si quiero que siempre empiece desde el inicio, reinicio con el indice 0
        if (CurrentScene == 0){
            ScoreBoardManager scoreBoardManager = FindAnyObjectByType<ScoreBoardManager>();
            if(scoreBoardManager) scoreBoardManager.ResetToZero();
        }

        SceneManager.LoadScene(CurrentScene);

        // Esto pide al SceneManager el índice de la escene activa (actual) y vuelve a cargar esa misma escena.

    }



}

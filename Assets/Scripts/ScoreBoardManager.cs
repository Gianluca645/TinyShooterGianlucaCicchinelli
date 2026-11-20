using UnityEngine;
using TMPro;

public class ScoreBoardManager : MonoBehaviour
{
    public static int score = 0;
    public static int bonus = 0;
    public static int savedScore = 0;
    public static int savedBonus = 0;

    // He buscado que para poder mantener la puntuación del primer nivel,
    // necesito crear las variables como static y luego llamar a mi funcion UpdateUI(); para que 
    // actualice los textos con los puntos que el jugador tenía anteriormente


    [SerializeField] TMP_Text scoreBoardText; // Para verlo y asignarlo desde el editor
    [SerializeField] TMP_Text bonusBoardText;
    


    void Start()
    {
        UpdateUI();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateUI();
        

        // Esto suma la cantidad recibida a la variable score

    }

    public void IncreaseBonus(int amount)
    {
        bonus += amount;
        UpdateUI();

        // Esto suma la cantidad recibida a la variable bonus
    

    }

    private void UpdateUI()
    {
        if(scoreBoardText) scoreBoardText.text = score.ToString("000");
        if(bonusBoardText) bonusBoardText.text = bonus.ToString();


        // convierte el entero en una cadena que podemos asignar a scoreBoardText.text
        // Quiero las 3 cifras asi que puse el "000" y así va sumando de derecha a izquierda



    }

    

    // Voy a crear una función que reinicie el valor del score y el bonus cuando muero. 
    // Asi se mantiene cuando voy al nivel 2 pero se reinicia si muero. 
    // Voy a hacer uso de mi PlayerCollisionManager y el ProcessHit()

    public void SaveCheckPoint()
    {
        savedScore = score;
        savedBonus = bonus;

        // Guardo en mis dos variables estáticas, el valor de los puntos y los bonus del jugador

    }

    public void ResetToCheckPoint()
    {
        score = savedScore;
        bonus = savedBonus;

        // Le asigno a score y bonus el valor guardado del checkpoint 
        // (El valor que tenía el jugador al pasar por la puerta)
        
    }
    
    public void ResetToZero()
    {
        score = 0;
        bonus = 0;
    }


}

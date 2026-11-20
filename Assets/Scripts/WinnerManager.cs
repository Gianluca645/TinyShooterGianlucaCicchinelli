using UnityEngine;
using TMPro;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] TMP_Text finalScoreMessage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int PipePoints = ScoreBoardManager.score;
        int BonusPoints = ScoreBoardManager.bonus;

        // Cojo los puntos finales y calculo la puntuación final

        int total = PipePoints + (10 * BonusPoints);

        // Lo escribo en la pantalla del juego


        finalScoreMessage.text = PipePoints + " + Bonus x10: " + (10*BonusPoints) + " = " + total;


    }

    
}

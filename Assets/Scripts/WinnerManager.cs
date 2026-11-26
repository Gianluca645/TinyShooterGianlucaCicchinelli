using UnityEngine;
using TMPro;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] TMP_Text finalScoreMessage;

    void Start()
    {
        int level1and2 = 21;

        // Leo directamente de la clase
        int presentsLevel2 = BonusScoreManager.bonusPresentsCollected;

        
        int extraPresents = presentsLevel2 - 5;
        if (extraPresents < 0)
        {
            extraPresents = 0;
        }

        // Calculo el bonus y el total
        int bonusScore = 25 * extraPresents;
        int total = (level1and2 * 10) + bonusScore;

    
        if (finalScoreMessage)
        {
            finalScoreMessage.text = level1and2 + " * 10 + Bonus x25: " + bonusScore + " = " + total;
        }
    }
}
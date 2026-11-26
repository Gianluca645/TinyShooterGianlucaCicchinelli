using UnityEngine;
using TMPro;

public class BonusScoreManager : MonoBehaviour
{
    
    

    [SerializeField] TMP_Text bonusPresentsText;
    public static int bonusPresentsCollected = 0;

    int totalYellowPresents = 5;
    bool bossDefeated = false;


    void Start()
    {
        // Partimos de esto cuando empezamos / reinciamos el nivel 2
        bonusPresentsCollected = 0;
        bossDefeated = false;
        UpdateUI();
    }

    public void AddBonusPresent()
    {
        bonusPresentsCollected++;
        UpdateUI();
    }

    void UpdateUI()
    {   
        if (bonusPresentsText) bonusPresentsText.text = bonusPresentsCollected.ToString("0");
        
    }

    public void BossDefeated()
    {
        bossDefeated = true;
    }

    public bool HasAllYellowPresents()
    {
        if ((bonusPresentsCollected >= totalYellowPresents) && (bossDefeated == true))
        {
            return true;
        }
        else
        {
            return false;   
        }
    }
}

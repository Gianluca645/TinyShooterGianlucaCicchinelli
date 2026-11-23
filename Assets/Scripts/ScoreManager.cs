using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
 [SerializeField] TMP_Text _pointsText; 
    private int _totalPresents = 16;
    private int _collectedPresents = 0;
    


    void Start()
    {
        UpdateUI();
    }

    public void AddPresent()
    {
        _collectedPresents++;
        UpdateUI();


    }
   
    public bool HasAllPresents()
    {
        if (_collectedPresents == _totalPresents)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }
    

    private void UpdateUI()
    {
        if (_pointsText)
        {
            _pointsText.text = _collectedPresents.ToString("00");
        }


    }
}

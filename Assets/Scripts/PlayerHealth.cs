using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Image[] _livesBar;
    [Range (0,5)]
    public int _lives = 5;


    void Start()
    {
        UpdateLivesBar();
    }


    void UpdateLivesBar()
    {
        for (int i = 0; i<_livesBar.Length; i++)
        {
            if (i<_lives) _livesBar[i].gameObject.SetActive(true);
            else _livesBar[i].gameObject.SetActive(false);
        }
    }


    public void TakeDamage()
    {
        if (_lives > 0)
        {
            _lives--;
            UpdateLivesBar();

            if (_lives <= 0)
            {
                FindAnyObjectByType<LevelController>().TriggerReloadLevel();
            }
        }
    }

    public void AddLife()
    {
        if (_lives < _livesBar.Length)
        {
            _lives++;
            UpdateLivesBar();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullets") || other.CompareTag("Enemy"))
        {
            _lives--;
            UpdateLivesBar();


            if (_lives <= 0)
            {
                LevelController levelcontroller = FindAnyObjectByType<LevelController>();
                if(levelcontroller) levelcontroller.TriggerReloadLevel();
            }


        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Sledge"))
        {
            TakeDamage();
        }
    }







}

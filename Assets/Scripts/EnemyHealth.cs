using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] BarController _healthBar;
    [SerializeField] float _maxHealth = 3f; // Con tres balas muere el muñeco
    private float _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
        if (_healthBar)
        {
            _healthBar._maxValue = _maxHealth;
            _healthBar.UpdateBar(_currentHealth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnowBallBullets"))
        {
            _currentHealth--; // Si hubo choque con las balas, reducimos la vida en 1
            if (_healthBar) _healthBar.UpdateBar(_currentHealth);

            if (_currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
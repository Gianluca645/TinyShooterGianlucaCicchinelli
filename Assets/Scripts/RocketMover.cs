using UnityEngine;

public class RocketMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] [Range(5f, 25f)] float _speed;
    public float _lifeTime = 3f;
    public bool isEnemyBullet = false;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody.linearVelocity = transform.forward * _speed;
        Destroy(this.gameObject, _lifeTime); // Para que se rompa después de 3 segundos

    }

    void OnTriggerEnter(Collider other)
    {
        if (isEnemyBullet && other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        else if (!isEnemyBullet && other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        else if (!other.CompareTag("Player") && !other.CompareTag("Enemy") && !other.isTrigger)
        {
            Destroy(this.gameObject);
        }


        // Esto es pare destruir la bola de nieve si lo lanza el enemigo y le da
        // al jugador, si lo lanza el jugador y le da al Enemigo 
        // O si ha chocado con cualquier cosa objeto

    }

}

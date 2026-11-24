using System.Collections; 
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigator : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;
    private PlayerInputController _player;

    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private Transform _rocketSpawnPoint;
    [SerializeField] GameObject _enemyExplosion;
    [SerializeField] private float _fireRate = 2f; // Disparar cada 2 segundos

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindAnyObjectByType<PlayerInputController>();
        if (_player) _navMeshAgent.SetDestination(_player.transform.position);
        StartCoroutine(FireRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
            // Uso la Y del propio enemigo para que el muñeco de nieve no se incline hacia arriba/abajo al mirarte
            this.transform.LookAt(new Vector3(_player.transform.position.x, this.transform.position.y, _player.transform.position.z));
        }
    }

    IEnumerator FireRoutine()
    {
        while (_player)
        {
            yield return new WaitForSeconds(_fireRate); // Pausa la corrutina durante unos segundos
            RocketMover newProjectile = Instantiate(_rocketPrefab, _rocketSpawnPoint.position, this.transform.rotation).GetComponent<RocketMover>();
            // Para que salgan desde la posicion del disparo del muñeco.
            newProjectile.transform.LookAt(new Vector3(_player.transform.position.x, _rocketSpawnPoint.position.y, _player.transform.position.z));
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_enemyExplosion) Instantiate(_enemyExplosion,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


}

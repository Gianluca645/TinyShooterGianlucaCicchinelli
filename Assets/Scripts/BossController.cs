using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private PlayerInputController _player;

    [SerializeField] private GameObject _enemyExplosion;
    

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _player = FindAnyObjectByType<PlayerInputController>();
        if (_player) _navMeshAgent.SetDestination(_player.transform.position);
        
    }

    void Update()
    {
        if (_player)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
            this.transform.LookAt(new Vector3(_player.transform.position.x, this.transform.position.y, _player.transform.position.z));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelController levelController = FindAnyObjectByType<LevelController>();
            if (levelController) levelController.TriggerReloadLevel();
        }
    }

    public void OnBossDefeated()
    {
        BonusScoreManager bonusscoreManager = FindAnyObjectByType<BonusScoreManager>();
        if (bonusscoreManager) bonusscoreManager.BossDefeated();
        
    }
}
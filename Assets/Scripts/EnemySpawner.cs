using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _spawnRate = 15f; // Velocidad (seg) a la que sale cada muñeco
    [SerializeField] int _maxEnemies = 5;  // Maximo numero de enemigos

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);

            int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (currentEnemies < _maxEnemies)
            {
                Instantiate(_enemyPrefab, this.transform.position, this.transform.rotation);
            }
        }
    }
}
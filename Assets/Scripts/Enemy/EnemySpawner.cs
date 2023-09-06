using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private const float ENEMY_SPAWN_INTERVAL = 1;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] randomPositions;

    private void Awake()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(ENEMY_SPAWN_INTERVAL);
        }
    }

    private void SpawnEnemy()
    {
        int random = Random.Range(0, randomPositions.Length);
        Vector3 randomSpawnPosition = randomPositions[random].position;
        Spawner.Spawn(enemyPrefab, randomSpawnPosition, Quaternion.identity);
    }
}

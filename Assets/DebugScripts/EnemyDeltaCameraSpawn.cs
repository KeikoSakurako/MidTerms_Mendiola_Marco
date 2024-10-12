using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeltaCameraSpawn : MonoBehaviour
{
    
    [SerializeField] PlayerDetlaControl _player;
    [SerializeField] EnemyDeltaControl _enemyDetlaPrefab; //EditInOriginal

    [SerializeField] float _spawnInterval;
    [SerializeField] int _enemyLimit = 10;

    Queue<EnemyDeltaControl> _availableEnemies = new(); //EditInOriginal

    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        InstantiateDetlaEnemies();
        InvokeRepeating(nameof(SpawnEnemy), 1f, _spawnInterval);
    }

    private void InstantiateDetlaEnemies()
    {
        for (int i = 0; i < _enemyLimit; i++)
        {
            // Spawn enemies
            var enemy = Instantiate(_enemyDetlaPrefab, transform); //EditInOriginal
            enemy.Initialize(_player.transform, this);
            enemy.gameObject.SetActive(false);
            _availableEnemies.Enqueue(enemy);

        }
    }


    public void ReturnEnemyToPool(EnemyDeltaControl enemy) //EditInOriginal
    {
        _availableEnemies.Enqueue(enemy);
        print($"{enemy.name} returned to queue");
    }


    public void SpawnEnemy()
    {
        // Initial Random.Range determines Left/Right side
        var spawnX = Random.Range(0f, 1f);
        if (spawnX < 0.5f)
        {
            spawnX = 0 - Random.Range(0f, 1f);
        }
        else
        {
            spawnX = 1 + Random.Range(0f, 1f);
        }
        var spawnY = Random.Range(0f, 1f);
        if (spawnY < 0.5f)
        {
            spawnY = 0 - Random.Range(0f, 1f);
        }
        else
        {
            spawnY = 1 + Random.Range(0f, 1f);
        }
        var spawnPosition = _camera.ViewportToWorldPoint(new(spawnX, spawnY, 10f));
        if (_availableEnemies.Count <= 0)
        {
            // Debug.LogWarning($"No enemy returned from queue. Instantiating {_enemyLimit} enemies. Will be used on next call.");
            // InstantiateEnemies();
            return;
        }
        var enemy = _availableEnemies.Dequeue();
        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);
    }
}

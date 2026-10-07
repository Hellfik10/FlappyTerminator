using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectSpawner<Character>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _minSpawnPointY;
    [SerializeField] private float _maxSpawnPointY;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private float _spawnTime = 3;
    [SerializeField] private Character _prefab;

    private Quaternion _rotation = Quaternion.Euler(0, 0, 0);

    public event Action EnemyReleased;

    protected override int PoolCapacity => _poolCapacity;
    protected override int PoolMaxSize => 15;

    private void Start()
    {
        StartCoroutine(EnableObject());
    }

    public IEnumerator EnableObject()
    {
        while (enabled)
        {
            var wait = new WaitForSeconds(_spawnTime);

            yield return wait;

            SpawnObject();
        }
    }

    protected override void Initialize(Character enemy)
    {
        enemy.transform.position = GetRandomSpawnPoint();
        enemy.gameObject.SetActive(true);
    }

    private void ReleasedObject(Character enemy)
    {
        EnemyReleased?.Invoke();
        ReleaseObject(enemy);
    }

    protected override Character CreateObject()
    {
        Character enemy = Instantiate(_prefab, GetRandomSpawnPoint(), _rotation);
        enemy.Destroyed += ReleasedObject;

        return enemy;
    }

    protected override void DestroyObject(Character enemy)
    {
        enemy.Destroyed -= ReleasedObject;
        Destroy(enemy.gameObject);
    }

    protected override void OnReleased(Character enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Vector2 GetRandomSpawnPoint()
    {
        Vector2 spawnPoint = new Vector2(_spawnPoint.transform.position.x, UnityEngine.Random.Range(_minSpawnPointY, _maxSpawnPointY));

        return spawnPoint;
    }
}

using UnityEngine;

public class BulletSpawner : ObjectSpawner<Bullet>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private Character _character;
    [SerializeField] private float _rotationZ;

    private Quaternion _rotation;

    protected override int PoolCapacity => _poolCapacity;
    protected override int PoolMaxSize => 100;

    protected override void Awake()
    {
        _rotation = Quaternion.Euler(0, 0, _rotationZ);
        base.Awake();
    }

    public void EnableBullet()
    {
        SpawnObject();
    }

    protected override void Initialize(Bullet bullet)
    {
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _rotation;
        bullet.InitializeDirection(_character.transform.position.x, _spawnPoint.transform.position.x);
        bullet.gameObject.SetActive(true);
    }

    private void ReleasedObject(Bullet bullet)
    {
        ReleaseObject(bullet);
    }

    protected override Bullet CreateObject()
    {
        Bullet bullet = Instantiate(_prefab, _spawnPoint.position, _rotation);
        bullet.EndedLifeTime += ReleasedObject;

        return bullet;
    }

    protected override void DestroyObject(Bullet bullet)
    {
        bullet.EndedLifeTime -= ReleasedObject;
        Destroy(bullet.gameObject);
    }

    protected override void OnReleased(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}

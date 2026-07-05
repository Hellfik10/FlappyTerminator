using UnityEngine;

[CreateAssetMenu(fileName="New Bullet", menuName=nameof(BulletConfig), order=51)]
public class BulletConfig : ScriptableObject
{
    [SerializeField] private Sprite _image;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _lifeTime;

    public Sprite Image => _image;
    public float BulletSpeed => _bulletSpeed;
    public float EnemyLayer => _enemyLayer;
    public float LifeTime => _lifeTime;
}

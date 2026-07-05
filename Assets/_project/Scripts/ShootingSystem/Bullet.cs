using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(BulletMover), typeof(BulletCollisionDetector))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletConfig _bulletInfo;

    private BulletMover _bulletMover;
    private Coroutine _coroutine;
    private BulletCollisionDetector _collisionDetector;

    public Action<Bullet> EndedLifeTime;

    private void Awake()
    {
        _collisionDetector = GetComponent<BulletCollisionDetector>();
        _bulletMover = GetComponent<BulletMover>();
    }

    private void OnEnable()
    {
        _collisionDetector.CollisionDetected += DisableObject;
        _coroutine = StartCoroutine(StartCountingTime());
    }

    private void OnDisable()
    {
        _collisionDetector.CollisionDetected -= DisableObject;
        StopCoroutine(_coroutine);
    }

    public void InitializeDirection(float characterPosition, float spawnPointPosition)
    {
        _bulletMover.SetDirection(spawnPointPosition - characterPosition);
    }

    private IEnumerator StartCountingTime()
    {
        var wait = new WaitForSeconds(_bulletInfo.LifeTime);

        yield return wait;

        EndedLifeTime?.Invoke(this);
    }

    private void DisableObject()
    {
        EndedLifeTime?.Invoke(this);
    }
}

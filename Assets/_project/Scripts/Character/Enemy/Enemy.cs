using System;
using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float _minAttackDelay = 2f;
    [SerializeField] private float _maxAttackDelay = 3f;

    private Coroutine _coroutine;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _coroutine = StartCoroutine(Attack());
    }

    public override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(_coroutine);
    }

    private IEnumerator Attack()
    {
        while (enabled)
        {
            float delay = UnityEngine.Random.Range(_minAttackDelay, _maxAttackDelay);
            var wait = new WaitForSeconds(delay);

            yield return wait;

            BulletSpawner.EnableBullet();
        }
    }
}

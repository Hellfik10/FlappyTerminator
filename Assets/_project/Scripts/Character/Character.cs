using System;
using UnityEngine;

[RequireComponent(typeof(CharacterCollisionDetector), typeof(BulletSpawner))]

public abstract class Character : MonoBehaviour
{
    protected BulletSpawner BulletSpawner;


    private CharacterCollisionDetector _collisionHandler;

    public event Action <Character> Destroyed;

    public virtual void Awake()
    {
        _collisionHandler = GetComponent<CharacterCollisionDetector>();
        BulletSpawner = GetComponent<BulletSpawner>();
    }

    public virtual void OnEnable()
    {
        _collisionHandler.CollisionDetected += DisableObject;
    }

    public virtual void OnDisable()
    {
        _collisionHandler.CollisionDetected -= DisableObject;
    }

    public void DisableObject()
    {
        Destroyed?.Invoke(this);
    }
}

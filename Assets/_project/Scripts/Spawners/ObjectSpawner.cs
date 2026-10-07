using UnityEngine;
using UnityEngine.Pool;

public abstract class ObjectSpawner<T> : MonoBehaviour where T : Component
{
    private ObjectPool<T> _pool;

    protected virtual int PoolCapacity => 5;
    protected virtual int PoolMaxSize => 100;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: CreateObject,
            actionOnGet: Initialize,
            actionOnRelease: OnReleased,
            defaultCapacity: PoolCapacity,
            actionOnDestroy: DestroyObject,
            maxSize: PoolMaxSize);
    }

    protected void SpawnObject()
    {
        _pool.Get();
    }

    protected void ReleaseObject(T instance)
    {
        _pool.Release(instance);
    }

    protected abstract T CreateObject();
    protected abstract void Initialize(T instance);
    protected abstract void DestroyObject(T instance);
    protected abstract void OnReleased(T instance);
}

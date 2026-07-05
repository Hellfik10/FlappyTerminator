using System;
using UnityEngine;

[RequireComponent(typeof(PointCollectorView))]

public class PointCollector : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    public event Action<float> ValueChanged;

    public float Count { get; private set; } = 0;

    private void OnEnable()
    {
        _spawner.EnemyReleased += IncreaseCounter;
    }

    private void OnDisable()
    {
        _spawner.EnemyReleased -= IncreaseCounter;
    }

    private void IncreaseCounter()
    {
        Count++;
        ValueChanged?.Invoke (Count);
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(PointCollectorView))]

public class PointCollector : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;

    public event Action<float> ValueChanged;

    public float Count { get; private set; } = 0;

    private void OnEnable()
    {
        spawner.EnemyReleased += IncreaseCounter;
    }

    private void OnDisable()
    {
        spawner.EnemyReleased -= IncreaseCounter;
    }

    private void IncreaseCounter()
    {
        Count++;
        ValueChanged?.Invoke (Count);
    }
}

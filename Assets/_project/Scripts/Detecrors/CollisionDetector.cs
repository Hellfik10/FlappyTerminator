using UnityEngine;
using System;

public abstract class CollisionDetector : MonoBehaviour
{
    [SerializeField] protected LayerMask EnemyMask;
    [SerializeField] protected LayerMask ObstacleMask;

    public virtual event Action CollisionDetected;
}

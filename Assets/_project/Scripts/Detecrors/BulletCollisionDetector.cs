using System;
using UnityEngine;

public class BulletCollisionDetector : CollisionDetector
{
    public override event Action CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & EnemyMask.value) != 0)
        {
            CollisionDetected?.Invoke();
        }
    }
}

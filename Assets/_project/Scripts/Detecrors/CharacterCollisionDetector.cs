using System;
using UnityEngine;

public class CharacterCollisionDetector : CollisionDetector
{
    private Character _character;

    public override event Action CollisionDetected;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & ObstacleMask.value) != 0)
        {
            CollisionDetected?.Invoke();
        }

        if(((1 << collision.gameObject.layer) & EnemyMask.value) != 0)
        {
            _character.DisableObject();
        }
    }
}

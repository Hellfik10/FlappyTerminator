using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Rigidbody2D _rigidbody;
    private float _direction = 1;   

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.linearVelocity = new Vector3(_direction,0) * _speed;
    }

    public void SetDirection(float value)
    {
        if(value > 0)
        {
            _direction = 1;
        }
        if(value < 0)
        {
            _direction = -1;
        }
    }
}

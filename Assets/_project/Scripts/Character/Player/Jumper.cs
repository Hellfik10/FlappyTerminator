using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Rigidbody2D _rigidbody;
    private bool _jumpRequested;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void FixedUpdate()
    {
        if (_jumpRequested)
        {
            _rigidbody.linearVelocity = Vector2.up * _tapForce;
            _jumpRequested = false;
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        _jumpRequested = true;
        transform.rotation = _maxRotation;
    }
}

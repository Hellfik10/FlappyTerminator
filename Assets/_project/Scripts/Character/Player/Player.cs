using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Jumper))]
public class Player : Character
{   
    private InputHandler _inputService;
    private Jumper _jumper;

    public override void Awake()
    {
        base.Awake();
        _jumper = GetComponent<Jumper>();
        _inputService = GetComponent<InputHandler>();
    }

    private void Start()
    {
        _inputService.Jumped += OnJump;
        _inputService.Attacked += OnAttack;
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    private void OnDestroy()
    {
        _inputService.Jumped -= OnJump;
        _inputService.Attacked -= OnAttack;
    }

    private void OnJump()
    {
        _jumper.Jump();
    }

    private void OnAttack()
    {
        BulletSpawner.EnableBullet();
    }
}

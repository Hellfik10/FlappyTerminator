using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private UnityInputSystem _inputSystem;

    private Vector2 _moveInput = Vector2.zero;
    private bool _isPaused = false;

    public event Action<Vector2> Moved;
    public event Action Attacked;
    public event Action Jumped;
    public event Action Paused;

    public Vector3 MoveDirection => _moveInput;


    private void Awake()
    {
        _inputSystem = new UnityInputSystem();
    }

    private void Start()
    {
        _inputSystem.Enable();

        _inputSystem.Player.Jump.started += OnJump;
        _inputSystem.Player.Attack.performed += OnAttack;
        _inputSystem.UI.Pause.performed += OnPause;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
    }

    private void OnDestroy()
    {
        _inputSystem.Player.Jump.started -= OnJump;
        _inputSystem.Player.Attack.performed -= OnAttack;
        _inputSystem.UI.Pause.performed -= OnPause;
    }

    public void EnablePause()
    {
        _isPaused = true;
    }

    public void DisablePause()
    {
        _isPaused = false;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_isPaused == false)
        {
            Jumped?.Invoke();
        }
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (_isPaused == false)
        {
        Attacked?.Invoke();
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        Paused?.Invoke();
    }
}

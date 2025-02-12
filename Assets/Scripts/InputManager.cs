using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;
    
    
    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;

    public void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        
        _playerMotor = GetComponent<PlayerMotor>();
        _playerLook = GetComponent<PlayerLook>();
        
        _onFoot.Jump.performed += _ => _playerMotor.Jump();
        _onFoot.Sprint.started += _ => _playerMotor.Sprint();
        _onFoot.Sprint.canceled += _ => _playerMotor.Sprint();
        _onFoot.Crouch.performed += _ => _playerMotor.Crouch();
    }

    public void FixedUpdate()
    {
        // Tell the player motor to move using the value from our movement action.
        _playerMotor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
    }

    public void LateUpdate()
    {
        _playerLook.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}
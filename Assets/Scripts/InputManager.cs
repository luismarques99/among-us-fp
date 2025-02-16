using Player;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions onFoot;
    
    private PlayerInput _playerInput;
    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;

    public void Awake()
    {
        _playerInput = new PlayerInput();
        onFoot = _playerInput.OnFoot;
        
        _playerMotor = GetComponent<PlayerMotor>();
        _playerLook = GetComponent<PlayerLook>();
        
        onFoot.Jump.performed += _ => _playerMotor.Jump();
        // Sprint and crouch disabled
        // _onFoot.Sprint.started += _ => _playerMotor.Sprint();
        // _onFoot.Sprint.canceled += _ => _playerMotor.Sprint();
        // _onFoot.Crouch.performed += _ => _playerMotor.Crouch();
    }

    public void FixedUpdate()
    {
        // Tell the player motor to move using the value from our movement action.
        _playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    public void LateUpdate()
    {
        _playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
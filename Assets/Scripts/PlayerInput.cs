using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions _controls;
    public Vehicle vehicle;
    private void Awake()
    {
        _controls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _controls.Player.Accelerate.performed += context => OnAccelerateInput(context);
        _controls.Player.Brake.performed += context => OnBrakeInput(context);
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Accelerate.performed -= context => OnAccelerateInput(context);
        _controls.Player.Brake.performed -= context => OnBrakeInput(context);
        _controls.Player.Disable();
    }

    private void OnAccelerateInput(InputAction.CallbackContext context)
    {
        vehicle.Accelerate(context.ReadValue<float>().Equals(1));
    }

    private void OnBrakeInput(InputAction.CallbackContext context)
    {
        vehicle.Brake(context.ReadValue<float>().Equals(1));
    }
}

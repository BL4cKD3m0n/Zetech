using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Movement movement;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    private void OnEnable()
    {
        if (movement == null)
        {
            movement = new Movement();

            movement.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}

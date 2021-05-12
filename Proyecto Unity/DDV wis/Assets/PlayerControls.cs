using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    
    public float speed = 10f;
    public float rotationSpeed = 15f;
    Transform cameraObject;
    Rigidbody playerRigidbody;
    private Vector2 movementInput;
    private void Awake()
    {
        cameraObject = Camera.main.transform;
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 moveDirection;//direccion
        moveDirection = cameraObject.forward * movementInput.y;
        moveDirection = moveDirection + cameraObject.right * movementInput.x;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * speed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;

       

        Vector3 targetDirection = Vector3.zero;//rotacion

        targetDirection = cameraObject.forward * movementInput.y;
        targetDirection = targetDirection + cameraObject.right * movementInput.x;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }
    public void OnMove(InputAction.CallbackContext ctx)=> movementInput = ctx.ReadValue<Vector2>();
}

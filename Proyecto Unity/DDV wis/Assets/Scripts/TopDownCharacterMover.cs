using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    public int player = 1;
    public float cooldowndash = 5;
    private float nextDash = 0;
    private float dashTime = 0;
    private float dashDuration = 2;
    private bool dashOn = false;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //var movementVector=MoveTowardTarget(targetVector);
        Vector3 movementVector;
        
        if(Time.time > nextDash)
        {
            if (Input.GetKey("r"))
            {
                if (Time.time > dashTime)
                {

                    dashTime = Time.time + dashDuration;
                    dashOn = true;                    
                }
                nextDash = Time.time + cooldowndash;
            }
            
        }
        if (Time.time < dashTime)
        {
            dashOn = false;
        }
        if (dashOn == true)
        {
            moveSpeed = 20;
        }
        else
        {
            moveSpeed = 4;
        }
        
       
        


        movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);

    }
    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }
    private Vector3 Dash(Vector3 tagetVector)
    {

        var speed = 20 * Time.deltaTime;
        tagetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * tagetVector;
        var targetPosition = transform.position + tagetVector * speed;
        transform.position = targetPosition;
        return tagetVector;

    }
    private Vector3 MoveTowardTarget(Vector3 tagetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        tagetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * tagetVector;
        var targetPosition = transform.position + tagetVector * speed;
        transform.position = targetPosition;
        return tagetVector;
        
    }
}

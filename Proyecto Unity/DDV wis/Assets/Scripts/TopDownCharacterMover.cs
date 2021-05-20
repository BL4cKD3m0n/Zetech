using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    public int player = 1;

    /*public float cooldowndash = 5;
    private float nextDash = 0;
    private float dashTime = 0;
    private float dashDuration = 2;
    private bool dashOn = false;*/

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera camera;

    //Agregado por chucho, si hay duda o problema decirme plotz :c
    [SerializeField]
    private float WalkSpeed;

    [SerializeField]
    private float DashLong;

    private Animator AnimMov;

    private float CoolDT = 1.5f;
    private float CoolDTemo = 5;
    private float NexUsT = 0;

    [SerializeField]
    private bool CanMove;
    //

    private void Awake()
    {
        _input = GetComponent<InputHandler>();

        //Agregado por chucho, si hay duda o problema decirme plotz :c
        AnimMov = GetComponentInChildren<Animator>();
        //
    }
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //var movementVector=MoveTowardTarget(targetVector);
        Vector3 movementVector;

        /* if(Time.time > nextDash)
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

         }//
         if (Time.time < dashTime)
         {
             dashOn = false;
         }
         if (dashOn == true)
         {
             moveSpeed = 20;
         }//
         else
         {
             moveSpeed = 4;
         }*/

        movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);

        //Agregado por chucho, si hay duda o problema decirme plotz :c
    
        if(Time.time > NexUsT)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Dash();
                NexUsT = Time.time + CoolDT;
            }
        }

        if(Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Attack();                         
                NexUsT = Time.time + CoolDT;
            }
        }

        if(Time.time > NexUsT)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Dap();
                NexUsT = Time.time + CoolDTemo;
            }
        }
        if(Time.time > NexUsT)
        {
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                Boring();
                NexUsT = Time.time + CoolDTemo;
            }
        }
        if(Time.time > NexUsT)
        {
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                FDance();
                NexUsT = Time.time + CoolDTemo;
            }
        }
        if(Time.time > NexUsT)
        {
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                VictoryDance();
                NexUsT = Time.time + CoolDTemo;
            }
        }

    }
        //
    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }
    /*private Vector3 Dash(Vector3 tagetVector)
    {

        var speed = 20 * Time.deltaTime;
        tagetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * tagetVector;
        var targetPosition = transform.position + tagetVector * speed;
        transform.position = targetPosition;
        return tagetVector;

    }*/

    private Vector3 MoveTowardTarget(Vector3 tagetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        tagetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * tagetVector;
        var targetPosition = transform.position + tagetVector * speed;
        transform.position = targetPosition;

        //Agregado por chucho, si hay duda o problema decirme plotz :c
        if (tagetVector != Vector3.zero && !Input.GetKey(KeyCode.R))
        {
            Walk();
        }
        else if (tagetVector == Vector3.zero)
        {
            Idle();
        }
        
        //
        return tagetVector;

    }
 
    //Agregado por chucho, si hay duda o problema decirme plotz :c
    private void Walk()
    {
        moveSpeed = WalkSpeed;
        AnimMov.SetFloat("ActionMove", 0.5f);
    }

    private void Idle()
    {
        moveSpeed = 0.0f;
        AnimMov.SetFloat("ActionMove", 0.1f);
    }  

    private void Dash()
    {
        moveSpeed = DashLong;
        AnimMov.SetTrigger("DashM");
    }

    private void Attack()
    {       
        AnimMov.SetTrigger("AttackPW");
    }

    private void Dap()
    {
        AnimMov.SetTrigger("DapT");
    }

    private void Boring()
    {
        AnimMov.SetTrigger("BoringT");
    }

    private void FDance()
    {
        AnimMov.SetTrigger("FT");
    }

    private void VictoryDance()
    {
        AnimMov.SetTrigger("VDT");
    }
    //
}
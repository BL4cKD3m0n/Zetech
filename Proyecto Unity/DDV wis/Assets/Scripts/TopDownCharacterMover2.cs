using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMover2 : MonoBehaviour, IDamage
{
    private InputHandler2 _input;
    public int player = 2;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float WalkSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float DashLong;
    
    [SerializeField]
    private bool CanMove;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float RealRotationSP;

    [SerializeField]
    private float RealWalkSP;

    private Animator AnimMov;

    private float IntervalTimeAT2 = 0;
    private float CoolDT = 1.0f;
    private float CoolDTemo = 4;
    private float NexUsT = 0;
    private float CoolDañoRecibido = 2.5f;

    public Transform PosDirecShoot;
    public Transform Player;

    private void Awake()
    {
        _input = GetComponent<InputHandler2>();

        //Agregado por chucho, si hay duda o problema decirme plotz :c
        AnimMov = GetComponentInChildren<Animator>();
        //

    }

    void Update()
    { 
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //var movementVector=MoveTowardTarget(targetVector);
        Vector3 movementVector;

        movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);

        Debug.DrawRay(PosDirecShoot.position, PosDirecShoot.forward * 100f, Color.red); //rayo disparador


        
        //Dash
        if (Time.time > IntervalTimeAT2) 
        {
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                moveSpeed = WalkSpeed * DashLong;
                Dash();
                IntervalTimeAT2 = Time.time + CoolDT;
            }
        }

        //Attack CoolDown, animation, stop and play
        if (Time.time > IntervalTimeAT2) 
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Space))
            {
                PastelazoObjectUse();
                DontMove(false);               
                Attack();               
                IntervalTimeAT2 = Time.time + CoolDT;
            }
            else
            {               
                DontMove(true);
            }
        }

        //Dap
        if (Time.time > IntervalTimeAT2) 
        {
            if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.J))
            {
                DontMove(false);
                Dap();
                IntervalTimeAT2 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }            
        }
        //Boring
        if (Time.time > IntervalTimeAT2)
        {
            if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.K))
            {
                DontMove(false);
                Boring();
                IntervalTimeAT2 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }
        }
        //FDance
        if (Time.time > IntervalTimeAT2)
        {
            if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.L))
            {
                DontMove(false);
                FDance();
                IntervalTimeAT2 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }
        }
        //VictoryDance
        if (Time.time > IntervalTimeAT2)
        {
            if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.I))
            {
                DontMove(false);
                VictoryDance();
                IntervalTimeAT2 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }
        }       
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }
    private Vector3 MoveTowardTarget(Vector3 tagetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        tagetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * tagetVector;
        var targetPosition = transform.position + tagetVector * speed;
        transform.position = targetPosition;

        //Agregado por chucho, si hay duda o problema decirme plotz :c
        if (tagetVector != Vector3.zero && !Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Keypad1))
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

    private void Walk()
    {
        AnimMov.SetFloat("ActionMove", 0.5f);
        moveSpeed = WalkSpeed;
    }
    private void Idle()
    {
        moveSpeed = 0.0f;
        AnimMov.SetFloat("ActionMove", 0.1f);
    }

    private void Dash()
    {     
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

    private void DontMove(bool CanMove)
    {
        if(CanMove == false)
        {
            WalkSpeed = 0;
            moveSpeed = 0;
            rotateSpeed = 0;
        }
        if(CanMove == true)
        {
            rotateSpeed = RealRotationSP;
            WalkSpeed = RealWalkSP;
        }
    }
    public void PastelazoObjectUse()
    {
        GameObject PastelazoObj = ObjectPoolingManager.instance.GetMunicion(true);

        PastelazoObj.transform.position = PosDirecShoot.position;
        Vector3 dir = Player.position + PosDirecShoot.forward * 10f;
        PastelazoObj.transform.LookAt(dir);
    }
    public void DoDamage(bool isPlayer)
    {
        Debug.Log("He Recibido Pastelazo " + " isPlayer = " + isPlayer);

        if (Time.time > IntervalTimeAT2)
        {
            if (isPlayer == true)
            {
                DontMove(false);
                AnimMov.SetTrigger("InjuredT");
                IntervalTimeAT2 = Time.time + CoolDañoRecibido;
            }
            else
            {
                DontMove(true);
            }
        }

    }

    
}

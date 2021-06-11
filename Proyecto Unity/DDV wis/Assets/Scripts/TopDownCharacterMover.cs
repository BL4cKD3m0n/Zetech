﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMover : MonoBehaviour, IDamage
{
    public bool ActiveShield1;
    Shield_Campo ScriptShield;

    private InputHandler _input;
    public int player = 1;


    public float moveSpeed;

    public float WalkSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float DashLong;
    private float RealWalk;
    public bool CanMove;

    [SerializeField]
    private Camera camera;

    public Animator AnimMov;

    private float IntervalTimeAT1 = 0; 
    private float CoolDT = 1.0f; //Cooldown Ataque
    private float CoolDTemo = 4; //Cooldown Emojis
    private float CoolDash = 0.5f;  //Cooldown Dash
    private float CoolDañoRecibido = 2.5f;  //Cooldown Inhabilitado si te atacan

    public Transform PosDirecShoot;
    public Transform Player;

    private void Awake()
    {
        RealWalk = WalkSpeed;
        _input = GetComponent<InputHandler>();
        AnimMov = GetComponentInChildren<Animator>();     
    }

    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //var movementVector=MoveTowardTarget(targetVector);
        Vector3 movementVector;

        movementVector = MoveTowardTarget(targetVector,CanMove);
        RotateTowardMovementVector(movementVector);

        Debug.DrawRay(PosDirecShoot.position, PosDirecShoot.forward * 100f, Color.red); //rayo disparador

      
        //Dash
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                WalkSpeed *= DashLong;
                Dash();
                IntervalTimeAT1 = Time.time + CoolDash;
            }
            else
            {
                WalkSpeed = RealWalk;
            }
        }

        //Attack CoolDown, animation, stop and play
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PastelazoObjectUse();
                
                CanMove = false;
                Attack();
                IntervalTimeAT1 = Time.time + CoolDT;
            }
            else
            {
                CanMove = true;
            }
        }

        //Dap
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {               
                CanMove = false;
                Dap();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                CanMove = true;
            }
        }
        //Boring
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CanMove = false;
                Boring();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                CanMove = true;
            }
        }
        //FDance
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CanMove = false;
                FDance();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                CanMove = true;
            }
        }
        //VictoryDance
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CanMove = false;
                VictoryDance();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                CanMove = true;
            }
        }

        ScriptShield.ActivateMove = ActiveShield1;
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }
    private Vector3 MoveTowardTarget(Vector3 tagetVector, bool canmove)
    {
        var speed = moveSpeed * Time.deltaTime;
        tagetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * tagetVector;
        var targetPosition = transform.position + tagetVector * speed;
        transform.position = targetPosition;
        if (canmove==false)
        {
            tagetVector = Vector3.zero;
        }
        else if (canmove == true)
        {
            if (tagetVector != Vector3.zero && !Input.GetKey(KeyCode.R))
            {
                Walk();
            }
            else if (tagetVector == Vector3.zero)
            {
                Idle();
            }
        }      
        return tagetVector;
    }

    private void Walk()
    {
        AnimMov.SetFloat("ActionMove", 0.5f);
        moveSpeed = WalkSpeed;
    }
    private void Idle()
    {        
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

    public void PastelazoObjectUse()
    {
        GameObject PastelazoObj = ObjectPoolingManager.instance.GetMunicion(true);

        PastelazoObj.transform.position = PosDirecShoot.position;
        Vector3 dir = Player.position + PosDirecShoot.forward * 10f;
        PastelazoObj.transform.LookAt(dir);
    }
    public void DoDamage(bool isPlayer)
    {
             

        Debug.Log("He Recibido Pastelazo  " + " isPlayer = " + isPlayer);

        if (Time.time > IntervalTimeAT1)
        {
            if (isPlayer == true && ActiveShield1 == false)
            {
                CanMove = false;
                AnimMov.SetTrigger("InjuredT");
                IntervalTimeAT1 = Time.time + CoolDañoRecibido;
            }
            else if (isPlayer == false && ActiveShield1 == false)
            {
                CanMove = true;
            }
            else if (isPlayer == false && ActiveShield1 == true)
            {
                CanMove = true;
            }
        }
     
    }
    


}
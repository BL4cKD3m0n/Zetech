using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterMover : MonoBehaviour, IDamage
{
    private InputHandler _input;
    public int player = 1;
    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public float WalkSpeed;

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
    public float RealWalkSP;

    private Animator AnimMov;

    private float IntervalTimeAT1 = 0;
    private float IntervalTimeH = 0;
    private float CoolDT = 1.0f;
    private float CoolDTemo = 4;
    private float CoolDash = 0.5f;
    private float CoolDañoRecibido = 2.5f;

    public Transform PosDirecShoot;
    public Transform Player;

    public bool ChoqueH = false;
    private float CoolPwHer = 4f;

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

        movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);

        Debug.DrawRay(PosDirecShoot.position, PosDirecShoot.forward * 100f, Color.red); //rayo disparador

        if (Time.time > IntervalTimeH)
        {
            if (ChoqueH == true)
            {
                WalkSpeed *= 1.8f;
                IntervalTimeH = Time.time + CoolPwHer;
                ChoqueH = false;
            }            
            
            //WalkSpeed = RealWalkSP;
        }

        //Dash
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                WalkSpeed *= DashLong;
                Dash();
                IntervalTimeAT1 = Time.time + CoolDash;
            }
        }

        //Attack CoolDown, animation, stop and play
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PastelazoObjectUse();
                DontMove(false);
                Attack();
                IntervalTimeAT1 = Time.time + CoolDT;
            }
            else
            {
                DontMove(true);
            }
        }

        //Dap
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DontMove(false);
                Dap();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }
        }
        //Boring
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DontMove(false);
                Boring();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }
        }
        //FDance
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                DontMove(false);
                FDance();
                IntervalTimeAT1 = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }
        }
        //VictoryDance
        if (Time.time > IntervalTimeAT1) 
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                DontMove(false);
                VictoryDance();
                IntervalTimeAT1 = Time.time + CoolDTemo;
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
        if (CanMove == false)
        {
            WalkSpeed = 0;
            moveSpeed = 0;
            rotateSpeed = 0;
        }
        if (CanMove == true)
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
        Debug.Log("He Recibido Pastelazo  " + " isPlayer = " + isPlayer);

        if (Time.time > IntervalTimeAT1)
        {
            if (isPlayer == true)
            {
                DontMove(false);
                AnimMov.SetTrigger("InjuredT");
                IntervalTimeAT1 = Time.time + CoolDañoRecibido;
            }
            else
            {
                DontMove(true);
            }
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        PW_Ups Hermes = other.GetComponent<PW_Ups>();
        if (Hermes != null)
        {
            float res = Hermes.GetEffects();
            if (Hermes.getID() == (int)PW_UpsID.VELOX2)
            {
                //WalkSpeed *= res;
                //Canvas controller para que aparezca imagen dependiendo del pewi este que agarre de Pw ups
                ChoqueH = true;
            }

        }
    }
}
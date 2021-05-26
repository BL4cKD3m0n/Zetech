using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMover : MonoBehaviour, IDamage
{
    private InputHandler _input;
    public int player = 1;
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

    private float IntervalTimeAT = 0;
    private float CoolDT = 1.0f;
    private float CoolDTemo = 5;
    private float NexUsT = 0;

    public Transform PosDirecShoot;
    public Transform Player;

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

        if (Time.time > NexUsT) //Dash
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Dash();
                NexUsT = Time.time + CoolDT;
            }
        }

        if (Time.time > IntervalTimeAT) //Attack CoolDown, animation, stop and play
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PastelazoObjectUse();
                DontMove(false);
                Attack();
                IntervalTimeAT = Time.time + CoolDT;
            }
            else
            {
                DontMove(true);
            }
        }

        if (Time.time > IntervalTimeAT) //Emotes
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DontMove(false);
                Dap();
                IntervalTimeAT = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DontMove(false);
                Boring();
                IntervalTimeAT = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                DontMove(false);
                FDance();
                IntervalTimeAT = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                DontMove(false);
                VictoryDance();
                IntervalTimeAT = Time.time + CoolDTemo;
            }
            else
            {
                DontMove(true);
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
        moveSpeed = WalkSpeed * DashLong;
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
    public void DoDamage(int vld, bool isPlayer)
    {
        Debug.Log("He Recibido Pastelazo = " + vld + ", isPlayer = " + isPlayer);
    }
}
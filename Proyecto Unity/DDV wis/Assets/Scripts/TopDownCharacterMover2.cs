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

    public Transform PosDirecShoot;
    public Transform Player;



    [SerializeField]
    private bool CanMove;
    //

    private void Awake()
    {
        _input = GetComponent<InputHandler2>();

        //Agregado por chucho, si hay duda o problema decirme plotz :c
        AnimMov = GetComponentInChildren<Animator>();
        //

    }

    public void DoDamage(int vld, bool isPlayer)
    {
        Debug.Log("He Recibido Pastelazo = " + vld + "isPlayer = " + isPlayer);
    }
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //var movementVector=MoveTowardTarget(targetVector);
        Vector3 movementVector;

        movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);

        //Agregado por chucho, si hay duda o problema decirme plotz :c

        Debug.DrawRay(PosDirecShoot.position, PosDirecShoot.forward * 100f, Color.red);

        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Insert))
        {

            //GameObject PastelazoObj = Instantiate(PastelazoPrefab);
            GameObject PastelazoObj = ObjectPoolingManager.instance.GetMunicion(true);

            PastelazoObj.transform.position = PosDirecShoot.position;
            Vector3 dir = Player.position + PosDirecShoot.forward * 10f;
            PastelazoObj.transform.LookAt(dir);
            //PastelazoObj.transform.rotation.x = PastelazoPrefab.transform.rotation.x;

        }


        if (Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                Dash();
                NexUsT = Time.time + CoolDT;
            }
        }

        if (Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Backspace))
            {
                Attack();
                NexUsT = Time.time + CoolDT;
            }
        }

        if (Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Dap();
                NexUsT = Time.time + CoolDTemo;
            }
        }
        if (Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Boring();
                NexUsT = Time.time + CoolDTemo;
            }
        }
        if (Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                FDance();
                NexUsT = Time.time + CoolDTemo;
            }
        }
        if (Time.time > NexUsT)
        {
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                VictoryDance();
                NexUsT = Time.time + CoolDTemo;
            }
        }    
    //

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

    
    //

}

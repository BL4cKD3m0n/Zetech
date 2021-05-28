using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public Vector2 InputVector { get; private set; }
    float h;
    float v;
    public TopDownCharacterMover tp;
    private void Start()
    {
        tp = GameObject.FindGameObjectWithTag("Player1").GetComponent<TopDownCharacterMover>();
    }

    void Update()
    {
        if (tp.CanMove == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                h = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                h = 1;
            }
            else
            {
                h = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                v = -1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                v = 1;
            }
            else
            {
                v = 0;
            }
        }
        else { v = 0;h = 0; }
        
        InputVector = new Vector2(h, v);
    }
}

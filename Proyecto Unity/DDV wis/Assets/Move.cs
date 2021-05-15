using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float x; 
    public float y;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x * speed,0, y * speed);
        if (Input.GetKey(KeyCode.A)) { x = 1; }
        else if (Input.GetKey(KeyCode.D)) { x = -1; }
        else { x = 0; }
        if (Input.GetKey(KeyCode.W)) { y = -1; }
        else if (Input.GetKey(KeyCode.S)) { y = 1; }
        else { y = 0; }
    }
}

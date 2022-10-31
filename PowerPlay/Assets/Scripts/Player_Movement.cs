using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public KeyCode moveup = KeyCode.W;
    public KeyCode movedown = KeyCode.S;
    public KeyCode moveleft = KeyCode.A;
    public KeyCode moveright = KeyCode.D;
    
    public float speed = 10.0f;
    
    
    private Rigidbody rbd;
    private Vector3 _startPosition;

    
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    public void Initialize()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        var vel = rbd.velocity;

        if (Input.GetKey(moveup))
        {
            vel.z = speed;
        }
        else if (Input.GetKey(movedown))
        {
            vel.z = -speed;
        }
        else if (Input.GetKey(moveright))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveleft))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(moveup) && Input.GetKey(moveright))
        {
            vel.x = speed;
            vel.z = speed;
        }
        else if (Input.GetKey(moveup) && Input.GetKey(moveleft))
        {
            vel.x = -speed;
            vel.z = speed;
        }
        else if (Input.GetKey(movedown) && Input.GetKey(moveright))
        {
            vel.x = speed;
            vel.z = -speed;
        }
        else if (Input.GetKey(movedown) && Input.GetKey(moveleft))
        {
            vel.x = -speed;
            vel.z = -speed;
        }
        else
        {
            vel.z = 0;
            vel.x = 0;
        }
        rbd.velocity = vel;
    }
}

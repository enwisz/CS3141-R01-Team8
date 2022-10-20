using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public KeyCode moveup = KeyCode.W;
    public KeyCode movedown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveright = KeyCode.D;
    public float speed = 10.0f;
    public float BoundX = 20.0f
    private Rigidbody3D rd3d;

    
    void Start()
    {
        rb3d = GetComponent<Rigidbody3D>();
    }

    void Update()
    {
        var vel = rb3d.velocity;
        if (Input.GetKey(moveup))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(movedown))
        {
            vel.y = -speed;
        }
        else if (Input.GetKey(moveright))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveleft))
        {
            vel.x = -speed;
        }
        else
        {
            vel.y = 0;
            vel.x = 0;
            vel.z = 0;
        }
        rb3d.velocity = vel;

        var pos = transform.position;
        if(pos.x > 0)
        {
            pos.x = 0;
        }
        else if(pos.x < -BoundX)
        {
            pos.x = -BoundX;
        }
        transform.position = pos;
    }
}

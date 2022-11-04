using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody rbd;

    public float force = 100f;
    public float maxSpeed = 100f;

    public KeyCode moveup = KeyCode.W;
    public KeyCode movedown = KeyCode.S;
    public KeyCode moveleft = KeyCode.A;
    public KeyCode moveright = KeyCode.D;
    
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rbd.velocity = Vector3.ClampMagnitude(rbd.velocity, maxSpeed);

        if (Input.GetKey(moveup))
        {
            rbd.AddForce(0, 0, force);
        }
        if (Input.GetKey(movedown))
        {
            rbd.AddForce(0, 0, -force);
        }
        if (Input.GetKey(moveright))
        {
            rbd.AddForce(force, 0, 0);
        }
        if (Input.GetKey(moveleft))
        {
            rbd.AddForce(-force, 0, 0);
        }
    }
}

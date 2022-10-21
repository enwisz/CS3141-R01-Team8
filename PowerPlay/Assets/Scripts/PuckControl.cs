using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody rbd;

    void GoRandDir()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rbd.AddForce(new Vector3(20,0, 15));
        }
        else
        {
            rbd.AddForce(new Vector3(-20, 0, -15));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Invoke("GoRandDir", 2);
    }

    void ResetPuck()
    {
        rbd.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    void RestartGame()
    {
        ResetPuck();
        Invoke("GoRandDir", 1);
    }

    void OnCollision(Collision coll)
    {
        if (coll.collider.CompareTag("Player1") || coll.collider.CompareTag("Player2"))
        {
            Vector3 vel;
            vel.x = rbd.velocity.x;
            vel.z = (rbd.velocity.z / 2) + (coll.collider.attachedRigidbody.velocity.z / 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

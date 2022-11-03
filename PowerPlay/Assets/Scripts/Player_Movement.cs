using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
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
        /*
        Checks the Player tag and uses the corresponding player movement inputs. 
        */
        if(this.CompareTag("Player1")){
            Vector3 movement_vector = new Vector3(Input.GetAxis("P1_Horizontal"), 0,  Input.GetAxis("P1_Vertical"));
            if (movement_vector != Vector3.zero){
            rbd.MovePosition(rbd.position + movement_vector * Time.deltaTime * speed);
            }
        }

        if(this.CompareTag("Player2")){
            Vector3 movement_vector = new Vector3(Input.GetAxis("P2_Horizontal"), 0,  Input.GetAxis("P2_Vertical"));
            if (movement_vector != Vector3.zero){
            rbd.MovePosition(rbd.position + movement_vector * Time.deltaTime * speed);
            }
        }
    }
}

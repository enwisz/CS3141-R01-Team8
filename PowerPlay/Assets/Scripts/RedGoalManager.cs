using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is for the goal on the red players half of the court

public class RedGoalManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Puck")
        {
            //Debug.Log("Collision 1");
            ScoreManager.instance.AddBluePoint();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

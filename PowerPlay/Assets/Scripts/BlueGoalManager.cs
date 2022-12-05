using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is for the goal on the blue players side of the court
public class BlueGoalManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Puck")
        {
            //Debug.Log("Collision 2");
            ScoreManager.instance.AddRedPoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

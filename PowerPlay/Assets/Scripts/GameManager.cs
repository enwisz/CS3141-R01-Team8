using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public GUISkin layout;

    GameObject thePuck;
    void Start()
    {
        //thePuck = gameObject.FindGameObjectWithTag("Puck");
    }

    public static void Score ( string wallID)
    {
        if(wallID == "Player2Goal")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        //GUI.Label(new Rect(Camera.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        //GUI.Label(new Rect(Camera.width / 2 + 150 = 12, 20, 100, 100), "" + PlayerScore2);

    }

    void Update()
    {
        
    }
}

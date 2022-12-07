using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Transform blueTransform;
    public Transform redTransform;
    public Transform puckTransform;

    public Rigidbody blueRigid;
    public Rigidbody redRigid;
    public Rigidbody puckRigid;
    
    public Text redScoreText;
    public Text blueScoreText;
    public Text bigText;
    public Image pausedPanel;

    public bool paused = true;

    int redScore = 0;
    int blueScore = 0;

    private Vector3 redPos;
    private Vector3 bluePos;
    private Vector3 puckPos;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        redScoreText.text = redScore.ToString();
        blueScoreText.text = blueScore.ToString();

        redPos = redTransform.position;
        bluePos = blueTransform.position;
        puckPos = puckTransform.position;

        StartGame();
    }

    // Update is called once per frame
    public void AddRedPoint()
    {
        redScore += 1;
        if (redScore > 2) {
            EndGame();
        }
        redScoreText.text = redScore.ToString();
        GoalScored();
    }

    public void AddBluePoint()
    {
        blueScore += 1;
        if (blueScore > 2) {
            EndGame();
            return;
        }
        blueScoreText.text = blueScore.ToString();
        GoalScored();
    }

    public void GoalScored()
    {
        paused = true;
        ResetPositions(); 
        StartGame();
    }

    public void ResetPositions()
    {
        blueTransform.transform.position = bluePos;
        redTransform.transform.position = redPos; 
        puckTransform.transform.position = puckPos;

        blueRigid.velocity = Vector3.zero;
        redRigid.velocity = Vector3.zero;
        puckRigid.velocity = Vector3.zero;
    }

    public void ShakeCamera() 
    {

    }

    public void StartGame()
    {
        paused = false;
    }

    public void EndGame()
    {
        paused = true;
        string endText = "";
        if (redScore > blueScore) {
            endText = "Red Player Wins!";    
        } else if (blueScore > redScore) {
            endText = "Blue Player Wins!";
        } else {
            endText = "Tie!";
        }

        bigText.text = endText;
        bigText.enabled = true;
        pausedPanel.enabled = true; 
    }

}

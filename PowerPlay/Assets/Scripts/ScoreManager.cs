using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        redScoreText.text = redScore.ToString();
        if (redScore > 2) {
            EndGame();
        }
        StartCoroutine(playerScored("red"));
        GoalScored();
    }

    public void AddBluePoint()
    {
        blueScore += 1;
        blueScoreText.text = blueScore.ToString();
        paused = true;
        if (blueScore > 2) {
            EndGame();
            return;
        }
        StartCoroutine(playerScored("blue"));
        GoalScored();
    }

    public void GoalScored()
    {
        paused = true;
        ResetPositions(); 
        StartGame();
    }

    IEnumerator playerScored(string player)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started playerScored at timestamp : " + Time.time);

        paused = true;
        string endText = "";
        if (player == "red") {
            endText = "Red Player Scores!";    
        } else if (player == "blue") {
            endText = "Blue Player Scores!";
        }

        bigText.text = endText;
        bigText.enabled = true;
        pausedPanel.enabled = true; 

        //Waits for 5 seconds
        yield return new WaitForSeconds(5);

        bigText.enabled = false;
        pausedPanel.enabled = false;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished playerScored at timestamp : " + Time.time);
        
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

        StartCoroutine(toMainMenu(3));
    }

    IEnumerator toMainMenu(float time1)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        SceneManager.LoadScene(0);
    }

}

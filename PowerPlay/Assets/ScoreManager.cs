using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text redScoreText;
    public Text blueScoreText;

    int redScore = 0;
    int blueScore = 0;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        redScoreText.text = redScore.ToString();
        blueScoreText.text = blueScore.ToString();
    }

    // Update is called once per frame
    public void AddRedPoint()
    {
        redScore += 1;
        redScoreText.text = redScore.ToString();
    }

    public void AddBluePoint()
    {
        blueScore += 1;
        blueScoreText.text = blueScore.ToString();
    }
}

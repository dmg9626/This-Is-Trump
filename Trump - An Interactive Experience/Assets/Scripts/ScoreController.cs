using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour 
{
    public int Score;
    public GameObject ScoreText;
	// Use this for initialization
	void Start () 
    {
        Score = 0;
        ScoreText = GameObject.Find("Score");
        ScoreText.GetComponent<Text>().text = "Score: \n " + Score;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void UpdateScore(int scoreIncrease)
    {
        Score += scoreIncrease;
        ScoreText.GetComponent<Text>().text = "Score: \n " + Score;
    }
}

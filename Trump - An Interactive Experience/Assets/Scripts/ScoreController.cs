using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour 
{
    public int Score;
    public GameObject ScoreText;

    private int _badHombreKills;
    private int _cameraManKills;
    private int _score;
    private int _time;
    public GameObject EnemyThatKilledYou; // enemy that killed you

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

    public void GameOverStats(int badHombreKills, int cameraManKills, float time)
    {
        _badHombreKills = badHombreKills;
        _cameraManKills = cameraManKills;
        _time = (int)time;

        Debug.Log("Bad Hombres Killed: " + _badHombreKills);
        Debug.Log("Liberal Media Killed: " + _cameraManKills);
        Debug.Log("Time: " + _time);
        Debug.Log("Score " + Score);
    }

    public void DisplayGameOverStats()
    {
        GameObject gameOverMessage = GameObject.Find("GameOverMessage");
        gameOverMessage.GetComponent<GUIText>().text += "";
    }
}

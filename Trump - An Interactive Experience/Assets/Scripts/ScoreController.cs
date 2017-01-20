using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour 
{
    public int Score;
    public GameObject ScoreText;
    GameObject PromptText;

    private int _badHombreKills;
    private int _cameraManKills;
    private int _time;
    private string _enemyName;

	// Use this for initialization
	void Start () 
    {
        Score = 0;
        ScoreText = GameObject.Find("Score");

        ScoreText.GetComponent<TextMesh>().text = "Score: \n " + Score;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void UpdateScore(int scoreIncrease)
    {
        Score += scoreIncrease;
        ScoreText.GetComponent<TextMesh>().text = "Score: \n" + Score;
    }

    public void SetGameOverStats(GameObject enemy, int badHombreKills, int cameraManKills, float time)
    {
        _badHombreKills = badHombreKills;
        _cameraManKills = cameraManKills;
        _time = (int)time;
        _enemyName = enemy.name;
    }

    public void DisplayGameOverStats()
    {
        GameObject gameOverMessage = GameObject.Find("GameOverMessage");
        switch(_enemyName)
        {
            case "Bad Hombre":
                _enemyName = "a Bad Hombre";
                break;
            case "Camera Man":
                _enemyName = "the \nBiased Liberal Media";
                break;
        }
        gameOverMessage.GetComponent<TextMesh>().text = string.Format("You got hit by {0}!", _enemyName);
        GameObject gameOverStats = GameObject.Find("GameOverStats");
        gameOverStats.GetComponent<TextMesh>().text = "Score: " + Score + "\n";

        gameOverStats.GetComponent<TextMesh>().text += string.Format("You kicked out {0} Bad Hombre{1}", _badHombreKills, FormatStatEnding(_badHombreKills));
        gameOverStats.GetComponent<TextMesh>().text += string.Format("You shut down {0} Biased Liberal Media{1}", _cameraManKills, FormatStatEnding(_cameraManKills));
        gameOverStats.GetComponent<TextMesh>().text += string.Format("You were president for {0} second{1}", _time, FormatStatEnding(_time));

        PromptText = GameObject.Find("PromptText");
        InvokeRepeating("ToggleText", 1, .5F);
    }

    private string FormatStatEnding(int number)
    {
        return number != 1 ?  "s\n" : "\n";
    }

    public void ToggleText()
    {
        PromptText.SetActive(!PromptText.activeSelf);
    }
}

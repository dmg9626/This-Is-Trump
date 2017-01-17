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
    private int _time;
    private string _enemyName;

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
        ScoreText.GetComponent<Text>().text = "Score: \n" + Score;
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
        gameOverMessage.GetComponent<TextMesh>().text += _enemyName + "!";

        GameObject gameOverStats = GameObject.Find("GameOverStats");
        gameOverStats.GetComponent<Text>().text = "Score: " + Score + "\n";

        gameOverStats.GetComponent<Text>().text += string.Format("You kicked out {0} Bad Hombre{1}", _badHombreKills, FormatStatEnding(_badHombreKills));
        gameOverStats.GetComponent<Text>().text += string.Format("You shut down {0} Biased Liberal Media{1}", _cameraManKills, FormatStatEnding(_cameraManKills));
        gameOverStats.GetComponent<Text>().text += string.Format("You were president for {0} second{1}", _time, FormatStatEnding(_time));
    }

    private string FormatStatEnding(int number)
    {
        return number != 1 ?  "s\n" : "\n";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour 
{
    public int Score;
    public GameObject ScoreText;
    public GameObject YearText;

    public Text ScoreTextUI;
    public Text YearTextUI;
    public GameObject TweetText;
    public GameObject WallText;
    public GameObject PromptText;

    private float _time;
    private int _badHombreKills;
    private int _cameraManKills;
    private int _level;
    private string _enemyName;

	// Use this for initialization
	void Start () 
    {
        Score = 0;
        _time = 0;
        ScoreText = GameObject.Find("Score");
        YearText = GameObject.Find("YearsInOffice");

        TweetText = GameObject.Find("TweetText");
        WallText = GameObject.Find("WallText");

        // ScoreText.GetComponent<TextMesh>().text = "Score: \n " + Score;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            if(WallText.activeSelf && TweetText.activeSelf)
            {
                if(_time > 10 && WallText.activeSelf)
                    ToggleInstructionText();
                else 
                    _time += Time.deltaTime;
            }
        }
	}

    public void IncreaseScore(int scoreIncrease)
    {
        Score += scoreIncrease;
        // ScoreText.GetComponent<TextMesh>().text = "Score: \n" + Score;
        ScoreTextUI.text = "Score: \n" + Score;
    }

    public void UpdateYear(int year)
    {
        // YearText.GetComponent<TextMesh>().text = "Years in Office: \n" + year;
        YearTextUI.text = "Years in Office: \n" + year;
    }

    public void SetGameOverStats(GameObject enemy, int badHombreKills, int cameraManKills, int level)
    {
        _badHombreKills = badHombreKills;
        _cameraManKills = cameraManKills;
        _level = level;
        _enemyName = enemy.name;
    }

    public void DisplayGameOverStats()
    {
        TextMesh RankText = GameObject.Find("RankMessage").GetComponent<TextMesh>();
        string rank = null;
        string rankNum = null;
        if (_level <= 2)
        {
            rank = "Small Hands";
            rankNum = "5";
        }
        else if (_level <= 4)
        {
            rank = "Low Energy";
            rankNum = "4";
        }
        else if (_level <= 6)
        {
            rank = "Drumpf";
            rankNum = "3";
        }
        else if (_level <= 8)
        {
            rank = "Deplorable";
            rankNum = "2";
        }
        else
        {
            rank = "4 Dimensional Chess";
            rankNum = "1";
        }
        
        RankText.text = string.Format("Rank {0}: {1}", rankNum, rank);

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
        gameOverStats.GetComponent<TextMesh>().text += string.Format("You were president for {0} year{1}", _level, FormatStatEnding(_level));

        PromptText = GameObject.Find("PromptText");
        InvokeRepeating("TogglePromptText", 1, .5F);
    }

    private string FormatStatEnding(int number)
    {
        return number != 1 ?  "s\n" : "\n";
    }

    public void TogglePromptText()
    {
        PromptText.SetActive(!PromptText.activeSelf);
    }

    public void ToggleInstructionText()
    {
        TweetText.SetActive(!TweetText.activeSelf);
        WallText.SetActive(!WallText.activeSelf);
    }
}

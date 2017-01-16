using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour
{

    // Use this for initialization
    private int _badHombreSpawnCount;
    private int _cameraManSpawnCount;

    private int _badHombreKillCount;
    private int _cameraManKillCount;

    public IList<GameObject> Hearts;
    public GameObject ScriptController;
    public GameObject ScoreController;
    public float time;

    void Start ()
    {
        SetUpNewScene("Game");
    }

    public void SetUpNewScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Game":
                {
                    SetUpGame();
                    break;
                }
            case "GameOver":
                {
                    GameObject enemy = GameObject.Find("Donald").GetComponent<Damage>().Enemy;
                    ScoreController.GetComponent<ScoreController>().SetGameOverStats(enemy, _badHombreKillCount, _cameraManKillCount, time);
                    
                    break;
                }
            default:
                break;
        }
    }

    private void SetUpGame()
    {
        Hearts = new GameObject[5];

        time = 0;
        ScriptController = GameObject.Find("ScriptController");
        ScoreController = GameObject.Find("ScoreController");
        DontDestroyOnLoad(ScoreController);

        Vector2 heartPosition = new Vector2(-6, 8);
        for (int i = 0; i < 5; i++)
        {
            Hearts[i] = Instantiate(Resources.Load("FullHeart")) as GameObject;
            Hearts[i].name = "FullHeart" + (i + 1);
            Hearts[i].transform.position = heartPosition;
            heartPosition.x += 1.5F;
        }
    }


    void Update()
    {
        time += Time.deltaTime;
    }

    public void RemoveHeart(int Lives)
    {
        GameObject heart = Hearts[Lives];
        Vector2 heartPosition = new Vector2(heart.transform.position.x, heart.transform.position.y);

        GameObject.Destroy(heart);
        heart = GameObject.Instantiate(Resources.Load("EmptyHeart")) as GameObject;
        heart.name = "EmptyHeart" + Lives;
        heart.transform.position = heartPosition;
    }

    public void BadHombreKilled()
    {
        _badHombreKillCount++;
        ScoreController.GetComponent<ScoreController>().UpdateScore(500);
    }
    public void BadHombreSpawned()
    {
        _badHombreSpawnCount++;
    }
    public void CameraManKilled()
    {
        _cameraManKillCount++;
        ScoreController.GetComponent<ScoreController>().UpdateScore(350);
    }
    public void CameraManSpawned()
    {
        _cameraManSpawnCount++;
    }

    public int BadHombreSpawnCount
    {
        get
        {
            return _badHombreSpawnCount;
        }
    }
    public int BadHombreKillCount
    {
        get
        {
            return _badHombreKillCount;
        }
    }
    public int CameraManSpawnCount
    {
        get
        {
            return _cameraManSpawnCount;
        }
    }
    public int CameraManKillCount
    {
        get
        {
            return _cameraManKillCount;
        }
    }
}

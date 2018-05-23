using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public List<Image> UIHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
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
                    int level = ScriptController.GetComponent<EnemySpawn>().LevelIndex;
                    ScoreController.GetComponent<ScoreController>().SetGameOverStats(enemy, _badHombreKillCount, _cameraManKillCount, level);
                    
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
    }


    void Update()
    {
        time += Time.deltaTime;
    }

    public void RemoveHeart(int Lives)
    {
        // Get reference to heart corresponding to player's reduced health
        Image heart = UIHearts[Lives];
        heart.sprite = emptyHeart;
    }

    public void BadHombreKilled()
    {
        _badHombreKillCount++;
        ScoreController.GetComponent<ScoreController>().IncreaseScore(500);
    }
    public void BadHombreSpawned()
    {
        _badHombreSpawnCount++;
    }
    public void CameraManKilled()
    {
        _cameraManKillCount++;
        ScoreController.GetComponent<ScoreController>().IncreaseScore(350);
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
    public int SpawnCount
    {
        get
        {
            return _badHombreSpawnCount + _cameraManSpawnCount;
        }
    }
}

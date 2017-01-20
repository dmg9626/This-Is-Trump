using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class EnemySpawn : MonoBehaviour 
{
    private GameObject ScriptController;
    private GameObject BadHombre;
    private GameObject CameraMan;

    private bool _canLevelUp = false;
    private float _frequency = 1.5F;
    public int LevelIndex = 1;
    
    // Use this for initialization
    void Start ()
    {
        ScriptController = GameObject.Find("ScriptController");
        BadHombre = Resources.Load("BadHombre") as GameObject;
        CameraMan = Resources.Load("CameraMan") as GameObject;

        InvokeRepeating("Spawn", .5F, _frequency);
        Debug.Log("Level " + LevelIndex);
    }

	void Spawn()
	{
		int randomNumber = Random.Range(0, 100); // random number from 0 to 100

		if (randomNumber >= 0 && randomNumber <= 70)
		{
			GameObject clone;
            int y = Random.Range(0, 100);
            if(y >= 50)
            {
                clone = Instantiate(Resources.Load("BadHombre")) as GameObject;
                clone.name = "Bad Hombre";
                ScriptController.GetComponent<Stats>().BadHombreSpawned(); // causing a Null Reference exception
            }
            if (y < 50)
            {
                clone = Instantiate(Resources.Load("CameraMan")) as GameObject;
                clone.name = "Camera Man";
                ScriptController.GetComponent<Stats>().CameraManSpawned(); // causing a Null Reference exception
            }
            _canLevelUp = true;
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(ScriptController.GetComponent<Stats>().SpawnCount % 10 == 0 && _canLevelUp)
        {
            IncreaseLevel();

            //if(ScriptController.GetComponent<Stats>().SpawnCount > 0)
            //{
            //    Debug.Log("level " + levelIndex);
            //    CancelInvoke();

            //    _frequency *= .8F;
            //    levelIndex++;
            //    InvokeRepeating("Spawn", 2, _frequency);
            //}
            //if (levelIndex > 1)
            //{

            //}
        }
	}

    void IncreaseLevel()
    {
        LevelIndex++;
        if (LevelIndex <= 2)
        {
            _frequency *= .8F;

            CancelInvoke();
            InvokeRepeating("Spawn", .5F, _frequency);
        }
        else
        {
            BadHombre.GetComponent<BadHombreMove>().LevelUp();
            CameraMan.GetComponent<CameraManMove>().LevelUp();
        }
        _canLevelUp = false;

        Debug.Log("Level " + LevelIndex);
    }
}

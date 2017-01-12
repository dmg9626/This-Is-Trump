using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class EnemySpawn : MonoBehaviour 
{
    GameObject ScriptController;
    private float _time = 0;
    private float _frequency = 1.5F;
    public int hombreIndex = 0;
    public int cameraManIndex = 0;
    public float levelIndex = 1;
    
    // Use this for initialization
    void Start ()
    {
        ScriptController = GameObject.Find("ScriptController");
	}

	void Spawn()
	{
		int randomNumber = Random.Range(0, 100); // random number from 0 to 100

		if (randomNumber >= 0 && randomNumber <= 70) // default 50% chance to spawn cow
		{
			GameObject clone;
            int y = Random.Range(0, 100);
            if(y >= 50)
            {
                clone = Instantiate(Resources.Load("BadHombre")) as GameObject;
                clone.name = "BadHombre";
                ScriptController.GetComponent<Stats>().BadHombreSpawned(); // causing a Null Reference exception
            }
            if (y < 50)
            {
                clone = Instantiate(Resources.Load("CameraMan")) as GameObject;
                clone.name = "CameraMan";
                ScriptController.GetComponent<Stats>().CameraManSpawned(); // causing a Null Reference exception
            }

            // spawns a prefab to the left of the screen
            // and casts it as a GameObject so it can be spawned in the scene
            // MAKE SURE THE PREFAB EXISTS IN THE RESOURCES FOLDER
            // ** MAKE DOUBLE SURE THAT THERE IS IN FACT A RESOURCES FOLDER ** //
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
        // this shit doesn't work
        //int totalSpawns = ScriptController.GetComponent<Stats>().BadHombreSpawnCount + ScriptController.GetComponent<Stats>().CameraManSpawnCount;
        //if (totalSpawns > 0 && totalSpawns % 20 == 0 )
        //{
        //    if (levelIndex > 1)
        //    {
        //        CancelInvoke();
        //    }
        //    Debug.Log("level " + levelIndex);
        //    _frequency *= .8F;
        //    levelIndex++;
        //
        //    InvokeRepeating("Spawn", 1, _frequency);
        //}
        //
        if(_time % 20 == 0)
        {
            if (levelIndex > 1)
            {
                CancelInvoke();
            }
            Debug.Log("level " + levelIndex);
            _frequency *= .8F;
            levelIndex++;
        
            InvokeRepeating("Spawn", 2, _frequency);
        }

        _time+= Time.deltaTime;
	}
}

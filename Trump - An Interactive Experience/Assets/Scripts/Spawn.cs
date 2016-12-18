using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class Spawn : MonoBehaviour 
{
    GameObject ScriptController;
    private float _time;
    private float _frequency;
    // Use this for initialization
    void Start ()
    {
        _frequency = 1.5F;
        InvokeRepeating("spawn", 1, _frequency);  // waits 5 seconds, then calls function cowSpawn every .25 seconds
        ScriptController = GameObject.Find("ScriptController");
        _time = 0;
	}

	void spawn()
	{
		int randomNumber = Random.Range(0, 100); // random number from 0 to 100

		if (randomNumber >= 0 && randomNumber <= 50) // default 50% chance to spawn cow
		{
			GameObject clone;
            int y = Random.Range(0, 100); ;
            if(y >= 50)
            {
                clone = Instantiate(Resources.Load("BadHombre")) as GameObject;
                //ScriptController.GetComponent<Stats>()._badHombreSpawnCount++; // causing a Null Reference exception
                //Debug.Log(ScriptController.GetComponent<Stats>()._badHombreSpawnCount + " bad hombres");
            }
            if (y < 50)
            {
                clone = Instantiate(Resources.Load("CameraMan")) as GameObject;
                //ScriptController.GetComponent<Stats>()._cameraManSpawnCount++; // causing a Null Reference exception
                //Debug.Log(ScriptController.GetComponent<Stats>()._cameraManSpawnCount + " bad hombres");
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
        if(_time > 600)
        {
            CancelInvoke();
            Debug.Log("level 2");
            _frequency = 1.15F;
            InvokeRepeating("spawn", 1, _frequency);
        }

        _time+= Time.deltaTime;
	}
}

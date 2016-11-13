using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class Spawn : MonoBehaviour 
{
	public Transform BadHombre;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("spawn", 1, 1.5F); 
		// waits 5 seconds, then calls function cowSpawn every .25 seconds
	}

	void spawn()
	{
		int x = Random.Range(0, 100); // random number from 0 to 100

		if (x >= 0 && x <= 50) // 35% chance to spawn cow
		{
			GameObject clone;
            int y = Random.Range(0, 100); ;
            if(y >= 50)
            {
                clone = Instantiate(Resources.Load("BadHombre")) as GameObject;
            }
            if (y < 50)
            {
                clone = Instantiate(Resources.Load("CameraMan")) as GameObject;
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
	
	}
}

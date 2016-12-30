using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour 
{

	// Use this for initialization
    GameObject DonaldWall;
    GameObject ScriptController;
	void Start () 
    {
        FindScriptController();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void FindScriptController()
    {
        ScriptController = GameObject.Find("ScriptController");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // causing NullReferenceException
            if (col.gameObject.name == "BadHombre")
            {
                ScriptController.GetComponent<Stats>().BadHombreKilled();
                Debug.Log("BadHombres killed: " + ScriptController.GetComponent<Stats>().BadHombreKillCount);
            }

            if (col.gameObject.name == "CameraMan")
            {
                ScriptController.GetComponent<Stats>().CameraManKilled();
                Debug.Log("CameraMans killed: " +  + ScriptController.GetComponent<Stats>().CameraManKillCount);
            }

            GameObject.Destroy(col.gameObject);
        }
    }
}

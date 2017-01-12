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
            if (col.gameObject.name == "BadHombre")
            {
                GameObject.Destroy(col.gameObject);

                ScriptController.GetComponent<Stats>().BadHombreKilled();
            }
            else
            {
                ScriptController.GetComponent<WallAnim>()._finishedAnimating = true;
            }
        }
    }
}

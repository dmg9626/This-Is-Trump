using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour 
{

	// Use this for initialization
    GameObject ScriptController;
	void Start () 
    {
        ScriptController = GameObject.Find("ScriptController");
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.name == "Bad Hombre")
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

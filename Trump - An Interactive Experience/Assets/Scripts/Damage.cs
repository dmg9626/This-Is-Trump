using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour 
{
    public int Lives;
    GameObject ScriptController;
	// Use this for initialization
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
        if (Lives > 0)
        {

            if (col.gameObject.tag == "Enemy")
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y);
                Lives--;
                ScriptController.GetComponent<Stats>().RemoveHeart(Lives);
            }
        }
        else
        {
            Application.LoadLevel("GameOver");
        }
    }


}

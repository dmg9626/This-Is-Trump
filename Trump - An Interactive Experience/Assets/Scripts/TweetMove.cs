using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetMove : MonoBehaviour 
{
    private float tweetSpeed;
    GameObject ScriptController;
	// Use this for initialization
	void Start () 
    {
        tweetSpeed = .25F;
        ScriptController = GameObject.Find("ScriptController");
	}
	
	// Update is called once per frame
	void Update () 
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + tweetSpeed, gameObject.transform.position.y);
        if (gameObject.transform.position.x > 13.5F)
        {
            GameObject.Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.name == "Camera Man")
            {
                GameObject.Destroy(col.gameObject);
                GameObject.Destroy(gameObject);
                ScriptController.GetComponent<Stats>().CameraManKilled();
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}

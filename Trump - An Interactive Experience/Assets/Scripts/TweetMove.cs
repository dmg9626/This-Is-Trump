using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetMove : MonoBehaviour 
{
    private float tweetSpeed;
	// Use this for initialization
	void Start () 
    {
        tweetSpeed = .25F;
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
                col.gameObject.GetComponent<CameraManMove>().SubtractHealth(2);
            }
            else if(col.gameObject.name == "Bad Hombre")
            {
                col.gameObject.GetComponent<BadHombreMove>().SubtractHealth(1);
            }
            GameObject.Destroy(gameObject);
        }
    }
}

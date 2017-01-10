using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrumpController : MonoBehaviour
{
    public bool canMove = true;
    public float playerSpeed;
    public GameObject Donald;
    public GameObject ScriptController;
    public GameObject SoundController;
	// Use this for initialization
	void Start ()
    {
        if(!GameObject.Find("Donald"))
        {
            Donald = Instantiate(Resources.Load("Donald")) as GameObject;
            Donald.name = "Donald";
            Donald.GetComponent<Damage>().Lives = 5;

            ScriptController = GameObject.Find("ScriptController");
            SoundController = GameObject.Find("SoundController");
        }
        playerSpeed = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!ScriptController.GetComponent<WallAnim>()._isAnimating)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Donald.transform.position = new Vector2(Donald.transform.position.x - playerSpeed * Time.deltaTime, Donald.transform.position.y);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Donald.transform.position = new Vector2(Donald.transform.position.x + playerSpeed * Time.deltaTime, Donald.transform.position.y);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if(!GameObject.Find("Tweet"))
                {
                    GameObject tweet = GameObject.Instantiate(Resources.Load("Tweet")) as GameObject;
                    tweet.transform.position = new Vector2(Donald.transform.position.x + 1, Donald.transform.position.y);
                    tweet.name = "Tweet";
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if(ScriptController.GetComponent<WallAnim>()._canBeginAnimating)
                {
                    ScriptController.GetComponent<WallAnim>()._beginAnimating = true; // trigger animation
                    SoundController.GetComponent<SoundManager>().WallRaise();
                }
            }
        }
    }

    
}

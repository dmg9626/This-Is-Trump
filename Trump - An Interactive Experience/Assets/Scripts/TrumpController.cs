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

    private int _badHombreKills;
    private int _cameraManKills;

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
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if(!ScriptController.GetComponent<WallAnim>()._isAnimating && !ScriptController.GetComponent<TweetAnim>()._isAnimating)
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
                    ScriptController.GetComponent<TweetAnim>()._beginAnimating = true;
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ScriptController.GetComponent<WallAnim>()._beginAnimating = true; // trigger animation
                SoundController.GetComponent<SoundManager>().DonaldSoundEffect();

            }
        }
    }


    
}

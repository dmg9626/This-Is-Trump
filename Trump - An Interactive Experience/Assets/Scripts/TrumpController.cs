using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrumpController : MonoBehaviour
{
    public bool CanControl = true;
    public float PlayerSpeed;
    public GameObject Donald;
    public GameObject ScriptController;
    public GameObject SoundController;

    private float _screenBoundaryLeft = -5.8F;
    private float _screenBoundaryRight = 10.25F;
    private float _killBoundaryLeft = -8.5F;

    // Use this for initialization
    void Start ()
    {
        if(!GameObject.Find("Donald"))
        {
            Donald = Instantiate(Resources.Load("Donald")) as GameObject;
            Donald.name = "Donald";
            Donald.GetComponent<Damage>().Lives = 5;

            ScriptController = GameObject.Find("ScriptController");
        }
        PlayerSpeed = 5;
        CanControl = true;
        DontDestroyOnLoad(ScriptController);
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputHandler();

        // if(Donald.transform.position.x <= _killBoundaryLeft)
            // kill donald
    }

    void InputHandler()
    {
        if(CanControl)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if(Donald.transform.position.x > _screenBoundaryLeft)
                    Donald.transform.position = new Vector2(Donald.transform.position.x - PlayerSpeed * Time.deltaTime, Donald.transform.position.y);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(Donald.transform.position.x < 10)
                    Donald.transform.position = new Vector2(Donald.transform.position.x + PlayerSpeed * Time.deltaTime, Donald.transform.position.y);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if(!GameObject.Find("Tweet"))
                {
                    GameObject tweet = GameObject.Instantiate(Resources.Load("Tweet")) as GameObject;
                    tweet.transform.position = new Vector2(Donald.transform.position.x + 1, Donald.transform.position.y);
                    tweet.name = "Tweet";
                    ScriptController.GetComponent<TweetAnim>()._beginAnimating = true; // trigger animation
                    ScriptController.GetComponent<SoundManager>().DonaldSoundEffect();
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ScriptController.GetComponent<WallAnim>()._beginAnimating = true; // trigger animation
                ScriptController.GetComponent<SoundManager>().DonaldSoundEffect();
            }
        }
    }
}

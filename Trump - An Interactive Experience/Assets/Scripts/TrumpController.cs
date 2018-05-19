using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrumpController : MonoBehaviour
{
    public bool CanMove;
    public bool CanAct;
    public float PlayerSpeed;
    public GameObject Donald;
    // public GameObject ScriptController;
    public GameObject SoundController;

    public float screenBoundaryLeft;
    public float screenBoundaryRight;
    //private float _killBoundaryLeft = -8.5F;

    // Use this for initialization
    void Start()
    {
        // ScriptController = GameObject.Find("ScriptController");
        // DontDestroyOnLoad(ScriptController);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();

        // if(Donald.transform.position.x <= _killBoundaryLeft)
        // kill donald
    }

    void InputHandler()
    {
        if (CanMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Donald.transform.position.x > screenBoundaryLeft)
                    Donald.transform.position = new Vector2(Donald.transform.position.x - PlayerSpeed * Time.deltaTime, Donald.transform.position.y);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Donald.transform.position.x < screenBoundaryRight)
                    Donald.transform.position = new Vector2(Donald.transform.position.x + PlayerSpeed * Time.deltaTime, Donald.transform.position.y);
            }
            if (CanAct)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!GameObject.Find("Tweet"))
                    {
                        GameObject tweet = GameObject.Instantiate(Resources.Load("Tweet")) as GameObject;
                        tweet.transform.position = new Vector2(Donald.transform.position.x + 1, Donald.transform.position.y);
                        tweet.name = "Tweet";
                        GetComponent<TweetAnim>()._beginAnimating = true; // trigger animation
                        GetComponent<SoundManager>().DonaldSoundEffect();
                    }
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    GetComponent<WallAnim>()._beginAnimating = true; // trigger animation
                    GetComponent<SoundManager>().DonaldSoundEffect();
                }
            }
        }
    }
}

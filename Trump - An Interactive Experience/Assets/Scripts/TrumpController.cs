using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrumpController : MonoBehaviour
{
    public bool canMove = true;
    public float playerSpeed;
    public GameObject trump;
    public GameObject ScriptController;
    public GameObject SoundController;
	// Use this for initialization
	void Start ()
    {
        if(!GameObject.Find("Donald"))
        {
            float TrumpXPos_Temp = -0.8F;
            float TrumpYPos_Temp = 1.91F;
            trump = Instantiate(Resources.Load("Donald")) as GameObject;
            trump.name = "Donald";
            trump.transform.position = new Vector2(TrumpXPos_Temp, TrumpYPos_Temp);
            ScriptController = GameObject.Find("ScriptController");
            SoundController = GameObject.Find("SoundController");
        }
        playerSpeed = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(ScriptController.GetComponent<Wall>()._canBeginAnimating)
            {
                ScriptController.GetComponent<Wall>()._beginAnimating = true; // trigger animation
                SoundController.GetComponent<SoundManager>().WallRaise();
            }
        }
        if(!ScriptController.GetComponent<Wall>()._isAnimating)
        {
            //move left/right
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                trump.transform.position = new Vector2(trump.transform.position.x - playerSpeed * Time.deltaTime, trump.transform.position.y);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                trump.transform.position = new Vector2(trump.transform.position.x + playerSpeed * Time.deltaTime, trump.transform.position.y);
            }
            if(Input.GetKey(KeyCode.Space))
            {
                trump.GetComponent<Jump>().BeginJump();
            }
        }
    }

    
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrumpController : MonoBehaviour
{
    public bool CanMove = true;
    public float PlayerSpeed;
    public GameObject trump;
    public GameObject ScriptController;
	// Use this for initialization
	void Start ()
    {
        if(!GameObject.Find("Donald"))
        {
            float TrumpXPos_Temp = -0.8F;
            float TrumpYPos_Temp = 1.91F;
            trump = Instantiate(Resources.Load("Donald")) as GameObject;
            trump.transform.position = new Vector2(TrumpXPos_Temp, TrumpYPos_Temp);
            ScriptController = GameObject.Find("ScriptController");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            trump.transform.position = new Vector2(trump.transform.position.x - PlayerSpeed * Time.deltaTime, trump.transform.position.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            trump.transform.position = new Vector2(trump.transform.position.x + PlayerSpeed * Time.deltaTime, trump.transform.position.y);
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
			ScriptController.GetComponent<Wall> ().beginAnimating = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "BadHombre(Clone)" || col.gameObject.name == "BadHombre")
        {
            SceneManager.LoadScene("GameOver_BadHombre");
        }
    }
}

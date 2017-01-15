using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        if (Lives > 1)
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
            // game over condition
            ScriptController.GetComponent<Stats>().SetUpNewScene("GameOver");
            MonoBehaviour[] scriptComponents = ScriptController.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scriptComponents)
            {
                Debug.Log("Found script " + script.GetType().Name);
            }
            GameObject.Destroy(ScriptController);
            SceneManager.LoadScene("GameOver");
        }
    }


}

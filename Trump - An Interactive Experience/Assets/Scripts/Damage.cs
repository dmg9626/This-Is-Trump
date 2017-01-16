using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Damage : MonoBehaviour 
{
    public int Lives;
    GameObject ScriptController;
    GameObject ScoreController;
    public GameObject Enemy;
    // Use this for initialization
    void Start () 
    {
        ScriptController = GameObject.Find("ScriptController");
        ScoreController = GameObject.Find("ScoreController");
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void OnCollisionEnter2D(Collision2D col)
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
            Enemy = col.gameObject;
            LoadGameOver();
        }
    }

    private void LoadGameOver()
    {
        ScriptController.GetComponent<Stats>().SetUpNewScene("GameOver");
        ScoreController.GetComponent<GameOverController>().enabled = true;
        GameObject.Destroy(ScriptController);
        DontDestroyOnLoad(ScoreController);

        SceneManager.LoadScene("GameOver");
    }


}

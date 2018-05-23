using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**

* I'm trying to change the damage system so it doesn't warp trump behind the left screen boundary 
* when he takes damage.
* 
* Pushes him back on first collision
* If still touching him, increase time
* If time = _damageBuffer (3 seconds or so), damage him again (but don't change his position)

 */

public class Damage : MonoBehaviour 
{
    public int Lives;
    GameObject ScriptController;
    GameObject ScoreController;
    public GameObject Enemy;
    float screenBoundaryLeft;

    void Start () 
    {
        ScriptController = GameObject.Find("ScriptController");
        ScoreController = GameObject.Find("ScoreController");

        screenBoundaryLeft = ScriptController.GetComponent<TrumpController>().screenBoundaryLeft;
        //_damageBuffer = 1;
        //_time = 0;
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (Lives > 1)
            {
                //if (_time == 0 || _time % _damageBuffer == 0)
                //{
                //    ApplyDamage();
                //}
                ApplyDamage();
                //_time += Time.deltaTime;
            }
            else // game over condition
            {
                Enemy = col.gameObject;
                LoadGameOver();
            }
        }
    }

    public void LoadGameOver()
    {
        ScriptController.GetComponent<Stats>().SetUpNewScene("GameOver");
        ScoreController.GetComponent<GameOverController>().enabled = true;
        DontDestroyOnLoad(ScoreController);
        GameObject.Destroy(ScriptController);

        SceneManager.LoadScene("GameOver");
    }

    private void ApplyDamage()
    {
        // if enemy has been touching trump for 3 seconds, damage him
        if (gameObject.transform.position.x > screenBoundaryLeft)
            ApplyForce();
        Lives--;
        ScriptController.GetComponent<Stats>().RemoveHeart(Lives);
    }

    private void ApplyForce()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y);
        //_time = 0; //resets time to just above 0
    }
}

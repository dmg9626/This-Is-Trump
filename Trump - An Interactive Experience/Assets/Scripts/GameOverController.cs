using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour 
{
    GameObject ScoreController;
	// Use this for initialization
	void Start () 
    {
        ScoreController = GameObject.Find("ScoreController");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            InstantiateGameOverObjects();
            //ScoreController.GetComponent<ScoreController>()
        }
	}

    void InstantiateGameOverObjects()
    {
        if (!GameObject.Find("DirectionalLight"))
        {
            GameObject lights = GameObject.Instantiate(Resources.Load("DirectionalLight")) as GameObject;
            lights.name = "DirectionalLight";
        }

    }


}

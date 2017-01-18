using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    GameObject ScoreController;
    GameObject ScriptController;
    private bool _hasLoaded;
    // Use this for initialization
    void Start () 
    {
        ScoreController = GameObject.Find("ScoreController");
        ScriptController = GameObject.Find("ScriptController");
        _hasLoaded = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_hasLoaded == false && SceneManager.GetActiveScene().name == "GameOver")
        {
            InstantiateGameOverObjects();
            _hasLoaded = true;
        }
	}

    void InstantiateGameOverObjects()
    {
        if (!GameObject.Find("DirectionalLight"))
        {
            GameObject lights = GameObject.Instantiate(Resources.Load("DirectionalLight")) as GameObject;
            lights.name = "DirectionalLight";
        }
        if(GameObject.Find("Background").GetComponent<BGScroll>().enabled)
        {
            GameObject.Find("Background").GetComponent<BGScroll>().Speed /= 2;
        }
        GameObject.Destroy(GameObject.Find("Music_GameMusic"));
        ScoreController.GetComponent<ScoreController>().DisplayGameOverStats();
    }
    
}

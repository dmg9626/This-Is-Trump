using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    GameObject ScoreController;
    GameObject PromptText;
    private bool _hasLoaded;
    // Use this for initialization
    void Start () 
    {
        ScoreController = GameObject.Find("ScoreController");

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
        else if(_hasLoaded == true)
        {
            InputHandler();
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

        PromptText = GameObject.Find("PromptText");
        InvokeRepeating("ToggleText", 1, .5F);
    }

    void ToggleText()
    {
        PromptText.SetActive(!PromptText.activeSelf);
    }

    void InputHandler()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LoadScene("MainMenu");
        }
    }

    void LoadScene(string sceneName)
    {
        GameObject.Destroy(ScoreController);
        GameObject.Destroy(GameObject.Find("Music_GameOverMusic"));
        SceneManager.LoadScene(sceneName);
    }
}
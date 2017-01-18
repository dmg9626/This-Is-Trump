using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    GameObject SoundController;
    GameObject StartText;
	// Use this for initialization
	void Start ()
    {
        SoundController = GameObject.Find("SoundController");
        StartText = GameObject.Find("StartText");

        DontDestroyOnLoad(SoundController);
        InvokeRepeating("ToggleText", 1, .5F);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
            LoadGame();
	}

    void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    void ToggleText()
    {
        StartText.SetActive(!StartText.activeSelf);
    }
}

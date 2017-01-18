using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    GameObject SoundController;
	// Use this for initialization
	void Start ()
    {
        SoundController = GameObject.Find("SoundController");
        DontDestroyOnLoad(SoundController);
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
}

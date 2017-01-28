using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    GameObject StartText;
    private int _soundEffectIndex = 0;
	// Use this for initialization
	void Start ()
    {
        StartText = GameObject.Find("StartText");

        InvokeRepeating("ToggleText", 1, .5F);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LoadGame();
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.W))
            gameObject.GetComponent<SoundManager>().DonaldSoundEffect();
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

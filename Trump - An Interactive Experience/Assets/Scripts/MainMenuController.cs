﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject StartText;
    public GameObject TitleText;
    public GameObject ControlsText;
    //GameObject ControlsHeaderText;
	void Start ()
    {
        InvokeRepeating("ToggleStartText", 1, .5F);
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
        if(Input.GetKeyDown(KeyCode.I))
            ToggleInstructionsText();
	}

    void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    void ToggleStartText()
    {
        StartText.SetActive(!StartText.activeSelf);
    }

    void ToggleInstructionsText()
    {
        TitleText.SetActive(!TitleText.activeSelf);
        //ControlsHeaderText.SetActive(!ControlsHeaderText.activeSelf);
        ControlsText.SetActive(!ControlsText.activeSelf);
    }
}

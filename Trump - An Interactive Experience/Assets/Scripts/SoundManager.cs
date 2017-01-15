/*
 * VERSION HISTORY:
 *  ---- 0.1.0 ----
 *      - Created the file
 *      - it can take in sound files from the prefab SoundObject, which contains every game sound as an Audio Source component
 *      
 * ---- 1.0.0 ----
 *      - It plays music!
 *      - when the mainMenu scene opens, it creates an instance of the Sound_GameMusic object which plays the music upon spawning
 *      - the music plays seamlessly between scenes
 *      - but when you return to the mainMenu scene it creates another instance of Sound_GameMusic, so there's 2 copies of the music playing at once
 * ---- 2.0.0 ----
 *      - The cows moo now!
 *      - the Moo() function creates one of 4 Sound_Moo objects that each play a different moo sound effect
 *      - random number determines which moo is chosen
 
 *  * === TO DO: ===
 *      - maybe implement other sounds (tractor beam, game start, cow missed, etc.)
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    GameObject _gameMusic;
    GameObject _gameOverMusic;

    // Use this for initialization
    void Start ()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                {
                    // calls musicGame() script to play the game music if it isn't playing already
                    GameMusic();
                    break;
                }
            case "GameOver":
                {
                    GameOverMusic();
                    break;
                }
        }

	}
    

    public void GameMusic()
    {
        if (!GameObject.Find("GameMusic"))
        {
            // creates instance of Sound_GameMusic object that plays music on loop as soon as it appears in the scene
            _gameMusic = Instantiate(Resources.Load("GameMusic")) as GameObject;
            _gameMusic.name = "GameMusic";
        }

        // don't destory SoundObject when switching scenes
        // this way if we need sound effects to happen in another scene the SoundObject will be there with its functions that make those effects play
        //DontDestroyOnLoad(GameObject.Find("SoundObject"));
    }

    public void GameOverMusic()
    {
        if (!GameObject.Find("GameOverMusic"))
        {
            _gameMusic = Instantiate(Resources.Load("GameOverMusic")) as GameObject;
            _gameMusic.name = "GameOverMusic";
        }
    }

    public void DonaldSoundEffect()
    {
        int rand = Random.Range(0, 3) + 1;
        GameObject sound = null;
        switch(rand)
        {
            case 1:
                sound = Instantiate(Resources.Load("SoundEffect_Wrong")) as GameObject;
                sound.name = "SoundEffect_Wrong";
                break;
            case 2:
                sound = Instantiate(Resources.Load("SoundEffect_BadHombres")) as GameObject;
                sound.name = "SoundEffect_BadHombres";
                break;
            case 3:
                sound = Instantiate(Resources.Load("SoundEffect_China")) as GameObject;
                sound.name = "SoundEffect_China";
                break;

        }
        Destroy(sound, sound.GetComponent<AudioSource>().clip.length);
    }

    public void Moo()
    {
        int rand = Random.Range(0, 2) + 1;
        GameObject moo;
        if (rand == 1)
        {
            moo = Instantiate(Resources.Load("Sound_Moo1")) as GameObject;
            Destroy(moo, 2);
        }
        else if (rand == 2)
        {
            moo = Instantiate(Resources.Load("Sound_Moo2")) as GameObject;
            Destroy(moo, 2);
        }
        else if (rand == 3)
        {
            moo = Instantiate(Resources.Load("Sound_Moo3")) as GameObject;
            Destroy(moo, 2);
        }
    }
}

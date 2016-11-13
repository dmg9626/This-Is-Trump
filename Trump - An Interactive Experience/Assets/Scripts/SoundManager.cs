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
using System.Collections;

public class SoundManager : MonoBehaviour
{
    GameObject GameMusic;

    // Use this for initialization
    void Start ()
    {
        // calls musicGame() script to play the game music if it isn't playing already
        if (!GameObject.Find("Sound_GameMusic(Clone)"))
        {
            musicGame();
        }
	}
    

    void musicGame()
    {
        // creates instance of Sound_GameMusic object that plays music on loop as soon as it appears in the scene
        GameMusic = Instantiate(Resources.Load("Sound_GameMusic")) as GameObject;

        // don't destroy the GameMusic object when switching scenes
        // this way the music keeps playing across scenes
        DontDestroyOnLoad(GameMusic);

        // don't destory SoundObject when switching scenes
        // this way if we need sound effects to happen in another scene the SoundObject will be there with its functions that make those effects play
        DontDestroyOnLoad(GameObject.Find("SoundObject"));
    }

    public void moo()
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

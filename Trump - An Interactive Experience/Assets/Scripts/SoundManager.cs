using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    GameObject _gameMusic;
    private int _soundEffectIndex = 0;
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
            case "MainMenu":
                {
                    GameMusic();
                    break;
                }
            case "Instructions":
                {
                    GameMusic();
                    break;
                }
        }

	}
    

    public void GameMusic()
    {
        if (!GameObject.Find("Music_GameMusic"))
        {
            // creates instance of Sound_GameMusic object that plays music on loop as soon as it appears in the scene
            _gameMusic = Instantiate(Resources.Load("GameMusic")) as GameObject;
            _gameMusic.name = "Music_GameMusic";
            DontDestroyOnLoad(_gameMusic);
        }

        // don't destory SoundObject when switching scenes
        // this way if we need sound effects to happen in another scene the SoundObject will be there with its functions that make those effects play
        //DontDestroyOnLoad(GameObject.Find("SoundObject"));
    }

    public void GameOverMusic()
    {
        if (!GameObject.Find("Music_GameOverMusic"))
        {
            _gameMusic = Instantiate(Resources.Load("GameOverMusic")) as GameObject;
            _gameMusic.name = "Music_GameOverMusic";
            DontDestroyOnLoad(_gameMusic);
        }
    }

    public void DonaldSoundEffect()
    {
        if (_soundEffectIndex < 5)
        {
            int rand = Random.Range(0, 3) + 1;
            GameObject sound = null;
            switch (rand)
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
            _soundEffectIndex++;

            Invoke("DestroyDonaldSoundEffect", sound.GetComponent<AudioSource>().clip.length);
            Destroy(sound, sound.GetComponent<AudioSource>().clip.length);
        }
    }

    public void DestroyDonaldSoundEffect()
    {
        _soundEffectIndex--;
    }
}

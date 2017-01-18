using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetAnim : MonoBehaviour {

    float _time; // iterates from each frame until the animtion is finished
    public bool _beginAnimating;
    public bool _isAnimating;
    public bool _finishedAnimating;
    public bool _canBeginAnimating; // set to true from TrumpController

    public GameObject Donald;
    public GameObject DonaldTweet;
    private GameObject ScriptController;
    Vector2 _trumpPos;
    // Use this for initialization
    void Start ()
    {
        _isAnimating = false;
        _beginAnimating = false;
        _canBeginAnimating = true;
        _finishedAnimating = false;

        ScriptController = GameObject.Find("ScriptController");
    }

    // Update is called once per frame
    void Update ()
    {
        if (_beginAnimating) 
        {
            Donald = GameObject.Find("Donald");
            _canBeginAnimating = false;
            if (!_isAnimating) 
            {
                _time = 0F;
                _trumpPos = Donald.transform.position;
                Donald.SetActive(false);
                DonaldTweet = Instantiate (Resources.Load ("DonaldTweet"), _trumpPos, Quaternion.identity) as GameObject;
                DonaldTweet.name = "DonaldTweet";

                _isAnimating = true;
                _beginAnimating = false;
                ScriptController.GetComponent<TrumpController>().CanControl = false;
            }
        }

        if (_isAnimating)
        {
            RunAnimation();
            if (_finishedAnimating)
            {
                _isAnimating = false;
                _trumpPos = DonaldTweet.transform.position;
                Destroy(DonaldTweet);
                Donald.SetActive(true);
                ScriptController.GetComponent<TrumpController>().Donald = Donald;
                _finishedAnimating = false;
                _canBeginAnimating = true;
                ScriptController.GetComponent<TrumpController>().CanControl = true;
            }
        }
    }

    void RunAnimation()
    {
        if (_time < .5F)
        {
            _time += Time.deltaTime;
        }
        else _finishedAnimating = true;
    }
}

using UnityEngine;
using System.Collections;


// this script needs to be attached to ScriptController
// when player presses W, TrumpController sets beginAnimating = true
// deletes Donald and begins animating
// after finished animating, spawns new Donald in its place and destroys self

public class Wall : MonoBehaviour
{
    float _time; // iterates from each frame until the animtion is finished
	public bool _beginAnimating;
    public bool _isAnimating;
	bool _finishedAnimating;
    public bool _canBeginAnimating; // set to true from TrumpController

    public GameObject Trump;
    public GameObject DonaldWall;
    Vector2 _trumpPos;
	// Use this for initialization
	void Start ()
    {
		_isAnimating = false;
		_beginAnimating = false;
        _canBeginAnimating = true;
        _finishedAnimating = false;

        Trump = GameObject.Find("Donald");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (_beginAnimating) 
		{
            _canBeginAnimating = false;
			if (!_isAnimating) 
			{
				_time = 0F;
				_trumpPos = Trump.transform.position;
				Destroy (Trump);
				DonaldWall = Instantiate (Resources.Load ("DonaldWall"), _trumpPos, Quaternion.identity) as GameObject;
                DonaldWall.name = "DonaldWall";

				_isAnimating = true;
				_beginAnimating = false;
			}
		}

        if (_isAnimating)
        {
            RunAnimation();
            if (_finishedAnimating)
            {
                _isAnimating = false;
                _trumpPos = DonaldWall.transform.position;
                Destroy(DonaldWall);
                Trump = Instantiate(Resources.Load("Donald"), _trumpPos, Quaternion.identity) as GameObject;
                Trump.name = "Donald";
                GameObject.Find("ScriptController").GetComponent<TrumpController>().trump = Trump;
                _finishedAnimating = false;
                _canBeginAnimating = true;
            }
        }
        
		
	}
    
    void RunAnimation()
    {
        if (_time < .75F)
        {
            _time += Time.deltaTime;
        }
        else _finishedAnimating = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(col.gameObject);

            // causing NullReferenceException
            //if (col.gameObject.name == "BadHombre")
            //{
            //    gameObject.GetComponent<Stats>().BadHombreKilled();
            //    Debug.Log("BadHombre killed");
            //}

            //if (col.gameObject.name == "CameraMan")
            //{
            //    gameObject.GetComponent<Stats>().CameraManKilled();
            //    Debug.Log("CameraMan killed");
            //}
        }
    }
}

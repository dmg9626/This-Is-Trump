using UnityEngine;
using System.Collections;


// this script needs to be attached to ScriptController
// when player presses W, TrumpController sets beginAnimating = true
// deletes Donald and begins animating
// after finished animating, spawns new Donald in its place and destroys self

public class Wall : MonoBehaviour
{
    float time; // iterates from each frame until the animtion is finished
	public bool _beginAnimating;
    public bool _isAnimating;
	bool _finishedAnimating;
    public bool _canBeginAnimating; // set to true from TrumpController

    public GameObject Trump;
    public GameObject WallTrump;
    Vector2 TrumpPos;
	// Use this for initialization
	void Start ()
    {
		_isAnimating = false;
		_beginAnimating = false;
        _canBeginAnimating = true;
        _finishedAnimating = false;

        Trump = GameObject.Find("Donald(Clone)");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (_beginAnimating) 
		{
            _canBeginAnimating = false;
			if (!_isAnimating) 
			{
				time = 0F;
				TrumpPos = Trump.transform.position;
				Destroy (Trump);
				WallTrump = Instantiate (Resources.Load ("DonaldWall"), TrumpPos, Quaternion.identity) as GameObject;

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
                TrumpPos = WallTrump.transform.position;
                Destroy(WallTrump);
                Trump = Instantiate(Resources.Load("Donald"), TrumpPos, Quaternion.identity) as GameObject;
                GameObject.Find("ScriptController").GetComponent<TrumpController>().trump = GameObject.Find("Donald(Clone)");
                _finishedAnimating = false;
                _canBeginAnimating = true;
            }
        }
        
		
	}
    
    void RunAnimation()
    {
        if (time < .75F)
        {
            time += Time.deltaTime;
        }
        else _finishedAnimating = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(col.gameObject); 
        }
    }
}

using UnityEngine;
using System.Collections;


// this script needs to be attached to ScriptController
// when player presses W, TrumpController sets 
// deletes Donald and begins animating
// after finished animating, spawns Donald in its place and destroys self

public class Wall : MonoBehaviour
{
    float time; // iterates from each frame until the animtion is finished
	public bool beginAnimating;
    public bool isAnimating;
	bool finishedAnimating;

    public GameObject Trump;
    public GameObject WallTrump;
    Vector2 TrumpPos;
	// Use this for initialization
	void Start ()
    {
		isAnimating = false;
		beginAnimating = false;
        finishedAnimating = false;

        Trump = GameObject.Find("Donald(Clone)");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (beginAnimating) 
		{
			if (!isAnimating) 
			{
				time = 0F;
				TrumpPos = Trump.transform.position;
				Destroy (Trump);
				WallTrump = Instantiate (Resources.Load ("DonaldWall"), TrumpPos, Quaternion.identity) as GameObject;

				isAnimating = true;
				beginAnimating = false;
			}
		}

        if (isAnimating)
        {
            RunAnimation();
        }
        
		if (finishedAnimating)
        {
            finishedAnimating = false;
            TrumpPos = WallTrump.transform.position;
            Destroy(WallTrump);
            Trump = Instantiate(Resources.Load("Donald"), TrumpPos, Quaternion.identity) as GameObject;
            Debug.Log("ay ylmao");
            GameObject.Find("ScriptController").GetComponent<TrumpController>().trump = GameObject.Find("Donald(Clone)");
        }
	}
    
    void RunAnimation()
    {
        if (time < .75F)
        {
            time += Time.deltaTime;
        }
        else
        {
            isAnimating = false;
			finishedAnimating = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.name == "BadHombre(Clone)" || col.gameObject.name == "CameraMan(Clone)")
        {
            GameObject.Destroy(col.gameObject); 
        }
    }
}

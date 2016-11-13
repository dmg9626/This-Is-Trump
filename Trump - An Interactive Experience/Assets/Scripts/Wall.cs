using UnityEngine;
using System.Collections;


// this script needs to be attached to WallTrump
// runs as soon as WallTrump spawns (in Donald's location)
// deletes Donald and begins animating
// after finished animating, spawns Donald in its place and destroys self

public class Wall : MonoBehaviour
{
    float time;
    bool isAnimating;
    public GameObject Trump;
    public GameObject WallTrump;
    Vector2 TrumpPos;
	// Use this for initialization
	void Start ()
    {
        BeginWall();
        AnimTimer();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isAnimating)
        {
            AnimTimer();
        }
        else
        {
            Destroy(WallTrump);
            Trump = Instantiate(Resources.Load("Donald"), TrumpPos, Quaternion.identity) as GameObject;
        }
	}

    void BeginWall()
    {
        time = 0F;
        Trump = GameObject.Find("Donald(Clone)");
        TrumpPos = Trump.transform.position;
        Destroy(Trump);
        WallTrump = Instantiate(Resources.Load("DonaldWall"), TrumpPos, Quaternion.identity) as GameObject;
    }
    
    void AnimTimer()
    {
        if(time < .8F)
        {
            time += Time.deltaTime;
        }
        else
        {
            isAnimating = false;
        }
    }
}

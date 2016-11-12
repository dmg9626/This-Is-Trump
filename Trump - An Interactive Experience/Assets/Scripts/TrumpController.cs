using UnityEngine;
using System.Collections;

public class TrumpController : MonoBehaviour
{
    public bool CanMove = true;
    public float PlayerSpeed;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - PlayerSpeed, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + PlayerSpeed, transform.position.y);
        }

    }
}

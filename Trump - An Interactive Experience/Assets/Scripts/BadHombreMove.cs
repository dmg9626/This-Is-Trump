using UnityEngine;
using System.Collections;

public class BadHombreMove : MonoBehaviour 
{
	public bool CanMove;
	public float MoveSpeed;

	// Use this for initialization
	void Start () 
	{
		CanMove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CanMove) 
		{
			transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y);
		}
	}
}

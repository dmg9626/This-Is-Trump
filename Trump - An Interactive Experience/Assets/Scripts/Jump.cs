using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public bool _isJumping;
    private float _jumpSpeed;
    private GameObject _donald;
    private GameObject _jumpingDonald;
	// Use this for initialization
	void Start ()
    {
        _isJumping = false;
        _jumpSpeed = 2;
        _donald = GameObject.Find("Donald");
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void BeginJump()
    {
        if (_isJumping == false)
        {
            _donald.transform.position = new Vector2(_donald.transform.position.x, _donald.transform.position.y * _jumpSpeed);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            _isJumping = false;
        }
    }
}

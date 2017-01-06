using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public bool _isJumping = false;
    private bool _canLand = false;
    private float _jumpSpeed = 2;
    //private float _jumpHeight;
    private GameObject _donald;
    private GameObject _jumpingDonald; // for when i make a jumping donald sprite
    private Vector2 _donaldPos;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void BeginJump()
    {
        _jumpSpeed = 2;
        if (_isJumping == false)
        {
            _donald = GameObject.Find("Donald");
            _donald.transform.position = new Vector2(_donald.transform.position.x, _donald.transform.position.y + _jumpSpeed);
            Debug.Log("jumped");
            _isJumping = true;
            _canLand = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground" && _isJumping && _canLand)
        {
            _isJumping = false;
            _donald = GameObject.Find("Donald");
            Debug.Log("Landed");
            _canLand = false;
        }
    }
}

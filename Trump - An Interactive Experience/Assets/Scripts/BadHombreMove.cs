using UnityEngine;
using System.Collections;

public class BadHombreMove : MonoBehaviour 
{
    private float _moveSpeed;
    private int _health = 2;
    private GameObject ScriptController;
    public int LowerBound = 3;
    public int UpperBound = 7;

    void Start () 
	{
        _moveSpeed = Random.Range(LowerBound, UpperBound);
        ScriptController = GameObject.Find("ScriptController");
    }
	
	// Update is called once per frame
	void Update () 
	{
        transform.position = new Vector2(transform.position.x - _moveSpeed * Time.deltaTime, transform.position.y);
        if(_health <= 0)
        {
            ScriptController.GetComponent<Stats>().BadHombreKilled();
            GameObject.Destroy(gameObject);
        }
    }

    public void SubtractHealth(int damage)
    {
        _health -= damage;
    }

    public void LevelUp()
    {
        LowerBound += 2;
        UpperBound += 2;
    }

    public void ResetLevel()
    {
        LowerBound = 3;
        UpperBound = 7;
    }
}

using UnityEngine;
using System.Collections;

public class CameraManMove : MonoBehaviour
{
    private float _moveSpeed;
    public int LowerBound = 3;
    public int UpperBound = 7;
    
    void Start()
    {
        _moveSpeed = Random.Range(LowerBound, UpperBound);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - _moveSpeed * Time.deltaTime, transform.position.y);
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

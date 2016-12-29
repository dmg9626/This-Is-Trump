﻿using UnityEngine;
using System.Collections;

public class CameraManMove : MonoBehaviour
{
    
    public float MoveSpeed;

    // Use this for initialization
    void Start()
    {
        MoveSpeed = Random.Range(3, 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y);
    }
}

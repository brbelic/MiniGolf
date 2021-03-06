﻿using UnityEngine;

public class CameraControllScript : MonoBehaviour {
    
    public SpriteRenderer aimPointer;

    public Rigidbody ball;

    // Update is called once per frame
    void Update () {

        if (ball.velocity.magnitude > 0.1)
        {
            aimPointer.enabled = false;
        }
        else
        {
            aimPointer.enabled = true;
        }

        transform.position = ball.transform.position;

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 1, 0);
        }
    }
}

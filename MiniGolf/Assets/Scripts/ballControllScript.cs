using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControllScript : MonoBehaviour {

    // Rigidbody component of the ball
    private Rigidbody ball;

    // Transform component of the CameraObject
    public Transform camTransform;

    private bool canShoot;

    // Shooting force
    public float shootForce;
    public float maxShootForce;
    public float minShootForce;

	// Use this for initialization
	void Start () {
       ball = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //We need to stop the ball if it's moving too slow
        if (ball.velocity.magnitude < 0.2)
        {
            ball.velocity = new Vector3(0, 0, 0);
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }


        if(Input.GetKey("up"))
        {
            shootForce += 10;
            if (shootForce > maxShootForce)
            {
                shootForce = maxShootForce;
            }
        }

        if (Input.GetKey("down"))
        {
            shootForce -= 10;
            if (shootForce < minShootForce)
            {
                shootForce = minShootForce;
            }
        }

        if (Input.GetButtonDown("Fire1") && /*ball.velocity.magnitude == 0*/ canShoot)
        {
            Shoot();
        } 
	}


    public void Shoot()
    {
        transform.localRotation = camTransform.localRotation;
        ball.AddRelativeForce(0,0,shootForce);
    }
}

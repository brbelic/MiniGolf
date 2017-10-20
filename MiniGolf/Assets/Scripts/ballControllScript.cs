using UnityEngine;
using UnityEngine.SceneManagement;

public class ballControllScript : MonoBehaviour {

    // Rigidbody component of the ball
    private Rigidbody ball;

    public Transform ballSpawn;

    // Transform component of the CameraObject
    public Transform camTransform;

    public static int totalStrokes;
    public int strokes = 0;
    private bool canShoot;

    // Shooting force
    public float shootForce;
    public float maxShootForce;
    public float minShootForce;

    public AudioSource ballHitSound;

    private int levelIndex;

	// Use this for initialization
	void Start () {
       ball = GetComponent<Rigidbody>();
       levelIndex = SceneManager.GetActiveScene().buildIndex;

       if (levelIndex == 0)
       {
           totalStrokes = 0;
       }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

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

        if ((Input.GetButtonDown("Fire1") && canShoot) || (Input.GetKeyDown(KeyCode.Space) && canShoot))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        transform.localRotation = camTransform.localRotation;
        ball.AddRelativeForce(0,0,shootForce);
        strokes += 1;
        totalStrokes += 1;
        ballHitSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            ResetBall();
        }
    }

    public void ResetBall()
    {
        ball.transform.position = ballSpawn.position;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}

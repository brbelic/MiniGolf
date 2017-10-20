using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillControllScript : MonoBehaviour {
    
    public Rigidbody windmill;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        windmill.transform.Rotate(0,1f,0);
    }
}

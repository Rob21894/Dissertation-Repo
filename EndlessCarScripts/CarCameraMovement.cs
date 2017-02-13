using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraMovement : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    public float offset = 6;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
    void FixedUpdate()
    {

    }
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - offset); // offset camera position 

    }
}

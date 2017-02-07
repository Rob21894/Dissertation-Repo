using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerControl>().playerHit = true;
            col.GetComponent<PlayerControl>().startFlash();
            col.GetComponent<PlayerMovement>().startSpeed -= 3.0f;
            col.GetComponent<PlayerMovement>().movementSpeed -= 2.0f;
        }
    }
}

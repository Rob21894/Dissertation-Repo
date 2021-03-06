﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start ()
    {
        player = Camera.main.transform.GetComponent<CameraMovement>().player;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.x > transform.position.x + GetComponent<BoxCollider2D>().size.x)
            Destroy(gameObject);
    }
}

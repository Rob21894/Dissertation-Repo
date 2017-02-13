using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Deactivate : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        player = Camera.main.transform.GetComponent<CarCameraMovement>().player;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.z >= gameObject.transform.position.z + 50.0f)
            gameObject.SetActive(false); // deactive gameobject to add back to recycler
	}
}

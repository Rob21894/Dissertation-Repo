using UnityEngine;
using System.Collections;

public class PlatformDeactivate : MonoBehaviour {

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
            gameObject.SetActive(false);
	}
}

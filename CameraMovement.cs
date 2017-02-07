using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x + 6, transform.position.y, -10);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlatformGeneration : MonoBehaviour {

    public GameObject[] platforms;
    public GameObject player;
    public Transform generationPoint;
    // Use this for initialization
    void Start ()
    {
        generationPoint = GameObject.Find("GenerationPoint").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {


            if (transform.position.x <= generationPoint.position.x)
            {

                GameObject newplatform = Instantiate(platforms[Random.Range(0, platforms.Length)], transform.position, Quaternion.identity);
                transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2), transform.position.y);
                newplatform.transform.position = transform.position;
                newplatform.transform.rotation = transform.rotation;
                newplatform.SetActive(true);
                transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2), transform.position.y);

            }
        
    }
}

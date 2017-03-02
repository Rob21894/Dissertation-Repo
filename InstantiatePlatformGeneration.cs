using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlatformGeneration : MonoBehaviour {

    public GameObject[] platforms;
    public GameObject player;
    public Transform generationPoint;

    public float xSize;
    // Use this for initialization
    void Start ()
    {
        generationPoint = GameObject.Find("GenerationPoint").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {


        //    if (transform.position.x <= generationPoint.position.x)
        //    {

        //        GameObject newplatform = Instantiate(platforms[Random.Range(0, platforms.Length)], transform.position, Quaternion.identity);
        //        transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2) + newplatform.GetComponent<BoxCollider2D>().offset.x, transform.position.y);
        //        newplatform.transform.position = transform.position;
        //        newplatform.transform.rotation = transform.rotation;
        //        newplatform.SetActive(true);
        //        transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2) + newplatform.GetComponent<BoxCollider2D>().offset.x, transform.position.y);

        //}

         if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject newplatform = Instantiate(platforms[Random.Range(0, platforms.Length)], transform.position, Quaternion.identity);
            transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2) + (newplatform.GetComponent<BoxCollider2D>().offset.x * -1) + (xSize * 1), transform.position.y);
            Debug.Log((newplatform.GetComponent<BoxCollider2D>().offset.x * 1) + (xSize * 1));
            newplatform.transform.position = transform.position;
            newplatform.transform.rotation = transform.rotation;
            newplatform.SetActive(true);
            xSize = 0;
            xSize = newplatform.GetComponent<BoxCollider2D>().offset.x;
            transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2), transform.position.y);
        }
        
    }
}

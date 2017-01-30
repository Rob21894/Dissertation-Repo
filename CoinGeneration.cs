using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour {

    public GameObject[] coinPrefabs;
    public GameObject player;

    private Transform generationPoint;
	// Use this for initialization
	void Start ()
    {
        player = Camera.main.transform.GetComponent<CameraMovement>().player;
        generationPoint = GameObject.Find("GenerationPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= generationPoint.position.x)
        {
            GameObject go = Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)], new Vector3(Random.Range(generationPoint.transform.position.x, generationPoint.transform.position.x + 50.0f), Random.Range(-3.0f, -1.0f), transform.position.z), Quaternion.identity);
            transform.position = go.transform.position;
        }

    }
}

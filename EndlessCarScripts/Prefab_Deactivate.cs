using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Deactivate : MonoBehaviour {

    public GameObject player;

    public GameObject[] gameObjects;
    public Vector3[] positions;
    public Quaternion[] rotations;

    public bool reset = false;
    public bool runOnce = false;
	// Use this for initialization
	void Start () {
        player = Camera.main.transform.GetComponent<CarCameraMovement>().player;
        positions = new Vector3[gameObjects.Length];
        rotations = new Quaternion[gameObjects.Length];
        //for (int i = 0; i < gameObjects.Length; i++)
        //{
        //    positions[i] = gameObjects[i].transform.position;
        //    rotations[i] = gameObjects[i].transform.rotation;
        //}
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.activeInHierarchy && !reset)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                positions[i] = gameObjects[i].transform.position;
                rotations[i] = new Quaternion(0, 0, 0, 0);
                gameObjects[i].GetComponent<Rigidbody>().isKinematic = false;
            }
            reset = true;
        }
        if (player.transform.position.z >= gameObject.transform.position.z + 100.0f && !runOnce)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].transform.position = positions[i];
                gameObjects[i].transform.rotation = rotations[i];
                gameObjects[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            runOnce = true;
          //  gameObject.SetActive(false); // deactive gameobject to add back to recycler
        }

        if (player.transform.position.z >= gameObject.transform.position.z + 150.0f)
        {
            reset = false; ;
            runOnce = false;
             gameObject.SetActive(false); // deactive gameobject to add back to recycler
        }
    }
}

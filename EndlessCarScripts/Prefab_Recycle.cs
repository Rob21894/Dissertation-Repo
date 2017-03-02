using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Prefab_Recycle : MonoBehaviour {

    public GameObject pooledObject;
    public int amountToPool;
    ObjectPooling_Prefabs prefabGeneration;

    public List<GameObject> pooledPrefabs;
    private List<GameObject> tempPooledPrefabs;



    void Start()
    {
        prefabGeneration = gameObject.GetComponent<ObjectPooling_Prefabs>();
        pooledPrefabs = new List<GameObject>();
        tempPooledPrefabs = new List<GameObject>();

        for (int i = 0; i < prefabGeneration.PlatformPools.Length; i++)
        {
            for (int j = 0; j < prefabGeneration.PlatformPools[i].amountToPool; j++) // Grab the amountToPool for each addition to the class
            {
                GameObject obj = (GameObject)Instantiate(prefabGeneration.PlatformPools[i].prefab[Random.Range(0, prefabGeneration.PlatformPools[i].prefab.Length)],transform.position,Quaternion.Euler(-90,0,0));
                obj.SetActive(false);
                pooledPrefabs.Add(obj);
            }
        }

        for (int i = 0; i < pooledPrefabs.Count; i++)
        {
            if (!pooledPrefabs[i].activeInHierarchy)
            {
                tempPooledPrefabs.Add(pooledPrefabs[i]); // Store all the current inactive gameObejcts into an list to be used later
            }
        }

    }


    public GameObject grabRecycledObject()
    {
        tempPooledPrefabs.Clear(); // clear the list to add the new currently deactivated gameobjects
        for (int i = 0; i < pooledPrefabs.Count; i++)
        {
            if (!pooledPrefabs[i].activeInHierarchy) // check if they're not active in the hierarhy
            {
                tempPooledPrefabs.Add(pooledPrefabs[i]); // add back to new list
            }
        }


        if (tempPooledPrefabs.Count > 0) // if newList or newjumplist count is over 1
        {
            GameObject go; // create empty gameobject
            go = tempPooledPrefabs[Random.Range(0, tempPooledPrefabs.Count)]; // grab a random platform from the list
            return go; // return the gameobject
        }

        /* if there is not enough deactivated gameobjects in the heriarchy, the code below will be triggered and return a platform to avoid problems*/

        GameObject obj = (GameObject)Instantiate(pooledObject, transform.position, Quaternion.Euler(-90, 0, 0));
        obj.SetActive(false);
        pooledPrefabs.Add(obj);
        return obj;
    }

    public GameObject GrabLastObject(GameObject go)
    {
        GetComponent<ObjectPooling_Prefabs>()._lastObjectPos = go.transform.position;
        return go;
 
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformRecycle : MonoBehaviour {

    public GameObject player;
    public GameObject pooledObject;
    public int amountToPool;
    PlatformGeneration platformGeneration;

    public List<GameObject> newlist;
    public List<GameObject> newJumplist;
    // Use this for initialization
    public List<GameObject> pooledPlatforms;
    public List<GameObject> pooledJumpPlatforms;



    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        platformGeneration = gameObject.GetComponent<PlatformGeneration>();
        pooledPlatforms = new List<GameObject>();

        for (int i = 0; i < platformGeneration.PlatformPools.Length; i++)
        {
          for (int j = 0; j < platformGeneration.PlatformPools[i].amountToPool; j++) // Grab the amountToPool for each addition to the class
            {
                GameObject obj = (GameObject)Instantiate(platformGeneration.PlatformPools[i].platforms[Random.Range(0, platformGeneration.PlatformPools[i].platforms.Length)]);
                obj.SetActive(false);
                pooledPlatforms.Add(obj);
            }
        }

        for (int i = 0; i < pooledPlatforms.Count; i++)
        {
            if (!pooledPlatforms[i].activeInHierarchy)
            {
                newlist.Add(pooledPlatforms[i]); // Store all the current inactive gameObejcts into an list to be used later
            }
        }

        for (int i = 0; i < platformGeneration.jumpPlatforms.Length; i++)
        {
            {
                for (int j = 0; j < platformGeneration.amountOfJumpPlatformsToPool; j++)
                {
                    GameObject obj = (GameObject)Instantiate(platformGeneration.jumpPlatforms[Random.Range(0, platformGeneration.jumpPlatforms.Length)]);
                    obj.SetActive(false);
                    pooledJumpPlatforms.Add(obj);
                }
            }
        }

        for (int i = 0; i < pooledJumpPlatforms.Count; i++)
        {
            if (!pooledJumpPlatforms[i].activeInHierarchy)
            {
                newJumplist.Add(pooledJumpPlatforms[i]);
            }
        }

    }
	

    public GameObject grabRecycledObject()
    {
        newlist.Clear(); // clear the list to add the new currently deactivated gameobjects
        newJumplist.Clear();
        for (int i = 0; i < pooledPlatforms.Count; i++)
        {
            if (!pooledPlatforms[i].activeInHierarchy) // check if they're not active in the hierarhy
            {
                newlist.Add(pooledPlatforms[i]); // add back to new list
            }
        }
        
            for (int i = 0; i < pooledJumpPlatforms.Count; i++)
            {
                if (!pooledJumpPlatforms[i].activeInHierarchy)
                {
                    newJumplist.Add(pooledJumpPlatforms[i]);
                }
            }

        if (newlist.Count > 0 || newJumplist.Count > 0) // if newList or newjumplist count is over 1
        {
            GameObject go; // create empty gameobject

            if (!platformGeneration.jumpPlatformSpawned) // if a jump platform has not been spanwed
            {
                go = newlist[Random.Range(0, newlist.Count)]; // grab a random platform from the list
                return go; // return the gameobject
            }
            else if (platformGeneration.jumpPlatformSpawned)
            {
                go = newJumplist[Random.Range(0, newJumplist.Count)];
                if (go.activeInHierarchy)
                {
                    newJumplist.Remove(go);
                    go = newJumplist[Random.Range(0, newJumplist.Count)];
                }
                return go;
            }
        }

        /* if there is not enough deactivated gameobjects in the heriarchy, the code below will be triggered and return a platform to avoid problems*/
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledPlatforms.Add(obj);
        return obj;
    }

    public GameObject GrabLastObject(GameObject go)
    {
        return go;
    }
}

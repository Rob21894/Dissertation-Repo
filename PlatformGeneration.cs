using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformGeneration : MonoBehaviour {

    public GameObject[] platforms;
   // public List<GameObject> platformList = new List<GameObject>();
    public GameObject player;
    public Transform generationPoint;
    public float minX = 7.0f;
    public float maxX = 10.0f;
    private float randDist;

    public PlatformRecycle platformRecycle;
   
    public float width;
    GameObject lastobj;
    public platformPools[] PlatformPools;
    [HideInInspector]
    public bool jumpPlatformSpawned;

    public GameObject[] jumpPlatforms;
    public int amountOfJumpPlatformsToPool;
    [System.Serializable]
    public class platformPools
    {
        public string platFormType;
        public GameObject[] platforms;
        public int amountToPool;
    }
	// Use this for initialization
	void Start () {
        generationPoint = GameObject.Find("GenerationPoint").transform;
        GameObject go = platformRecycle.grabRecycledObject();
        platformRecycle = GetComponent<PlatformRecycle>();
        go.transform.position = new Vector2(transform.position.x, transform.position.y);
        lastobj = go;
        platformRecycle.GrabLastObject(lastobj);
        transform.position = new Vector2(transform.position.x + (go.GetComponent<BoxCollider2D>().size.x / 2), transform.position.y);
        go.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Spawn();
        
	}

    public void Spawn()
    {
        if (player.GetComponent<PlayerControl>().playerStates == PlayerControl.playerState.Running)
        {

            if (transform.position.x <= generationPoint.position.x && !jumpPlatformSpawned)
            {
                
                randDist = Random.Range(minX, maxX);
                GameObject newplatform = platformRecycle.grabRecycledObject();
                transform.position = new Vector2(transform.position.x + newplatform.GetComponent<BoxCollider2D>().offset.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2) + randDist, Random.Range(-3.18f,-5.22f));
                newplatform.transform.position = transform.position;
                newplatform.transform.rotation = transform.rotation;
                checkCoinsActive(newplatform);
                newplatform.SetActive(true);
                lastobj = newplatform;
                platformRecycle.GrabLastObject(lastobj);
                transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2), transform.position.y);
                if (newplatform.GetComponent<Jumpplatform>() != null)
                    jumpPlatformSpawned = true;
            }
            else if (transform.position.x <= generationPoint.position.x && jumpPlatformSpawned)
            {
                randDist = Random.Range(1f, 15.0f);
                GameObject newplatform = platformRecycle.grabRecycledObject();
                transform.position = new Vector2(transform.position.x  + (newplatform.GetComponent<BoxCollider2D>().size.x / 2) + randDist, transform.position.y);
                newplatform.transform.position = transform.position;
                newplatform.transform.rotation = transform.rotation;
                checkCoinsActive(newplatform);
                newplatform.SetActive(true);
                lastobj = newplatform;
                platformRecycle.GrabLastObject(lastobj);
                transform.position = new Vector2(transform.position.x + (newplatform.GetComponent<BoxCollider2D>().size.x / 2), transform.position.y);
                jumpPlatformSpawned = false;
            }
        }
    }



    public void checkCoinsActive(GameObject obj)
    {
        // makes sure all coins are active upon activation
        Transform[] coins = obj.transform.gameObject.GetComponentInChildren<Transform>().gameObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform go in coins)
        {
            go.transform.gameObject.SetActive(true);
        }
    }
}

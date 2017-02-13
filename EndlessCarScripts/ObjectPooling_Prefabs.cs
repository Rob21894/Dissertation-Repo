using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling_Prefabs : MonoBehaviour {

    // public List<GameObject> platformList = new List<GameObject>();
    public GameObject player;
    public Transform generationPoint;
    public float minX = 7.0f;
    public float maxX = 10.0f;
    private float randDist;

    public Prefab_Recycle prefabRecycle;

    public float width;
    GameObject lastobj;

    [System.Serializable]
    public class platformPools
    {
        public string prefabType;
        public GameObject[] prefab;
        public int amountToPool;
    }

    public platformPools[] PlatformPools;
    // Use this for initialization
    void Start()
    {
        generationPoint = GameObject.Find("GenerationPoint").transform;
        GameObject go = prefabRecycle.grabRecycledObject();
        prefabRecycle = GetComponent<Prefab_Recycle>();
        go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (go.GetComponent<BoxCollider>().size.y / 2) + go.GetComponent<BoxCollider>().center.y);
        Debug.Log(transform.position.z + (go.GetComponent<BoxCollider>().size.y / 2) + go.GetComponent<BoxCollider>().center.y);
        lastobj = go;
        prefabRecycle.GrabLastObject(lastobj);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + go.GetComponent<BoxCollider>().size.y);
        go.SetActive(true);
        //    go.transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z + (go.GetComponent<BoxCollider>().center.y + go.GetComponent<BoxCollider>().size.y / 2));
        //    lastobj = go;
        //    prefabRecycle.GrabLastObject(lastobj);
        //    transform.position = new Vector3(transform.position.x, transform.position.y,(go.GetComponent<BoxCollider>().center.y + go.GetComponent<BoxCollider>().size.y / 2));
        //    go.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();

    }

    public void Spawn()
    {
       // if (player.GetComponent<PlayerControl>().playerStates == PlayerControl.playerState.Running)
      //  {

            if (transform.position.z <= generationPoint.position.z)
            {

            //randDist = Random.Range(minX, maxX);
            //GameObject newplatform = prefabRecycle.grabRecycledObject();
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (newplatform.GetComponent<BoxCollider>().center.y + newplatform.GetComponent<BoxCollider>().size.y / 2));
            //newplatform.transform.position = transform.position;
            //newplatform.transform.rotation = transform.rotation;
            //newplatform.SetActive(true);
            //lastobj = newplatform;
            //prefabRecycle.GrabLastObject(lastobj);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (newplatform.GetComponent<BoxCollider>().center.y + newplatform.GetComponent<BoxCollider>().size.y / 2));
        }

            if (Input.GetKeyDown(KeyCode.Return))
        {
            randDist = Random.Range(minX, maxX);
            GameObject newplatform = prefabRecycle.grabRecycledObject();
            newplatform.transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z + (newplatform.GetComponent<BoxCollider>().size.y / 2) + newplatform.GetComponent<BoxCollider>().center.y);
            newplatform.transform.position = transform.position;
            newplatform.transform.rotation = transform.rotation;
            newplatform.SetActive(true);
            lastobj = newplatform;
            prefabRecycle.GrabLastObject(lastobj);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + newplatform.GetComponent<BoxCollider>().size.y);
        }
       // }
    }
}

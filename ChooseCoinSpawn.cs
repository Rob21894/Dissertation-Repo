using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCoinSpawn : MonoBehaviour {

    public GameObject[] coinSpawns;
    public GameObject[] coins;
	// Use this for initialization

    void Awake()
    {
       // coins[Random.Range(0, coins.Length)].transform.position = coinSpawns[Random.Range(0, coinSpawns.Length)].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

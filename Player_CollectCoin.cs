using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollectCoin : MonoBehaviour {

    public int coinsCollected = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            col.gameObject.GetComponent<Animator>().SetBool("PickedUp", true);
            coinsCollected += 1;
        }
    }
}

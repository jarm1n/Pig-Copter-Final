using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    private GameObject console;

	// Use this for initialization
	void Start () {
        console = GameObject.FindGameObjectWithTag("Console");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            console.GetComponent<Console>().UpdateGold(10);
            Destroy(this.gameObject);
        }
    }
}

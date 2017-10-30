using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoundaryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Mouse")
        {
            Destroy(col.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {

    public GameObject warning, i;

	// Use this for initialization
	void Start () {
        Vector2 pos = new Vector2(this.transform.position.x, 4.9397f);
        i = Instantiate(warning, pos, this.transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (i!=null)
        {
            if (this.gameObject.transform.position.y < i.transform.position.y)
                Destroy(i);
        }
	}
}

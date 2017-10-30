using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

    private float fallSpeed;
    private float size;

	// Use this for initialization
	void Start () {

        fallSpeed = Random.Range(1, 4);
        size = Random.Range(0.02f, 0.1f);
        this.transform.localScale = new Vector2(size, size);

	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

	}
}

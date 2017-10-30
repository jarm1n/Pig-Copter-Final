using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour {

    public float fallSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorBlades : MonoBehaviour {

    public float speed;
    public float rotX;
    private float rot;

	// Use this for initialization
	void Start () {

        rot = this.transform.rotation.y;

	}
	
	// Update is called once per frame
	void Update () {

        rot += speed;
        this.transform.rotation = Quaternion.Euler(rotX, rot, this.transform.rotation.z);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class TiltTest : MonoBehaviour {

    public GameObject text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float rotation = CrossPlatformInputManager.GetAxis("Horizontal")*180;
        Debug.Log(rotation);
        text.GetComponent<Text>().text = rotation.ToString();
	}
}

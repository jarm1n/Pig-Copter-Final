using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

    public bool fadeIn;
    public bool fadeOut;

    public float speed, min, max;
    public float opacity = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (opacity >= max)
        {
            fadeIn = false;
            fadeOut = true;
        }
        else if (opacity <= min)
        {
            fadeIn = true;
            fadeOut = false;
        }

        if (fadeIn)
        {
            opacity += speed;
        }
        else if (fadeOut)
        {
            opacity -= speed;
        }

        Color color = new Color(this.GetComponent<Image>().color.r,
            this.GetComponent<Image>().color.g,
            this.GetComponent<Image>().color.b,
            opacity);

        this.GetComponent<Image>().color = color;
	}

    
}

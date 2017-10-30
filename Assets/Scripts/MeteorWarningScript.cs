using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorWarningScript : MonoBehaviour {

    public float opacity, fadeSpeed;
    public bool fadeIn, fadeOut;

	// Use this for initialization
	void Start () {
        opacity = this.GetComponent<SpriteRenderer>().color.a;
	}
	
	// Update is called once per frame
	void Update () {
        if (opacity <= 0)
            fadeIn = true;
        else if (opacity >= 1)
            fadeIn = false;

        if (fadeIn)
            opacity += (fadeSpeed / 5);
        else
            opacity -= (fadeSpeed / 5);

        Color newColor = new Color(this.GetComponent<SpriteRenderer>().color.r,
            this.GetComponent<SpriteRenderer>().color.g,
            this.GetComponent<SpriteRenderer>().color.b,
            opacity);

        this.GetComponent<SpriteRenderer>().color = newColor;
    }
}

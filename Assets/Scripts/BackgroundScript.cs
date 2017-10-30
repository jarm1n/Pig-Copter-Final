using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    public float speed;
    private Color normalColor;
    public float r, g, b;
    private GameObject console;

	// Use this for initialization
	void Start () {
        normalColor = this.GetComponent<SpriteRenderer>().color;
        r = this.GetComponent<SpriteRenderer>().color.r;
        g = this.GetComponent<SpriteRenderer>().color.g;
        b = this.GetComponent<SpriteRenderer>().color.b;
        console = GameObject.FindGameObjectWithTag("Console");
    }
	
	// Update is called once per frame
	void Update () {

        if (console.GetComponent<Console>().inGame)
        {
            if (r > 0)
                r -= speed;
            if (g > 0)
                g -= speed;
            if (b > 0)
                b -= speed;

            Color color = new Color(r, g, b, 1);

            this.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = normalColor;
            r = this.GetComponent<SpriteRenderer>().color.r;
            g = this.GetComponent<SpriteRenderer>().color.g;
            b = this.GetComponent<SpriteRenderer>().color.b;
        }
	}
}

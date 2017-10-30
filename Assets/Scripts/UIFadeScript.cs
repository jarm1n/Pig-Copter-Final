using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeScript : MonoBehaviour {

    public float opacity;
    private float OPACITY;
    public bool text, image;

	// Use this for initialization
	void Start () {
        if (image)
            OPACITY = this.GetComponent<Image>().color.a;
        else if (text)
            OPACITY = this.GetComponent<Text>().color.a;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateOpacity()
    {
        if (image)
        {
            Color newColor = new Color(this.GetComponent<Image>().color.r
                    , this.GetComponent<Image>().color.g
                    , this.GetComponent<Image>().color.b
                    , opacity);
            this.GetComponent<Image>().color = newColor;
        }
        if (text)
        {
            Color newColor = new Color(this.GetComponent<Text>().color.r
                    , this.GetComponent<Text>().color.g
                    , this.GetComponent<Text>().color.b
                    , opacity);
            this.GetComponent<Text>().color = newColor;
        }
    }

    public void FadeIn()
    {
        opacity = OPACITY;
        UpdateOpacity();
    }

    public void FadeOut()
    {
        opacity = 0;
        UpdateOpacity();
    }
}

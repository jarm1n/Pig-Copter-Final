using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPanel : MonoBehaviour {

    public bool mouseReleased = true;
    public float setX = 0;
    public float oldX = 0;
    public float minX, maxX;

	// Use this for initialization
	void Start () {
        Debug.Log(transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0) && mouseReleased)
        {
            setX = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            oldX = this.transform.position.y;
            mouseReleased = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleased = true;
        }

        if (!mouseReleased)
        {
            float diff = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - setX;
            float newX = oldX + diff;

            if (newX <= minX)
                newX = minX;
            if (newX >= maxX)
                newX = maxX;

            this.transform.position = new Vector2(this.transform.position.x, newX);
        }

	}
}

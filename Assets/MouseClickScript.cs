using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickScript : MonoBehaviour {

    public bool mouseReleased = true;
    public Vector2 oldPos;
    public GameObject storeControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && mouseReleased)
        {
            oldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseReleased = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleased = true;

            if (oldPos.x <= Camera.main.ScreenToWorldPoint(Input.mousePosition).x+0.1f && oldPos.x >= Camera.main.ScreenToWorldPoint(Input.mousePosition).x - 0.1f)
                this.GetComponent<BoxCollider2D>().enabled = true;
        }

        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            Debug.Log("SELECT ITEM");
            storeControl.GetComponent<StoreController>().SelectItem(col.gameObject);
        }

        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}

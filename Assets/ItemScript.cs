using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour {

    public int cost, skinID;
    public bool owned;
    public GameObject costText;
    public Sprite sprite;


	// Use this for initialization
	void Start () {
		
	}

    public void SetToOwned()
    {
        owned = true;
        costText.GetComponent<Text>().text = "OWNED";
    }

    public void SetToEquipped()
    {
        costText.GetComponent<Text>().text = "EQUIP";
    }
}

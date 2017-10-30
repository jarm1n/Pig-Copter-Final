using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class StoreController : MonoBehaviour {

    public GameObject selectedItem;
    private GameObject console;

	// Use this for initialization
	void Start () {
        console = GameObject.FindGameObjectWithTag("Console");
	}
	
	// Update is called once per frame
	void Update () {

        if (CrossPlatformInputManager.GetButtonUp("EquipItem"))
        {
            EquipItem();
        }
        if (CrossPlatformInputManager.GetButtonUp("StorePurchase"))
        {
            PurchaseItem();
        }
        if (CrossPlatformInputManager.GetButtonUp("StoreBack"))
        {
            console.GetComponent<Console>().ChangeView(0);
        }
	}

    public void PurchaseItem()
    {
        GameObject item = selectedItem;
        if (!item.GetComponent<ItemScript>().owned)
        {
            //Purchase
            int cost = item.GetComponent<ItemScript>().cost;
            int gold = console.GetComponent<Console>().gold;

            if (cost<=gold)
            {
                console.GetComponent<Console>().UpdateGold(-cost);
                item.GetComponent<ItemScript>().SetToOwned();
            }
        }
    }

    public void EquipItem()
    {
        GameObject item = selectedItem;
        if (item.GetComponent<ItemScript>().owned)
        {
            item.GetComponent<ItemScript>().SetToEquipped();
            console.GetComponent<Console>().ChangePlayerSkin(item);
        }
    }

    public void SelectItem(GameObject item)
    { 
        selectedItem = item;
    }
}

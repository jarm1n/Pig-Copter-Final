using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public GameObject console, energyIndicator;
    private Vector2 startPos;
    public Slider energySlider;
    public float energy, energyLossRate;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
        console = GameObject.FindGameObjectWithTag("Console");
	}
	
	// Update is called once per frame
	void Update () {

        if (console.GetComponent<Console>().inGame)
        {
            energy -= energyLossRate;
            energySlider.value = energy;
            if (energy <= 0)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
                console.GetComponent<Console>().GameOver();
            }
            if (energy <= 30)
            {
                energyIndicator.GetComponent<Image>().enabled = true;
            }
            else
            {
                energyIndicator.GetComponent<Image>().enabled = false;
            }
        }
	}

    public void EatApple()
    {
        energy += 25;
        if (energy > 100)
            energy = 100;
    }

    public void Reset()
    {
        energy = 100;
        this.transform.parent.transform.position = new Vector2(0, -6.37f);
        this.transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.GetComponentInChildren<Rigidbody2D>().velocity= new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.transform.position = startPos;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //GAMEOVER
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            console.GetComponent<Console>().GameOver();
        }
    }
}

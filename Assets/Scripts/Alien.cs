using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public float speed;
    public GameObject player;
    public float rotZ;
    public float rotSpeed;

	// Use this for initialization
	void Start () {
        //parent = this.transform.parent.gameObject;
        rotZ = -90;
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.parent = null;
    }
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.y > player.transform.position.y)
        {
            RotateToPlayer();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

	}

    public void RotateToPlayer()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        if (angle < -100)
        {
            angle = -100;
        }
        else if (angle > -40)
            angle = -70;

        if (angle < rotZ)
        {
            rotZ -= rotSpeed;
        }
        else
        {
            rotZ += rotSpeed;
        }

        Quaternion q = Quaternion.AngleAxis(rotZ, Vector3.forward);
        transform.rotation = q;
    }
}

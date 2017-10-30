using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleScript : MonoBehaviour {

    private GameObject player, parent;
    private Vector2 waitAtPoint;
    private float readyTimer;
    public bool isReady = false;
    public float fallSpeed, speed, readyTimeMin, readyTimeMax;


	// Use this for initialization
	void Start () {
        waitAtPoint.x = this.transform.position.x;
        waitAtPoint.y = Random.RandomRange(2.5f, 4.4f);
        readyTimer = Random.RandomRange(readyTimeMin, readyTimeMax);
        player = GameObject.FindGameObjectWithTag("Player");

        //Store parent then detach from parent
        parent = this.transform.parent.gameObject;
        this.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (!isReady)
        {
            if (parent.gameObject != null)
            {
                if (parent.transform.position.y > waitAtPoint.y)
                {
                    this.transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
                }
                else
                {
                    readyTimer -= Time.deltaTime;
                    if (readyTimer <= 0)
                    {
                        RotateToPlayer();
                        isReady = true;
                    }
                }
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
	}

    public void RotateToPlayer()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

    public GameObject star;
    private GameObject console;
    public float spawnMin, spawnMax;

    private Vector2 position;
    private float spawnTimer;

    // Use this for initialization
    void Start()
    { 
        resetSpawnTimer();
        console = GameObject.FindGameObjectWithTag("Console");
        position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (console.GetComponent<Console>().distance > 2500 && console.GetComponent<Console>().inGame)
            {
                position.x = Random.Range(-2.8f, 2.8f);
                position.y = Random.Range(5, 7);
                Instantiate(star, position, this.transform.rotation);
            }
            resetSpawnTimer();
        }

    }

    public void resetSpawnTimer()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }
}

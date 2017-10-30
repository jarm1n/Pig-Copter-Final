using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject[] cloud;
    private GameObject console;
    public int layer;
    public float spawnMin, spawnMax;

    private Vector2 position;

    private float spawnTimer;
    private float[] layerSpawnChance = new float[] { 50, 80, 100 };

	// Use this for initialization
	void Start () {

        resetSpawnTimer();
        console = GameObject.FindGameObjectWithTag("Console");

	}
	
	// Update is called once per frame
	void Update () {

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (console.GetComponent<Console>().distance<1700 || !console.GetComponent<Console>().inGame)
            {
                int layer = pickRandomLayer();
                position = new Vector2(Random.Range(-6, 0), Random.Range(8, 10));

                GameObject newCloud = Instantiate(cloud[Random.Range(0, 4)], position, this.transform.rotation) as GameObject;
                newCloud.GetComponent<CloudScript>().setLayer(layer);
            }

            resetSpawnTimer();
        }

	}

    public int pickRandomLayer()
    {
        int rand = Random.Range(0, 100);

        for (int i=0;i<layerSpawnChance.Length;i++)
        {
            if (rand<layerSpawnChance[i])
            {
                return i;
            }
        }

        return 0;
    }

    public void resetSpawnTimer()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }
}

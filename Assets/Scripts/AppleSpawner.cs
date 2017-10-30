using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject apple, coin, boost;
    private GameObject console;
    public float coinSpawnTimer;
    public float coinSpawnGap, appleTimeMin, appleTimeMax;
    public float boostTimeMin, boostTimeMax;
    private float COINSPAWNGAP, appleSpawnTime, boostSpawnTime;

    public bool spawnCoins = false;
    public bool runZigZag = false;
    public bool running = false;

    public int spawner = 0;
    int counter = 0;
    public int appleCount = 0;
    public int coinsToSpawn = 0;

    bool countUp = true;
    public int startAt, endAt;

	// Use this for initialization
	void Start () {
        COINSPAWNGAP = coinSpawnGap;
        appleSpawnTime = Random.RandomRange(appleTimeMin, appleTimeMax);
        boostSpawnTime = Random.RandomRange(boostTimeMin, boostTimeMax);
        console = GameObject.FindGameObjectWithTag("Console");
	}
	
	// Update is called once per frame
	void Update () {

        if (console.GetComponent<Console>().inGame)
        {
            coinSpawnTimer -= Time.deltaTime;
            appleSpawnTime -= Time.deltaTime;
            boostSpawnTime -= Time.deltaTime;

            if (boostSpawnTime <= 0)
            {
                SpawnCollectible(boost);
                boostSpawnTime = Random.RandomRange(boostTimeMin, boostTimeMax);
            }

            if (appleSpawnTime <= 0)
            {
                SpawnCollectible(apple);
                appleSpawnTime = Random.RandomRange(appleTimeMin, appleTimeMax);
            }

            if (coinSpawnTimer <= 0)
            {
                coinSpawnTimer = Random.RandomRange(4, 7);
                spawnCoins = true;
            }

            if (spawnCoins)
            {
                int method = Random.RandomRange(0, 2);

                switch (method)
                {
                    case 0:
                        runZigZag = true;
                        coinsToSpawn = Random.RandomRange(5, 10);
                        startAt = Random.RandomRange(0, 3);
                        endAt = Random.RandomRange(startAt + 2, 5);

                        if (Random.RandomRange(0, 2) == 0)
                            spawner = startAt;
                        else
                            spawner = endAt;
                        break;
                    case 1:

                        break;
                    default:
                        break;
                }

                spawnCoins = false;
            }

            if (runZigZag && coinsToSpawn > 0)
            {
                coinSpawnGap -= Time.deltaTime;
                if (spawner > endAt - 1)
                    countUp = false;
                else if (spawner < startAt + 1)
                    countUp = true;

                if (coinSpawnGap <= 0)
                {
                    SpawnCoinAt(spawner);
                    coinsToSpawn -= 1;
                    coinSpawnGap = COINSPAWNGAP;

                    if (countUp)
                        spawner++;
                    else
                        spawner--;
                }

                if (coinsToSpawn == 0)
                    coinSpawnTimer = Random.RandomRange(3, 5);
            }
        }
	}

    public void SpawnCollectible(GameObject item)
    {
        Vector2 pos;
        pos.y = this.transform.position.y;
        pos.x = Random.RandomRange(-2.5f, 2.5f);

        Instantiate(item, pos, this.transform.rotation);
    }

    public void SpawnCoinAt(int spawner)
    {
        Instantiate(coin, spawners[spawner].transform.position, this.transform.rotation);
    }


}

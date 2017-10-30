using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawnController : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject apple, coin;
    public float spawnApplesTimer;
    public float spawnTimeGap;
    private float SPAWNTIMEGAP;

    public bool spawnApples = false;
    public bool runZigZag = false;
    public bool running = false;

    public int spawner = 0;
    int counter = 0;
    public int appleCount = 0;
    public int applesToSpawn = 0;

    bool countUp = true;
    public int startAt, endAt;

    // Use this for initialization
    void Start()
    {
        SPAWNTIMEGAP = spawnTimeGap;
    }

    // Update is called once per frame
    void Update()
    {

        spawnApplesTimer -= Time.deltaTime;
        if (spawnApplesTimer <= 0)
        {
            spawnApplesTimer = Random.RandomRange(8, 11);
            spawnApples = true;
        }

        if (spawnApples)
        {
            int method = Random.RandomRange(0, 2);

            switch (method)
            {
                case 0:
                    runZigZag = true;
                    applesToSpawn = Random.RandomRange(5, 10);
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

            spawnApples = false;
        }

        if (runZigZag && applesToSpawn > 0)
        {
            spawnTimeGap -= Time.deltaTime;
            if (spawner > endAt - 1)
                countUp = false;
            else if (spawner < startAt + 1)
                countUp = true;

            if (spawnTimeGap <= 0)
            {
                SpawnAppleAt(spawner);
                applesToSpawn -= 1;
                spawnTimeGap = SPAWNTIMEGAP;

                if (countUp)
                    spawner++;
                else
                    spawner--;
            }

            if (applesToSpawn == 0)
                spawnApplesTimer = Random.RandomRange(3, 5);
        }

    }

    public void TestInvoke()
    {
        Debug.Log(counter);
        counter++;
    }

    public void ZigZag(int repeatTimes)
    {

    }

    public void StraightLine(int appleSpawner)
    {

    }

    public void SpawnAppleAt(int spawner)
    {
        Instantiate(apple, spawners[spawner].transform.position, this.transform.rotation);
    }
}

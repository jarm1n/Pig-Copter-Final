using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {


    public int distance;
    public float timer;
    public bool inGame;
    public float spawnTimeMin, spawnTimeMax;
    public GameObject[] enemies;

    private int[] enemySpawnChance;
    private float spawnTimer;
    private float TIMER;
    private GameObject console;

    Vector2 prevPos;

    public enum e
    {
        METEOR=0,
        BIRD=1,
        EAGLE=2,
        ALIEN=3
    }

	void Start () {
        console = GameObject.FindGameObjectWithTag("Console");
        TIMER = timer;
        spawnTimer = Random.RandomRange(spawnTimeMin, spawnTimeMax);
        prevPos = new Vector2(-10, -10);
	}
	
	void Update () {

        inGame = console.GetComponent<Console>().inGame;

        if (inGame)
        {
            distance = console.GetComponent<Console>().distance;
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                int enemyNo = 1;
                enemySpawnChance = ComputeEnemieSpawnChance();

                if (distance > 500)
                {
                    if (Random.RandomRange(0, 10) < 3)
                    {
                        enemyNo = 2;
                    }
                }

                for (int i = 0; i < enemyNo; i++)
                {
                    int randomEnemy = Random.RandomRange(0, 100);
                    int selectedEnemy = SelectEnemy(randomEnemy, enemySpawnChance);
                    Vector3 newPos = new Vector3();
                    Quaternion rotation = new Quaternion();

                    if (selectedEnemy == (int)e.BIRD || selectedEnemy == (int)e.EAGLE ||
                        selectedEnemy == (int)e.ALIEN)
                    {
                        newPos.x = Random.RandomRange(-2.2f, 2.2f);
                        newPos.y = Random.RandomRange(7, 10);
                        newPos.z = 0;
                        rotation = Quaternion.Euler(0, 0, 0);
                    }
                    if (selectedEnemy == (int)e.METEOR)
                    {
                        newPos.x = Random.RandomRange(-2.2f, 2.2f);
                        newPos.y = Random.RandomRange(20, 40);
                        newPos.z = 0;
                        rotation = Quaternion.Euler(0, 0, 0);
                    }

                    //Checks if enemy is overlapping with previous enemy
                    newPos = ValidatePosition(prevPos, newPos);

                    //Instantiate the enemy and update timer, prevpos
                    Instantiate(enemies[selectedEnemy], newPos, rotation);
                    spawnTimer = Random.RandomRange(spawnTimeMin, spawnTimeMax);
                    prevPos = newPos;
                }
            }
        }
	}

    public Vector2 ValidatePosition(Vector2 prevPos, Vector2 newPos)
    {
        bool alterPos = false;
        if (newPos.x < prevPos.x && newPos.x > prevPos.x - 1.2f        //Is it to close to the left
            || newPos.x > prevPos.x && newPos.x < prevPos.x + 1.2f)    //Is it to close to the right
        {
            alterPos = true;
        }
        if (alterPos)
        {
            if (prevPos.x <= 0)
            {
                newPos.x = Random.RandomRange(prevPos.x + 1.5f, 2.2f);
            }
            else
            {
                newPos.x = Random.RandomRange(-2.2f, prevPos.x - 1.5f);
            }
        }
        return newPos;
    }

    public int SelectEnemy(int num, int[] spawnChances)
    {
        for (int i = 0; i < spawnChances.Length; i++)
        {
            if (num < spawnChances[i])
                return i;
        }
        Debug.Log("FAILED TO FIND ENEMY");
        return 0;
    }

    public int[] ComputeEnemieSpawnChance()
    {
        if (distance < 750)
            return new int[] { 10, 100, 0, 0, 0, 0 };
        else if (distance < 1500)
            return new int[] { 20, 70, 100, 0, 0, 0 };
        else if (distance < 2200)
            return new int[] { 20, 50, 70, 100, 0, 0 };

        return new int[] { 20, 50, 70, 100, 0, 0 };
    }

}

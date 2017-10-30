using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour {

    public GameObject c;

    public void SpawnApple()
    {
        Instantiate(c, this.transform.position, this.transform.rotation);
    }
}

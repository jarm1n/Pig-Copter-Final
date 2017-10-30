using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAppleSpawner : MonoBehaviour {

    public GameObject apple;

    public void SpawnApple()
    {
        Instantiate(apple, this.transform.position, this.transform.rotation);
    }
}

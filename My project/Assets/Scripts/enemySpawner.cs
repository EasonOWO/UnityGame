using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    float time = 0f;
    int monsterSpawnedNumber = 0;
    int whereToSpawn;
    public GameObject[] spawnpoint = new GameObject[8];
    public GameObject slime;
    public GameObject turtleshell;
    private GameObject targetSpawnMonster;
    // Start is called before the first frame update
    void Start()
    {
        targetSpawnMonster = slime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (monsterSpawnedNumber*2 <= time && time<300)
        {
            spawn();
            monsterSpawnedNumber += 1;
        }
        if (time > 60)
        {
            targetSpawnMonster = turtleshell;
        }
    }
    void spawn()
    {
        whereToSpawn = Random.Range(0, 8);
        if (time < 300)
            Instantiate(targetSpawnMonster, spawnpoint[whereToSpawn].transform.position, new Quaternion(0,0,0,0));
    }
}

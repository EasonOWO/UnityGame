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
    public GameObject yellowSpider;
    public GameObject onihito;
    public GameObject blackSpider;
    public GameObject dragon;
    private GameObject targetSpawnMonster;
    bool isSummonedDragon=false;
    // Start is called before the first frame update
    void Start()
    {
        targetSpawnMonster = slime;
        //time=290;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (monsterSpawnedNumber*2 <= time)
        {
            spawn();
            monsterSpawnedNumber += 1;
        }
        if (time > 60 && time < 120)
        {
            targetSpawnMonster = turtleshell;
        }
        if (time > 120 && time < 180)
        {
            targetSpawnMonster = yellowSpider;
        }
        if (time > 180 && time < 240)
        {
            targetSpawnMonster = onihito;
        }
        if (time > 240 && time < 300)
        {
            targetSpawnMonster = blackSpider;
        }
        if (time > 300)
        {
            targetSpawnMonster = null;
        }
    }
    void spawn()
    {
        whereToSpawn = Random.Range(0, 8);
        while(spawnpoint[whereToSpawn].transform.position.x > 40 || spawnpoint[whereToSpawn].transform.position.x < -40 ||
              spawnpoint[whereToSpawn].transform.position.z > 40 || spawnpoint[whereToSpawn].transform.position.z < -40)
                    whereToSpawn = Random.Range(0, 8);

        if (time < 300)
            Instantiate(targetSpawnMonster, spawnpoint[whereToSpawn].transform.position, new Quaternion(0,0,0,0));
        else if(time > 300)
        {
            Instantiate(dragon, new Vector3(0,0,0), new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        
    }
}

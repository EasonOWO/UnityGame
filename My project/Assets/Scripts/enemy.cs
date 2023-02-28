using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public int HP=50;
    public GameObject img;
    private int dropItem;
    public GameObject healItem;
    public GameObject dmgItem;
    void Start()
    {
        dropItem = Random.RandomRange(1, 101);
    }

    void Update()
    {
        if (HP <= 0) {
            if(dropItem>=1 && dropItem <= 4)
            {
                Instantiate(healItem, gameObject.transform.position + new Vector3(0,0.5f,0), new Quaternion(0,0,0,0));
            }
            if (dropItem >= 5 && dropItem <= 8)
            {
                Instantiate(dmgItem, gameObject.transform.position + new Vector3(0,0.5f,0), new Quaternion(0,0,0,0));
            }
            Destroy(gameObject);
        }
        if (characterControll.totalTime > 305)
        {
            dragonController.HP += 100;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        print(col.gameObject.name);
        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
            HP -= characterDamage.DMG;
            Instantiate(img);
        }
        
    }
}

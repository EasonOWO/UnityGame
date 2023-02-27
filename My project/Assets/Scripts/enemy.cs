using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public int HP=50;
    public GameObject img;
    
    void Update()
    {
        if (HP <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        print(col.gameObject.name);
        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
            HP -= 999;
            Instantiate(img);
        }
        
    }
}

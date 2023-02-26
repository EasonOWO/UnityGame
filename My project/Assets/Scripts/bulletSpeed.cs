using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{
    private float existingTime = 0f;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        existingTime += Time.deltaTime;
        if (existingTime > 5)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    
    //////////////////////////////////////

    
}

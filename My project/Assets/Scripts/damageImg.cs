using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageImg : MonoBehaviour
{
    float existingTime;
    // Start is called before the first frame update
    void Start()
    {
        existingTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        existingTime -= Time.deltaTime;
        if (existingTime < 0)
        {
            existingTime = 0.7f;
            gameObject.SetActive(false);
        }
    }
}

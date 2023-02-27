using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Time.deltaTime * 90, Time.deltaTime * 90, 0);
    }
}

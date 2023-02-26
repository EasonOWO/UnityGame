using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour
{
    public float time = 0f;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        gameObject.transform.parent = canvas.transform;
        gameObject.transform.position += new Vector3(578.75f, 246.75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.1f) Destroy(this.gameObject);
    }
}

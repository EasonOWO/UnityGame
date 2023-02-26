using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    public GameObject bullet;
    public Camera cam;
    public float speed = 2f;
    public float reload = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        reload -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && reload<0)
        {
            GameObject cloneBullet = Instantiate(bullet);
            cloneBullet.transform.position = cam.transform.position + transform.forward;
            cloneBullet.transform.forward = cam.transform.forward;
            reload = 0.25f;
        }
    }
}

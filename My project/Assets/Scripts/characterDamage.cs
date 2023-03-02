using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterDamage : MonoBehaviour
{
    public GameObject player;
    public static int DMG = 25;
    public static int HP = 100;
    // Start is called before the first frame update
    void Start()
    {
      //DMG = 200;
    }
    void Update()
    {
        if(HP<=0 || player.transform.position.y < -30)
        {
            UIControll.isDead = true;
            SceneManager.LoadScene("UI");
        }
    }
    // Update is called once per frame
}

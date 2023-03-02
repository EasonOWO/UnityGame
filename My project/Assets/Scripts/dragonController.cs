using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class dragonController : MonoBehaviour
{
    public static int HP = 6000;
    public GameObject img;
    Animator ani;
    public NavMeshAgent agent;
    public GameObject player;
    public float speed = 2f;

    public float timer = 0f;
    bool secPhase = false;
    int eventHappened = 0;
    void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.Find("player");
        ani.SetBool("isTracking", false);
        StartCoroutine(waiter(8.5f));
        HP = 6000;
    }

    void Update()
    {

        
        if (HP <= 0)
        {
            ani.SetBool("isTracking", false);
            ani.SetBool("isDead", true);
        }
        ////////////////////////////////////////////////////
        if (ani.GetBool("isTracking") == true)
        {
            chasePlayer();
        }
        ////////////////////////////////////////////////////
        if (HP <= 5000 && ani.GetBool("isSecondPhase")==false)
        {
            ani.SetBool("isSecondPhase", true);
            StartCoroutine(turnToPhaseTwo());
        }
        ////////////////////////////////////////////////////
        if (secPhase)
        {
            timer += Time.deltaTime;
            if (eventHappened * 10 < timer)
            {
                eventHappened++;
                StartCoroutine(run());
            }
        }
        ////////////////////////////////////////////////////
        if (HP <= 0)
        {
            StartCoroutine(winner());
        }
        ////////////////////////////////////////////////////

        ////////////////////////////////////////////////////
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
    
    
    void chasePlayer()
    {
        agent.SetDestination(player.transform.position);
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    
    
    IEnumerator waiter(float waitHowManySeconds)
    {
        yield return new WaitForSeconds(waitHowManySeconds);
        ani.SetBool("isTracking", true);
    }

    IEnumerator turnToPhaseTwo()
    {
        ani.SetBool("isTracking", false);
        yield return new WaitForSeconds(4f);
        ani.SetBool("isTracking", true);
        secPhase = true;
    }

    IEnumerator run()
    {
        speed *= 5;
        ani.SetBool("isRunning", true);
        yield return new WaitForSeconds(3f);
        speed /= 5;
        ani.SetBool("isRunning", false);
    }
    IEnumerator winner()
    {
        UIControll.isWin = true;
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("UI");
    }
}

/*

*/

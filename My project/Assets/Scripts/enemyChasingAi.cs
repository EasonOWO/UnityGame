using UnityEngine;
using UnityEngine.AI;

public class enemyChasingAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float speed=2f;
    private void Start()
    {
        player=GameObject.Find("player");
    }
    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }

    void chasePlayer()
    {
        agent.SetDestination(player.transform.position);
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

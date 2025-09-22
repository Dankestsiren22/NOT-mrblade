using UnityEngine;
using UnityEngine.AI;
public class Melee : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform player;
    public float SwingRange;
    public float health = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;

        //if (Vector3.Distance(transform.position, player.position) < SwingRange)
        //attack
        if (health <= 0)
            Destroy(gameObject);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Ranger : MonoBehaviour
{
    NavMeshAgent agent;
    public int speed;
    public int stopdistance;
    public int shootdistance;
    public GameObject Shot;
    private Transform player;
    public int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, player.position) < stopdistance)
        {
            agent.destination = Vector3.MoveTowards(transform.position, player.position, -speed);
        }
        else if(Vector3.Distance(transform.position, player.position) > stopdistance)
        {
            agent.destination = Vector3.MoveTowards(transform.position, player.position, speed);
        }

        //if (Vector3.Distance(transform.position, player.position) = shootdistance)
        {
            //shoot shot's
        }


        if (health <= 0)
            Destroy(gameObject);

    }










}


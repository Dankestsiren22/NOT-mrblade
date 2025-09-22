using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Ranger : MonoBehaviour
{
    NavMeshAgent agent;
    public float speed;
    public float stopdistance;
    public GameObject Shot;
    private Transform player;

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

        

  
    }










}


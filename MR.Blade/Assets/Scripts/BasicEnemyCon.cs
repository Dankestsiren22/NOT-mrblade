using UnityEngine;
using UnityEngine.AI;
public class BasicEnemyCon : MonoBehaviour
{

    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;
    }
}

using UnityEngine;
using UnityEngine.AI;
public class BasicProject : MonoBehaviour
{

    NavMeshAgent agent;
    public int speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("player").transform.position * speed;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player") 

           Destroy(gameObject);
        
    }
}

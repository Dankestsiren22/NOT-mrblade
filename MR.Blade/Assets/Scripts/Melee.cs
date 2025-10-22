using UnityEngine;
using UnityEngine.AI;
public class Melee : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform player;
    public float SwingRange;
    
    public GameObject Katana;
    public float health = 5;
    Reggy Reggy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        //Katana = GameObject.FindWithTag("Katana").GetComponent<BoxCollider>();
        agent = GetComponent<NavMeshAgent>();
        Reggy = GameObject.FindGameObjectWithTag("Reggy").GetComponent<Reggy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;

        if (Vector3.Distance(transform.position, player.position) < SwingRange)
        {
           //Katana.BoxCollider.SetActive(true);
        }
        
        if (Reggy.St1P1 == true)
        {
            if (health <= 0)
            {
                Reggy.ST1P1Health--;
                Destroy(gameObject);

            }
        }
        if (Reggy.St1P2 == true)
        {
            if (health <= 0)
            {
                Reggy.ST1P2Health--;
                Destroy(gameObject);

            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "prog")
            health--;
    }



}

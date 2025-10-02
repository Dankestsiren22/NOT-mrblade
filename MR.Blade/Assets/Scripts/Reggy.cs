using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Reggy : MonoBehaviour
{
    NavMeshAgent agent;
    public int Demons = 0;
    public int speed = 1;
    public int health = 1000;
    public int maxHealth = 1000;
    public Vector3 spawnPoint;
    public GameObject ranger;
    public GameObject melee;
    private Transform player;
    //private int spawnammount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        player = GameObject.FindWithTag("player").transform;
        //spawnammount = 0;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] spawnammount;
        spawnammount = GameObject.FindGameObjectsWithTag("demon");

        spawnPoint = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f));
        //spawnammount = GameObject.FindGameObjectsWithTag("demon");

       if (Demons <= 100 && spawnammount.Length  <= 10)
        {
            Instantiate(melee, spawnPoint, transform.rotation);
            
        }
        
       
            


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "prog")
            health--;
    }

}


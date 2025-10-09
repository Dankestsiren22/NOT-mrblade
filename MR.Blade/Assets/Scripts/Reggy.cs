using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Reggy : MonoBehaviour
{
    //general info
    public bool candamage = true;
    public int speed = 1;
    
    public Vector3 spawnPoint;
    public GameObject ranger;
    public GameObject melee;
    private Transform player;
    // Stage 1
    public bool St1P1 = false;
    public bool St1P2 = false;
    public int ST1P1MaxHealth = 50;
    public int ST1P2MaxHealth = 50;
    public int ST1P1Health = 50;
    public int ST1P2Health = 50;
    public int Demons = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        player = GameObject.FindWithTag("player").transform;
        candamage = false;
        St1P1 = true;
        //spawnammount = 0;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (St1P1 == true)
        {
            GameObject[] spawnammount;
            spawnammount = GameObject.FindGameObjectsWithTag("demon");

            spawnPoint = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f));
            //spawnammount = GameObject.FindGameObjectsWithTag("demon");

            if (spawnammount.Length <= 10)
            {
            
                Instantiate(melee, spawnPoint, transform.rotation);
                
                

            }
            if (ST1P1Health == 0)
            {
                St1P1 = false;
                St1P2 = true;
            }
        }
       if (St1P2 == true)
        {
            spawnPoint = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f));
            spawnPoints = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f));
            GameObject[] spawnammounts;
            spawnammounts = GameObject.FindGameObjectsWithTag("demons");
            GameObject[] spawnammount;
            spawnammount = GameObject.FindGameObjectsWithTag("demon");

            if (spawnammount.Length <= 10)
            {
                
                Instantiate(melee, spawnPoint, transform.rotation);



            }

            if (spawnammounts.Length <= 10)
            {

                Instantiate(ranger, spawnPoints, transform.rotation);



            }


        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "prog")
        {
            ST1P1Health--;
            ST1P2Health--;
        }
           
    }

}


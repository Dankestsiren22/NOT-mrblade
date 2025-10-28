using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Reggy : MonoBehaviour
{
    //SPawnPOints
    public Vector3 spawn1;
    public Vector3 spawn2;
    public Vector3 spawn3;
    public Vector3 spawn4;
    public Vector3 spawn5;
    public Vector3 spawn6;
    public Vector3 spawn7;
    public Vector3 spawn8;
    

    //general info
    public bool candamage = true;
    public Vector3 St2point;
    public int speed = 1;
    NavMeshAgent ReggyAi;
    public Vector3 spawnPoint;
    public Vector3 spawnPoints;
    public GameObject ranger;
    public GameObject melee;
    private Transform player;
    public bool SpawnedEnemys1;
    public bool SpawnedEnemy2;
    // Stage Bools
    public bool St1P1 = false;
    public bool St1P2 = false;
    public bool St2 = false;
    //Stage Health's
    public int ST1P1MaxHealth = 50;
    public int ST1P2MaxHealth = 50;
    public int ST1P1Health = 50;
    public int ST1P2Health = 50;
    public int ST2Health = 1000;
    public int ST2HealthMax = 1000;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnedEnemys1 = false;
        SpawnedEnemy2 = false;
        player = GameObject.FindWithTag("player").transform;
        candamage = false;
        St1P1 = true;
        ReggyAi = GetComponent<NavMeshAgent>();
        St2point = new Vector3(0, 1, 85);
        //spawnammount = 0;



    }

    // Update is called once per frame
    void Update()
    {
        if (St1P1 == true && SpawnedEnemys1 == false)
        {

            Instantiate(melee, spawn1, transform.rotation);
            Instantiate(melee, spawn2, transform.rotation);
            Instantiate(melee, spawn3, transform.rotation);
            Instantiate(melee, spawn4, transform.rotation);
            Instantiate(melee, spawn5, transform.rotation);
            Instantiate(melee, spawn6, transform.rotation);
            Instantiate(melee, spawn7, transform.rotation);
            Instantiate(melee, spawn8, transform.rotation);
            SpawnedEnemys1 = true;

            
        }
        if (ST1P1Health == 0)
        {
            St1P1 = false;
            St1P2 = true;
        }

        if (St1P2 == true && SpawnedEnemy2 == false)
        {

            Instantiate(melee, spawnPoint, transform.rotation);
            Instantiate(ranger, spawnPoints, transform.rotation);
            Instantiate(melee, spawnPoint, transform.rotation);
            Instantiate(ranger, spawnPoints, transform.rotation);
            Instantiate(ranger, spawnPoints, transform.rotation);
            SpawnedEnemy2 = true;
        }
    
       if (ST1P2Health == 0)
        {
            //play cutsence 
            St1P2 = false;
            St2 = true;

        }

       if (St2 == true)
        {
            candamage = true;
            transform.position = St2point;
        }
       
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (candamage == true)
        {
            if (collision.gameObject.tag == "prog")
            {
                ST1P1Health--;
                ST1P2Health--;
            }
        }
       
           
    }

}


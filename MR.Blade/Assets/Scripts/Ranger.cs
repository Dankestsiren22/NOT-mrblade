using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Ranger : MonoBehaviour
{
    Reggy Reggy;
    NavMeshAgent agent;
    public int speed;
    public int stopdistance;
    public int shootdistance;
    public GameObject Shot;
    private Transform player;
    public int health = 3;
    public Transform ShotPoint;
    public Vector3 spawnPoint;
    public bool canshoot;
    public float rateofire;
    public int projLifespan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
        Reggy = GameObject.FindGameObjectWithTag("Reggy").GetComponent<Reggy>();
        canshoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Shotammount;
        Shotammount = GameObject.FindGameObjectsWithTag("Basic Project");

        if (Vector3.Distance(transform.position, player.position) > stopdistance)
        {
            agent.destination = Vector3.MoveTowards(transform.position, player.position, speed);
        }

        else if (Vector3.Distance(transform.position, player.position) < stopdistance)
        {
            agent.destination = Vector3.MoveTowards(transform.position, player.position, -speed);
        }

        


        if (Vector3.Distance(transform.position, player.position) >= shootdistance && canshoot == true)
        {
            GameObject p = Instantiate(Shot, ShotPoint.position, transform.rotation);
            Destroy(p, projLifespan);
            canshoot = false;
            StartCoroutine("cooldownFire", rateofire);
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

    IEnumerator cooldownFire(float cooldownTime)
    {

        yield return new WaitForSeconds(cooldownTime);
        canshoot = true;
        
    }



}














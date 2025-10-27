using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Ranger : MonoBehaviour
{
    Reggy Reggy;
    public float Cooldown;
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

        agent.destination = GameObject.Find("player").transform.position;



        if (Vector3.Distance(transform.position, player.position) >= shootdistance && canshoot == true)
        {
            GameObject p = Instantiate(Shot, ShotPoint.position, transform.rotation);
            Destroy(p, projLifespan);
            canshoot = false;
            StartCoroutine("cooldownFire");
            return;
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

    IEnumerator cooldownFire()
    {

        yield return new WaitForSeconds(Cooldown);
        canshoot = true;
        
    }



}














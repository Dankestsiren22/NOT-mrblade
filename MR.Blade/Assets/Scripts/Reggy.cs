using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Reggy : MonoBehaviour
{
    NavMeshAgent agent;
    private int Demons = 0;
    public int speed = 1;
    public int health = 1;
    public Vector3 spawnPoint;
    public GameObject ranger;
    public GameObject melee;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        spawnPoint = new Vector3(player.position.x + 5, 1, player.position.z + 5);
        
        Instantiate(melee, spawnPoint, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Demons == 100)
            
      


    }






}


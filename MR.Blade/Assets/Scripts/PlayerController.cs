using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    

    Camera playerCam;
    Rigidbody rb;
    
    public Vector3 respawnPoint;

    float verticalmove;
    float horizontalmove;

    public float speed = 5f;
    public float jumpHeight = 10f;
    public float GroundDetetlenght = .5f;
    Ray ray;
    RaycastHit hit;
    public int health = 5;
    public int maxhealth = 5;
    //// Start is called once before the first execution of Update after the MonoBehaviour is created////
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
        respawnPoint = new Vector3(0, 1, 0);
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
  
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //// Update is called once per frame////
    void Update()
    {
        if (health <= 0)
        {
            transform.position = respawnPoint;
            health = maxhealth;
        }

        ////camera rotatiom////
        Quaternion playerRotaion = playerCam.transform.rotation;
        playerRotaion.x = 0;
        playerRotaion.z = 0;
        transform.rotation = playerRotaion;
        
        //// movment system////
        Vector3 temp = rb.linearVelocity;
        temp.x = verticalmove * speed;
        temp.z = horizontalmove * speed;

        ray.origin = transform.position;
        ray.direction = -transform.up;
        

       

        rb.linearVelocity = (temp.x * transform.forward) + (temp.y * transform.up) + (temp.z * transform.right);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputAxis = context.ReadValue<Vector2>();
        verticalmove = inputAxis.y;
        horizontalmove = inputAxis.x;
      
    }
    public void jump()
    {
        if(Physics.Raycast(ray, GroundDetetlenght))
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
     
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "killzone")
        health = 0;

        if ((other.tag == "Health") && (health < maxhealth))
                health++;
                Destroy(other.gameObject);
            


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
            health--;
    }

}




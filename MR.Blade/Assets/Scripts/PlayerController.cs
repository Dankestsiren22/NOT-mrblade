using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Vector2 cameraRotation;
    InputAction lookVector;
    Transform playerCam;
    Rigidbody rb;
    Transform camHolder;
    public Vector3 respawnPoint;

    float verticalmove;
    float horizontalmove;
    public float speed = 5f;
    public float jumpHeight = 10f;
    public float xsensitvity = 1.0f;
    public float ysensitvity = 1.0f;
    public float camrotationlimit = 90.0f;

    public int health = 5;
    public int maxhealth = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnPoint = new Vector3(0, 1, 0);
        rb = GetComponent<Rigidbody>();
        playerCam = transform.GetChild(0);
        lookVector = GetComponent<PlayerInput>().currentActionMap.FindAction("Look");
        cameraRotation = Vector2.zero;
        camHolder = transform.GetChild(0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            transform.position = respawnPoint;
            health = maxhealth;
        }
        
        //camera rotatiom
        //playerCam.transform.position = camHolder.position;


        cameraRotation.x += lookVector.ReadValue<Vector2>().x * xsensitvity;
        cameraRotation.y += lookVector.ReadValue<Vector2>().y * ysensitvity;

        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -camrotationlimit, camrotationlimit);
        

        playerCam.rotation = Quaternion.Euler(-cameraRotation.y, cameraRotation.x, 0);
        transform.localRotation = Quaternion.AngleAxis(cameraRotation.x, Vector3.up);
        
        // movment system
        Vector3 temp = rb.linearVelocity;
        temp.x = verticalmove * speed;
        temp.z = horizontalmove * speed;

        rb.linearVelocity = (temp.x * transform.forward) + (temp.y * transform.up) + (temp.z * transform.right);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputAxis = context.ReadValue<Vector2>();
        verticalmove = inputAxis.y;
        horizontalmove = inputAxis.x;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "killzone")
        health = 0;
    }
     
}




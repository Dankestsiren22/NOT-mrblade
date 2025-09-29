using UnityEngine;

public class BulletsDe : MonoBehaviour
{




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "demon")
            Destroy(gameObject);
        else
            Destroy(gameObject);
    }



}

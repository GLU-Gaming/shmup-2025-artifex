using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] private int forwardThrust = 0;
    Rigidbody rb;
    [SerializeField] ParticleSystem bulletCollision;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(transform.forward * forwardThrust);
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

       
        
         Destroy(gameObject);
         
        
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(bulletCollision, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "ForceField")
        {
            
                Instantiate(bulletCollision, transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            
        }
    }


}
